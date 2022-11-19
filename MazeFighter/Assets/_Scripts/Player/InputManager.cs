using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Player _player;
    Vector2 _rotation;
    Vector2 _movement;

    const string Horizontal = "Horizontal";
    const string Vertical   = "Vertical";

    Camera mainCamera;
    private void Start()
    {
        mainCamera = Camera.main;
    }
    // Update is called once per frame
    void Update()
    {
        _movement = new Vector2(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
        _rotation =  mainCamera.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButtonDown(0))
            _player.PlayerShoot();
        _player.PlayerMove(_movement, _rotation);
    }
}