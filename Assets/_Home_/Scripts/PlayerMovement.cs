using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using ExtensionMethods;
using UnityEngine.InputSystem;

public class PlayerMovement : StateMachine<PlayerState>
{
    private void Start()
    {
        ChangeToState(this.GetOrAddComponent<MovingState>());
    }
    public override void ChangeToPreviousState()
    {
        throw new System.NotImplementedException();
    }

    public override void ChangeToState(PlayerState newState)
    {
        currentState?.Exit(this);
        currentState = newState;
        newState.Enter(this);
    }

    public override void SubstituteStateWith(PlayerState newState)
    {
        throw new System.NotImplementedException();
    }

    public void Movement(InputAction.CallbackContext c)
    {
        currentState.Move(c);
    }

    public void Look(InputAction.CallbackContext c)
    {
    }
}
