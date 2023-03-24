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
    public virtual void Look(InputAction.CallbackContext c)
    {
        // Mouse controls
        if (c.action.activeControl.device.displayName.Equals("Mouse"))
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = Camera.main.nearClipPlane;
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(mousePos);
        }
    }

    public virtual void Dash() { }

    public virtual void Enter(StateMachine<PlayerState> newStateMachine)
    {
        this.enabled = true;
        stateMachine = newStateMachine;
    }

    public void Exit()
    {
        this.enabled = false;
    }
}