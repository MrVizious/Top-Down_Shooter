using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using UnityEngine;
using UtilityMethods;
using ExtensionMethods;
using Cysharp.Threading.Tasks;

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
        gunController.SubstituteStateWith(this.GetOrAddComponent<PistolReadyState>());
    }

    public override void Exit()
    {
        Destroy(this);
    }
}