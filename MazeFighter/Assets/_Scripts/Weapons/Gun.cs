using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{    
    [SerializeField] Bullet _bullet;
    [SerializeField] Transform _bulletsContainer;
    [SerializeField] Transform _shootingPos;

    [Header("Gun Starting Stats")]
    [SerializeField] int _bulletsPerMagasine;
    [SerializeField] float _timeBetweenShots;
    [SerializeField] float _loadingTime;

    [Header("Gun Current Stats")]
    [SerializeField] int _magasinesAmount;
    [SerializeField] int _bulletsAmount;
    [SerializeField] float _lastTimeShot;
    [SerializeField] float _lastTimeReload;

    [Header("Bullets Stats")]
    [SerializeField] float _bulletSpeeed;
    [SerializeField] float _bulletDeviation;

    float startTime;
    private void Start()
    {
        startTime = Time.time;
    }

    private void Update()
    {
        if (_bulletsAmount <= 0 && _magasinesAmount > 0)
            Reload();

    }

    public void Reload()
    { 
        _lastTimeReload = Time.time;
        _bulletsAmount = _bulletsPerMagasine;
    }

    public void Shoot()
    {
        Debug.Log("Gun:Shoot");
        if (Time.time - _lastTimeShot < _timeBetweenShots)
            return;
        //if (Time.time - _lastTimeReload < _loadingTime)
        //    return;
        if (_bulletsAmount <= 0)
            return;
        _lastTimeShot = Time.time;
        Instantiate(_bullet, _bulletsContainer).Init(_shootingPos.position, _shootingPos.up, _bulletSpeeed);        
    }
}

