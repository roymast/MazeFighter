using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Gun _gun;
    [SerializeField] PlayerController _playerController;

    [Header("stats")]
    public int hp;
    public int speed;

    private void Start()
    {
        _playerController.Speed = speed;
        _gun = gameObject.GetComponent<Gun>();
        Debug.Log(_gun);
    }

    public void PlayerShoot()
    {
        Debug.Log("PlayerShoot");
        _gun.Shoot();
    }

    public void PlayerMove(Vector2 movement, Vector2 rotation)
    {
        _playerController.Movement = movement;
        _playerController.PosToLook = rotation;
    }
}
