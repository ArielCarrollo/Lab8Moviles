using UnityEngine;
using System.Collections.Generic;

public class StaticObjectPooling : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] PoolObject prefab;
    [SerializeField] int initialSize = 10;

    [Header("Events")]
    [SerializeField] GameEventInt onPoolInitialized;
    [SerializeField] GameEventPoolObject onObjectTaken;
    [SerializeField] GameEventPoolObject onObjectReturned;

    private Queue<PoolObject> pool = new Queue<PoolObject>();

    void Start() => InitializePool();

    private void InitializePool()
    {
        for (int i = 0; i < initialSize; i++)
        {
            PoolObject obj = Instantiate(prefab, transform);
            obj.Despawn();
            pool.Enqueue(obj);
        }
        onPoolInitialized?.Raise(initialSize);
    }

    public PoolObject GetObject()
    {
        if (pool.Count == 0) return null;

        PoolObject obj = pool.Dequeue();
        obj.Spawn();
        onObjectTaken?.Raise(obj);
        return obj;
    }

    public void ReturnObject(PoolObject obj)
    {
        obj.Despawn();
        pool.Enqueue(obj);
        onObjectReturned?.Raise(obj);
    }
}