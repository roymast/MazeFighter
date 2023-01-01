using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Gun", menuName ="Gun")]
public class GunSO : WeaponSO
{   
    public int BulletsPerMagasine;
    public float ReloadingTime;
    
    public int MagasinesAmount;        

    public int BulletDamage;    
    public float BulletSpeed;
    public float BulletDeviation;
    public bool IsAutomatic;
}
