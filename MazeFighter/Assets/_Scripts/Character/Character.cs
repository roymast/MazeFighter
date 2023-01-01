using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] WeaponSO[] _weaponSOList;
    [SerializeField] int _currentWeaponSO;
    [SerializeField] IWeapon _currentWeapon;
    [SerializeField] CharacterMover _playerController;
    [SerializeField] CharacterHealth _characterHealth;

    [Header("stats")]
    public int hp;
    public int speed;

    private void Start()
    {
        _playerController.Speed = speed;
        _currentWeapon = gameObject.GetComponent<IWeapon>();
        _characterHealth.SetHealth(hp);
    }

    public void UseWeapon()
    {        
        _currentWeapon.Use();
    }

    public void NextWeapon()
    {
        _currentWeaponSO++;
        if (_currentWeaponSO >= _weaponSOList.Length)
            _currentWeaponSO = 0;
        _currentWeapon.ChangeWeapon(_weaponSOList[_currentWeaponSO]);
    }

    public void PlayerMove(Vector2 movement, Vector2 rotation)
    {
        _playerController.Movement = movement;
        _playerController.PosToLook = rotation;
    }
}
