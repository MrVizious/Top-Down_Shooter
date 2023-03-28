using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UnityEngine.InputSystem;
using DesignPatterns;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingState : PlayerState
{
    private Rigidbody2D rb;
    public override void Enter(StateMachine<PlayerState> newStateMachine)
    {
        //Debug.Log("Entering moving state");
        base.Enter(newStateMachine);
        rb = ((PlayerController)stateMachine).rb;
    }

    public override void Dash()
    {
        DashingState dashingState = this.GetOrAddComponent<DashingState>();
        dashingState.direction = playerData.lastMovementInput.normalized;
        stateMachine.SubstituteStateWith(dashingState);
    }

    private void Update()
    {
        if (playerData.lastMovementInput.sqrMagnitude < 0.1f)
        {
            stateMachine.ChangeToState(this.GetOrAddComponent<IdleState>());
            return;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)rb.position + playerData.lastMovementInput * playerData.speed * Time.deltaTime);
    }
}
