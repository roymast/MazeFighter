using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour, IPooledObject
{
    [SerializeField] Rigidbody2D _rb;    

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        BulletHit(damageable);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {        
        IDamageable damageable = collision.gameObject.GetComponent<IDamageable>();
        BulletHit(damageable);
    }

    private void BulletHit(IDamageable damageable)
    {
        Destroy(gameObject);
        if (damageable != null)
            damageable.Damage();
    }

    public void OnObjectSpawn(Vector2 pos, Vector2 dir, float speed)
    {        
        transform.position = pos;
        _rb.AddForce(dir*speed, ForceMode2D.Impulse);
    }
    public void Init(Vector2 pos, Vector2 dir, float speed)
    {
        transform.position = pos;
        transform.up = dir;
        _rb.AddForce(dir * speed, ForceMode2D.Impulse);
    }
}
