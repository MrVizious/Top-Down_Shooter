using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using UnityEngine.InputSystem;
using DesignPatterns;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerLook))]
public class PlayerController : StateMachine<PlayerState>
{

    public PlayerData playerData;
    [HideInInspector] public Rigidbody2D rb { get; private set; }
    [HideInInspector] public PlayerLook playerLook { get; private set; }
    [HideInInspector] public Vector2 lastMovementInput;
    private void Start()
    {
        rb = this.GetOrAddComponent<Rigidbody2D>();
        playerLook = this.GetOrAddComponent<PlayerLook>();
        ChangeToState(this.GetOrAddComponent<IdleState>());
    }

    public void Movement(InputAction.CallbackContext c)
    {
        lastMovementInput = c.ReadValue<Vector2>();
        currentState.Move(c);
    }


    public void Dash(InputAction.CallbackContext c)
    {
        if (c.started)
            currentState.Dash();
    }

}
