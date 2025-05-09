using UnityEngine;

public class PoolObject : MonoBehaviour
{
    [Header("Pool Events")]
    [SerializeField] GameEventPoolObject onSpawnEvent;
    [SerializeField] GameEventPoolObject onDespawnEvent;

    public void Spawn()
    {
        gameObject.SetActive(true);
        onSpawnEvent?.Raise(this);
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
        onDespawnEvent?.Raise(this);
    }
}