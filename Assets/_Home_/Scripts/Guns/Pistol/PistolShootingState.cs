using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using UnityEngine;
using ExtensionMethods;

public class PistolShootingState : GunState
{
    public override void Enter(StateMachine<GunState> newStateMachine)
    {
        base.Enter(newStateMachine);
        Debug.Log("Pium");
        gunController.SubstituteStateWith(this.GetOrAddComponent<PistolCooldownState>());
    }

    public override void Exit()
    {
        Destroy(this);
    }
}
