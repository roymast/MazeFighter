using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    [Header("Weapon Starting Stats")]
    [SerializeField] protected float _timeBetweenUses;
    [SerializeField] protected float _lastTimeUsed;
    [SerializeField] protected Sprite _sprite;
    public static event Action<WeaponSO> OnWeaponChange;
    public static event Action<IWeapon> OnWeaponUpdate;

    private void Start()
    {
        _lastTimeUsed = Time.time;
    }
    public virtual void ChangeWeapon(WeaponSO weaponSO)
    {
        _timeBetweenUses = weaponSO.TimeBetweenUses;
        _sprite = weaponSO.Sprite;
        OnWeaponChange?.Invoke(weaponSO);
    }

    public virtual bool IsCanUse()
    {        
        if (Time.time - _lastTimeUsed > _timeBetweenUses)        
            return true;
        return false;
    }
    public virtual void Use()
    {        
        if (IsCanUse())
            _lastTimeUsed = Time.time;        
    }
}
