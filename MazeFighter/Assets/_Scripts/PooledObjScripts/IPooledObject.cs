
using UnityEngine;

public interface IPooledObject
{        
    void OnObjectSpawn(Vector2 pos, Vector2 dir, float speed);
}
