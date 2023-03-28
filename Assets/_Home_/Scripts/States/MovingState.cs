using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UnityEngine.InputSystem;
using DesignPatterns;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingState : PlayerState
{
    private Vector2 lastMovementInput = Vector2.zero;
    private Rigidbody2D rb;
    private PlayerData playerData;
    public override void Enter(StateMachine<PlayerState> newStateMachine)
    {
        //Debug.Log("Entering moving state");
        base.Enter(newStateMachine);
        rb = ((PlayerController)stateMachine).rb;
        playerData = ((PlayerController)stateMachine).playerData;
    }

    public override void Move(InputAction.CallbackContext c)
    {
        lastMovementInput = c.ReadValue<Vector2>();
        if (lastMovementInput.sqrMagnitude < 0.1f)
        {
            stateMachine.ChangeToState(this.GetOrAddComponent<IdleState>());
        }
    }

    public override void Dash()
    {
        DashingState dashingState = this.GetOrAddComponent<DashingState>();
        dashingState.direction = lastMovementInput.normalized;
        stateMachine.SubstituteStateWith(dashingState);
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)rb.position + lastMovementInput * playerData.speed * Time.deltaTime);
    }
}
