using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector3 Movement;
    public Vector2 PosToLook;

    [HideInInspector]
    public float Speed;
    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + Movement, Speed * Time.deltaTime);        

        // get direction you want to point at
        Vector2 direction = (PosToLook - (Vector2)transform.position).normalized;

        // set vector of transform directly
        transform.up = direction;        
    }
}
