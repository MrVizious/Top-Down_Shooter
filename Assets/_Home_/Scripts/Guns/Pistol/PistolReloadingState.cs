using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;
using DesignPatterns;
using Cysharp.Threading.Tasks;


public class PistolReloadingState : GunState
{
    public override void Enter(StateMachine<GunState> newStateMachine)
    {
        base.Enter(newStateMachine);
        UtilityMethods.UniTaskMethods.DelayedFunction(() => EndReload(), gunController.currentGun.gun.reloadSeconds).Forget();
    }

    private void EndReload()
    {
        gunController.currentGun.Reload();
        gunController.SubstituteStateWith(this.GetOrAddComponent<PistolReadyState>());
    }
}
