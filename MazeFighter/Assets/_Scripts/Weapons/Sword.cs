using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : IWeapon
{
    public override void Use()
    {
        Debug.Log("Sword.Use()");
        base.Use();
    }    
}
