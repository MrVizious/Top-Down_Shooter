using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using UnityEngine;
using Cysharp.Threading.Tasks;
using UtilityMethods;
using ExtensionMethods;

public class DashingState : PlayerState
{
    public Vector2 direction;
    private bool dashing = false;
    private PlayerData playerData;
    private Rigidbody2D rb;
    public override void Enter(StateMachine<PlayerState> newStateMachine)
    {
        //Debug.Log("Entering dash state");
        base.Enter(newStateMachine);
        rb = ((PlayerController)stateMachine).rb;
        playerData = ((PlayerController)stateMachine).playerData;
        Dashing().Forget();
        UniTaskMethods.DelayedFunction(() => StopDashing(), playerData.dashDuration).Forget();
    }

    private async UniTask Dashing()
    {
        dashing = true;
        while (dashing)
        {
            rb.MovePositionInDirection(playerData.dashSpeed * direction * Time.fixedDeltaTime);
            await UniTask.WaitForFixedUpdate();
        }
    }

    public void StopDashing()
    {
        dashing = false;
        Debug.Log("Stopping dash");
        stateMachine.ChangeToPreviousState();
    }

}
