using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game Events/Float Event")]
public class GameEventFloat : ScriptableObject
{
    private List<GameEventListenerFloat> listeners = new List<GameEventListenerFloat>();

    public void Raise(float value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(GameEventListenerFloat listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventListenerFloat listener) => listeners.Remove(listener);
}