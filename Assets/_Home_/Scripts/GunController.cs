using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using ExtensionMethods;
using System;
using UnityEngine.InputSystem;

public class GunController : StateMachine<GunState>
{
    public GunData gun;
    private void Start()
    {
        GunState initialState = (GunState)this.GetOrAddComponent(Type.GetType(gun.initialStateName));
        ChangeToState(initialState);
    }

    public void Shoot(InputAction.CallbackContext c)
    {
        currentState?.Shoot(c);
    }
}