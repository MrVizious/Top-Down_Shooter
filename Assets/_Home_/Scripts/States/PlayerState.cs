using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using UnityEngine.InputSystem;

public abstract class PlayerState : MonoBehaviour, State<PlayerState>
{
    public StateMachine<PlayerState> stateMachine
    {
        get;
        protected set;
    }
    public virtual void Move(InputAction.CallbackContext c) { }

    public virtual void Dash() { }

    public virtual void Enter(StateMachine<PlayerState> newStateMachine)
    {
        this.enabled = true;
        stateMachine = newStateMachine;
    }

    public virtual void Exit()
    {
        this.enabled = false;
    }
}