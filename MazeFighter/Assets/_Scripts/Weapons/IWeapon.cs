using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon : MonoBehaviour
{
    [Header("Weapon Starting Stats")]
    [SerializeField] float _timeBetweenUses;        
    [SerializeField] float _lastTimeUsed;       

    private void Start()
    {
        _lastTimeUsed = Time.time;
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
