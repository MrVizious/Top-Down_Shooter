using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ExtensionMethods;
using DesignPatterns;

public class PistolReadyState : GunState
{

    public override void Shoot(InputAction.CallbackContext c)
    {
        if (c.started)
            gunController.ChangeToState(this.GetOrAddComponent<PistolShootingState>());
    }

    public override void Reload(InputAction.CallbackContext c)
    {
        if (gunController.currentGun.currentBullets >= gunController.currentGun.gun.magazineSize) return;
        gunController.ChangeToState(this.GetOrAddComponent<PistolReloadingState>());
    }

    public override void Exit()
    {
        this.enabled = false;
    }
}