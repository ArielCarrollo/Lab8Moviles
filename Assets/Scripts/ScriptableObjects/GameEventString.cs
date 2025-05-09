using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Game Events/String Event")]
public class GameEventString : ScriptableObject
{
    private List<GameEventListenerString> listeners = new List<GameEventListenerString>();

    public void Raise(string value)
    {
        for (int i = listeners.Count - 1; i >= 0; i--)
            listeners[i].OnEventRaised(value);
    }

    public void RegisterListener(GameEventListenerString listener) => listeners.Add(listener);
    public void UnregisterListener(GameEventListenerString listener) => listeners.Remove(listener);
}
