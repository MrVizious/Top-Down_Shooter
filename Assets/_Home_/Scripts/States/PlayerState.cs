using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using UnityEngine.InputSystem;

public abstract class PlayerState : State<PlayerState>
{
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
}