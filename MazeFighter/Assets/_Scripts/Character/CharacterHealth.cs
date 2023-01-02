using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterHealth : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _startingHealth;
    [SerializeField] Transform _healthbarTransform;
    [SerializeField] CharacterDamageable characterDamageable;

    public event Action<int> OnHealthChange;
    public static event Action<GameObject> OnCharacterDestroyed;
    private void Start()
    {
        characterDamageable.OnDamage += OnDamage;        
    }

    public void SetHealth(int health)
    {
        _health = health;
        if(_startingHealth == 0)
            _startingHealth = health;
    }

    private void OnDamage(int damage)
    {
        _health -= damage;
        Debug.Log("i got shot");
        if (_health <= 0)
        {
            Debug.Log("dead");
            _health = 0;
            OnCharacterDestroyed?.Invoke(transform.root.gameObject);
            Destroy(transform.root.gameObject);
        }
        _healthbarTransform.localScale = new Vector3((float)_health / _startingHealth, _healthbarTransform.localScale.y);        
        OnHealthChange?.Invoke(_health);
    }    
}
