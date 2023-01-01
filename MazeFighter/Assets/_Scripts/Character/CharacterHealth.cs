using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _startingHealth;
    [SerializeField] Transform _healthbarTransform;

    public event Action<int> OnHealthChange;
    private void Start()
    {
        gameObject.GetComponent<CharacterDamageable>().OnDamage += OnDamage;        
    }

    public void SetHealth(int health)
    {
        _health = health;
        if(_startingHealth == 0)
            _startingHealth = _health;
    }

    private void OnDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)        
            Debug.Log("dead");                
        _healthbarTransform.localScale = new Vector3((float)_health / _startingHealth, _healthbarTransform.localScale.y);
        OnHealthChange?.Invoke(_health);
    }    
}
