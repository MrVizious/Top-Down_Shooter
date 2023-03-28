using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ExtensionMethods;
using DesignPatterns;

public class IdleState : PlayerState
{

    public override void Enter(StateMachine<PlayerState> newStateMachine)
    {
        //Debug.Log("Entering idle state");
        base.Enter(newStateMachine);
        if (playerController.lastMovementInput.sqrMagnitude > 0.1f)
        {
            playerController.ChangeToState(this.GetOrAddComponent<MovingState>());
            return;
        }
    }

    public override void Move(InputAction.CallbackContext c)
    {
        base.Move(c);
        if (playerController.lastMovementInput.sqrMagnitude > 0.1f)
        {
            playerController.ChangeToState(this.GetOrAddComponent<MovingState>());
            return;
        }
    }

    public override void Dash()
    {
        DashingState dashingState = this.GetOrAddComponent<DashingState>();
        dashingState.direction = playerController.playerLook.lookDirection;
        playerController.ChangeToState(dashingState);
    }
}