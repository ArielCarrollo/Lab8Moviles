using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerPoolObject : MonoBehaviour
{
    [SerializeField] GameEventPoolObject gameEvent;
    [SerializeField] UnityEvent<PoolObject> response;

    void OnEnable() => gameEvent.RegisterListener(this);
    void OnDisable() => gameEvent.UnregisterListener(this);
    public void OnEventRaised(PoolObject poolObject) => response.Invoke(poolObject);
}