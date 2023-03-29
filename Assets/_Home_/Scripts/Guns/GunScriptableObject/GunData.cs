using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "GunData", menuName = "Top-Down Shooter/GunData", order = 0)]
public class GunData : ScriptableObject
{
    [Header("Gun information")]
    public int magazineSize;
    public float damagePerHit, reloadSeconds;
    public bool hasCooldown;
    [ShowIf("hasCooldown")]
    public float cooldownSeconds;
    public bool hasChargingTime;
    [ShowIf("hasChargingTime")]
    public float chargeSeconds = 0f;
    [Header("State machine information")]
    public string initialStateName = "";

    private void OnEnable()
    {
        SetInitialStateName();
    }
    private void OnValidate()
    {
        SetInitialStateName();
    }

    private void SetInitialStateName()
    {
        if (initialStateName.Equals("") || initialStateName.Equals("ReadyState"))
        {
            initialStateName = name + "ReadyState";
        }
    }

}