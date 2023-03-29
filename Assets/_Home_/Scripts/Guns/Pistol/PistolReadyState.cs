using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PistolReadyState : GunState
{
    public override void Shoot(InputAction.CallbackContext c)
    {
        if (c.started)
            Debug.Log("Pium");
    }
}
