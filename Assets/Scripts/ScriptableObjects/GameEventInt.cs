using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game Events/Int Event")]
public class GameEventInt : ScriptableObject
{
    private List<GameEventListenerInt> listeners = new List<GameEventListenerInt>();

    public void Raise(int value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(GameEventListenerInt listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventListenerInt listener) => listeners.Remove(listener);
}