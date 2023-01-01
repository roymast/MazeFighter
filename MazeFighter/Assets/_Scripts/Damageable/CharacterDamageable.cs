using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterDamageable : MonoBehaviour, IDamageable
{
    public event Action<int> OnDamage;
    public void Damage(int damage)
    {        
        Debug.Log("CharacterDamageable:Damage()");
        OnDamage?.Invoke(damage);
    }
}
