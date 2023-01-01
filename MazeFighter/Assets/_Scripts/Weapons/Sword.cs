using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : IWeapon
{
    public override void ChangeWeapon(WeaponSO weaponSO)
    {
        base.ChangeWeapon(weaponSO);
        Debug.Log("SwordChangeWeapon");
    }
    public override void Use()
    {
        Debug.Log("Sword.Use()");
        base.Use();
    }    
}
