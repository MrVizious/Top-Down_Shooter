using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using UnityEngine;
using UtilityMethods;
using ExtensionMethods;
using Cysharp.Threading.Tasks;
using UnityEngine.InputSystem;

public class PistolCooldownState : GunState
{
    public override void Enter(StateMachine<GunState> newStateMachine)
    {
        base.Enter(newStateMachine);
        Debug.Log("Cooling down");
        UtilityMethods.UniTaskMethods.DelayedFunction(() => EndCooldown(), gunController.currentGun.gun.cooldownSeconds).Forget();
    }

    private void EndCooldown()
    {
        if (gunController.currentGun.currentBullets > 0)
        {
            gunController.SubstituteStateWith(this.GetOrAddComponent<PistolReadyState>());
        }
        else
        {
            gunController.SubstituteStateWith(this.GetOrAddComponent<PistolEmptyState>());
        }
    }

    public override void Reload(InputAction.CallbackContext c)
    {
        if (gunController.currentGun.currentBullets >= gunController.currentGun.gun.magazineSize) return;
        gunController.SubstituteStateWith(this.GetOrAddComponent<PistolReloadingState>());
    }

    public override void Exit()
    {
        Destroy(this);
    }
}