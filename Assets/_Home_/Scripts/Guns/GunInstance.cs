using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GunInstance
{
    public GunData gun;
    public int currentBullets;
    public int extraBullets;

    public GunInstance(GunData gun, int currentBullets = -1, int extraBullets = -1)
    {
        this.gun = gun;
        // Use magazine size as bullet count if there is none specified
        this.currentBullets = currentBullets < 0 ? gun.magazineSize : currentBullets;
        this.currentBullets = extraBullets < 0 ? gun.magazineSize : extraBullets;
    }
}
