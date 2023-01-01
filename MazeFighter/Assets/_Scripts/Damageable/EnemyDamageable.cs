using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageable : MonoBehaviour, IDamageable
{
    public void Damage()
    {
        Debug.Log("EnemyDamageable:Damage()");
    }
}
