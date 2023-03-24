using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UtilityMethods;

public class DashingState : PlayerState
{
    public override void Enter(StateMachine<PlayerState> newStateMachine)
    {
        Debug.Log("Entering dash state");
        base.Enter(newStateMachine);
        UniTaskMethods.DelayedFunction(() => stateMachine.ChangeToPreviousState(), 3f);
    }

}
