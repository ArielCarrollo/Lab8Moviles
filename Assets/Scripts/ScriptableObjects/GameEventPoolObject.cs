using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game Events/PoolObject Event")]
public class GameEventPoolObject : ScriptableObject
{
    private List<GameEventListenerPoolObject> listeners = new List<GameEventListenerPoolObject>();

    public void Raise(PoolObject poolObject)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(poolObject);
    }

    public void RegisterListener(GameEventListenerPoolObject listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventListenerPoolObject listener) => listeners.Remove(listener);
}