using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ExtensionMethods;

public class PistolReadyState : GunState
{
    public override void Shoot(InputAction.CallbackContext c)
    {
        if (c.started)
            gunController.ChangeToState(this.GetOrAddComponent<PistolShootingState>());
    }
}
