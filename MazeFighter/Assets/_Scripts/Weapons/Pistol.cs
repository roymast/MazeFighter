using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : IGun
{
    [SerializeField] Bullet bullet;
    [SerializeField] Transform shootingPos;

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

    public void Reload()
    {
        if (Time.time - _lastTimeReload < _loadingTime)
            return;
        if (_magasinesAmount <= 0)
            return;
        if (_bulletsAmount > 10)
            return;
        _lastTimeReload = Time.time;
        _bulletsAmount = _bulletsPerMagasine;
    }

    public void Shoot()
    {
        if (Time.time - _lastTimeShot < _timeBetweenShots)
            return;
        if (Time.time - _lastTimeReload < _loadingTime)
            return;
        if (_bulletsAmount <= 0)
            return;
        bullet.OnObjectSpawn(shootingPos.position, shootingPos.up, _bulletSpeeed * Time.deltaTime);
    }    
}
