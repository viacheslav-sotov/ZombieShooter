//by Richard and Viacheslav
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool Instance; // Singleton 

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    public List<Pool> pools;
    private Dictionary<string, Queue<GameObject>> poolDictionary;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Start()
    {
        poolDictionary = new Dictionary<string, Queue<GameObject>>();

        foreach (Pool pool in pools)
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
            }

            poolDictionary[pool.tag] = objectPool;
        }
    }

    public GameObject GetObject(string tag)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Pool with tag '{tag}' does not exist!");
            return null;
        }

        if (poolDictionary[tag].Count == 0)
        {
            Debug.LogWarning($"Pool '{tag}' is empty — consider increasing size.");
            return null;
        }

        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        return objectToSpawn;
    }

    public void ReturnObject(string tag, GameObject obj)
    {
        if (!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning($"Trying to return object to unknown pool '{tag}'.");
            Destroy(obj);
            return;
        }

        obj.SetActive(false);
        poolDictionary[tag].Enqueue(obj);
    }
}
