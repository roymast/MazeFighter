using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : IWeapon
{    
    [SerializeField] Bullet _bullet;
    [SerializeField] Transform _bulletsContainer;
    [SerializeField] Transform _shootingPos;
    [SerializeField] Collider2D _shooterCollider;

    [Header("Gun Starting Stats")]
    [SerializeField] int _bulletsPerMagasine;
    [SerializeField] float _reloadingTime;

    [Header("Gun Current Stats")]
    [SerializeField] int _magasinesAmount;
    [SerializeField] int _bulletsAmount;
    [SerializeField] float _lastTimeReload;

    [Header("Bullets Stats")]
    [SerializeField] float _bulletSpeeed;
    [SerializeField] float _bulletDeviation;

    private void Start()
    {
        _shooterCollider = gameObject.GetComponent<Collider2D>();
    }
    private void Update()
    {
        if (_bulletsAmount <= 0 && _magasinesAmount > 0)
            Reload();
    }

    public void Reload()
    {
        Debug.Log("Gun:reload");
        _lastTimeReload = Time.time;
        _bulletsAmount = _bulletsPerMagasine;
        _magasinesAmount--;
    }

    public void Shoot()
    {
        GameObject newBullet = ObjectPooler.Instance.SpawnFromPool(_bullet.tag);
        newBullet.GetComponent<Bullet>().Init(_shootingPos.position, _shootingPos.up, _bulletSpeeed, _shooterCollider);
        //Instantiate(_bullet, _bulletsContainer).Init(_shootingPos.position, _shootingPos.up, _bulletSpeeed, _shooterCollider);        
    }

    public override bool IsCanUse()
    {        
        if (!base.IsCanUse())
            return false;
        if (_bulletsAmount <= 0)
            return false;
        //if (Time.time - _lastTimeReload > _reloadingTime)
        //    return false;
        return true;
    }

    public override void Use()
    {
        if (IsCanUse())
        {
            base.Use();
            _bulletsAmount--;
            Shoot();
        }        
    }
}

