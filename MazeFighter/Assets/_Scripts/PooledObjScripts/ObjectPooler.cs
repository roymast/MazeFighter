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
            poolDictionary.Add(pool.tag, objectQueue);
            for (int i = 0; i < pool.size; i++)            
                CreateGameObject(pool);                                 
        }
    }
    private GameObject CreateGameObject(Pool pool)
    {
        GameObject newObj = Instantiate(pool.perfab, transform);
        newObj.SetActive(false);
        poolDictionary[pool.tag].Enqueue(newObj);
        return newObj;
    }
    private int FindPoolByTag(string tagToFind)
    {
        for (int i = 0; i < Pools.Count; i++)
        {
            if (Pools[i].tag == tagToFind)
                return i;
        }
        return -1;
    }
    private GameObject InsertObjectMidRun(string tag)
    {
        Pool pool = Pools[FindPoolByTag(tag)];        
        return CreateGameObject(pool);
    }
    public GameObject SpawnFromPool(string tag)
    {
        Debug.Log("trying to shoot");
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.Log("not found");
            return null;
        }
        GameObject newObj = null;
        poolDictionary[tag].TryDequeue(out newObj);

        if (newObj == null)
            newObj = InsertObjectMidRun(tag);

        newObj.SetActive(true);        
        poolDictionary[tag].Enqueue(newObj);

        return newObj;
    }
}
