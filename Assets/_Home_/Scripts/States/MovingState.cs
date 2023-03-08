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
    public override void Enter(StateMachine<PlayerState> newStateMachine)
    {
        rb = this.GetOrAddComponent<Rigidbody2D>();
    }

    public override void Move(InputAction.CallbackContext c)
    {
        lastMovementInput = c.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.MovePosition((Vector2)rb.position + lastMovementInput * 2f * Time.deltaTime);
    }
}
