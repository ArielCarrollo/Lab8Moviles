using UnityEngine;
using System.Collections.Generic;

public class DinamicObjectPooling : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] PoolObject prefab;
    [SerializeField] int initialSize = 5;
    [SerializeField] int growthAmount = 3;

    [Header("Events")]
    [SerializeField] GameEventInt onPoolGrew;
    [SerializeField] GameEventPoolObject onObjectTaken;
    [SerializeField] GameEventPoolObject onObjectReturned;

    private Queue<PoolObject> pool = new Queue<PoolObject>();

    void Start() => GrowPool(initialSize);

    public PoolObject GetObject()
    {
        if (pool.Count == 0) GrowPool(growthAmount);

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

    private void GrowPool(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            PoolObject obj = Instantiate(prefab, transform);
            obj.Despawn();
            pool.Enqueue(obj);
        }
        onPoolGrew?.Raise(amount);
    }
}