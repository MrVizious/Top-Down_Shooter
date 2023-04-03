using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using ExtensionMethods;
using System;
using UnityEngine.InputSystem;
using Sirenix.OdinInspector;

public class GunController : StateMachine<GunState>
{
    private GunInstance _currentGun;
    public GunInstance currentGun
    {
        get
        {
            if (_currentGun == null)
            {
                if (acquiredGuns != null && acquiredGuns.Count > 0)
                {
                    currentGun = acquiredGuns[0];
                    return _currentGun;
                }
                return null;
            }
            return _currentGun;
        }
        set
        {
            _currentGun = value;
        }
    }
    [SerializeField] private List<GunInstance> acquiredGuns;
    private void Start()
    {
        GunState initialState = (GunState)this.GetOrAddComponent(Type.GetType(currentGun.gun.initialStateName));
        ChangeToState(initialState);
    }

    #region Gun Selection

    public void AddGun(GunData newGun, int currentBullets = -1, int extraBullets = -1)
    {
        acquiredGuns.Add(new GunInstance(newGun, currentBullets, extraBullets));
    }

    public void AddGun(GunInstance newGun)
    {
        acquiredGuns.Add(newGun);
    }

    [Button]
    public void RemoveCurrentGun()
    {
        GunInstance gunToRemove = currentGun;
        currentGun = acquiredGuns[(acquiredGuns.IndexOf(currentGun) + 1) % acquiredGuns.Count];
        acquiredGuns.Remove(gunToRemove);
    }

    #endregion

    #region Gun Actions

    public void Shoot(InputAction.CallbackContext c)
    {
        currentState?.Shoot(c);
    }

    public void Reload(InputAction.CallbackContext c)
    {
        if (c.performed)
            currentState?.Reload(c);
    }

    #endregion
}