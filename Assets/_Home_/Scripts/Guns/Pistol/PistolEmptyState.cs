using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using ExtensionMethods;

public class PistolEmptyState : GunState
{
    public override void Shoot(InputAction.CallbackContext c)
    {
        if (gunController.currentGun.extraBullets > 0)
        {
            gunController.SubstituteStateWith(this.GetOrAddComponent<PistolReloadingState>());
        }
        /*
            else{
                //play sound
            }
        */
    }
    public override void Reload(InputAction.CallbackContext c)
    {
        if (gunController.currentGun.currentBullets >= gunController.currentGun.gun.magazineSize) return;
        gunController.SubstituteStateWith(this.GetOrAddComponent<PistolReloadingState>());
    }

    public override void Exit()
    {
        this.enabled = false;
    }
}
