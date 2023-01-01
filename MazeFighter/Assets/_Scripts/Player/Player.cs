using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] IWeapon _currentWeapon;
    [SerializeField] PlayerController _playerController;

    [Header("stats")]
    public int hp;
    public int speed;

    private void Start()
    {
        _playerController.Speed = speed;
        _currentWeapon = gameObject.GetComponent<IWeapon>();
        Debug.Log(_currentWeapon);
    }

    public void UseWeapon()
    {
        Debug.Log("Player:UseWeapon()");
        _currentWeapon.Use();
    }

    public void PlayerMove(Vector2 movement, Vector2 rotation)
    {
        _playerController.Movement = movement;
        _playerController.PosToLook = rotation;
    }
}
