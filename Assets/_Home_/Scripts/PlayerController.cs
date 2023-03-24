using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UnityEngine.InputSystem;
using DesignPatterns;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : StateMachine<PlayerState>
{
    public Rigidbody2D rb { get; private set; }
    private void Start()
    {
        rb = this.GetOrAddComponent<Rigidbody2D>();
        ChangeToState(this.GetOrAddComponent<IdleState>());
    }
    public float speed = 3f;

    public void Movement(InputAction.CallbackContext c)
    {
        currentState.Move(c);
    }

    public void Look(InputAction.CallbackContext c) { }

    public void Dash(InputAction.CallbackContext c)
    {
        Debug.Log("Trying to dash");
        if (c.performed)
            currentState.Dash();
    }

}
