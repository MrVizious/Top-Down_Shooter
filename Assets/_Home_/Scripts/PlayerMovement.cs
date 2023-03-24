using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using ExtensionMethods;
using UnityEngine.InputSystem;

public class PlayerMovement : StateMachine<PlayerState>
{
    public float speed = 3f;
    private void Start()
    {
        ChangeToState(this.GetOrAddComponent<MovingState>());
    }

    public override void SubstituteStateWith(PlayerState newState)
    {
        throw new System.NotImplementedException();
    }

    public void Movement(InputAction.CallbackContext c)
    {
        currentState.Move(c);
    }

    public void Look(InputAction.CallbackContext c) { }
}