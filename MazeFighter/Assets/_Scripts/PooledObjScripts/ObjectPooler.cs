using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler Instance;

    [System.Serializable]
    public struct Pool
    {
        public string tag;
        public GameObject perfab;
        public int size;
    }

    public List<Pool> Pools;
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    private void Awake()
    {
        if (Instance != null)
            Destroy(Instance);

        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
    }
    private void Start()
    {
        foreach (Pool pool in Pools)
        {
            Queue<GameObject> objectQueue = new Queue<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject newObj = Instantiate(pool.perfab, transform);
                newObj.SetActive(false);
                objectQueue.Enqueue(newObj);
            }
            poolDictionary.Add(pool.tag, objectQueue);
        }
    }
    public GameObject SpawnFromPool(string tag, Vector2 pos, Vector2 rot)
    {
        Debug.Log("trying to shoot");
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("not found");
            return null;
        }
        GameObject newObj = poolDictionary[tag].Dequeue();
        newObj.SetActive(true);
        newObj.transform.position = pos;
        newObj.transform.up = (rot - (Vector2)transform.position).normalized;
        poolDictionary[tag].Enqueue(newObj);

        return newObj;
    }
}
