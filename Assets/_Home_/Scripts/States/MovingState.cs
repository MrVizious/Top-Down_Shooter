using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UnityEngine.InputSystem;
using DesignPatterns;

[RequireComponent(typeof(Rigidbody2D))]
public class MovingState : PlayerState
{
    public float speed = 3f;
    private Vector2 lastMovementInput = Vector2.zero;
    private Rigidbody2D rb;
    public override void Enter(StateMachine<PlayerState> newStateMachine)
    {
        Debug.Log("Entering moving state");
        base.Enter(newStateMachine);
        rb = ((PlayerController)stateMachine).rb;
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
        stateMachine.SubstituteStateWith(this.GetOrAddComponent<DashingState>());
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)rb.position + lastMovementInput * speed * Time.deltaTime);
    }
}
