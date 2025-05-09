using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerString : MonoBehaviour
{
    [SerializeField] GameEventString gameEvent;
    [SerializeField] UnityEvent<string> response;

    void OnEnable() => gameEvent.RegisterListener(this);
    void OnDisable() => gameEvent.UnregisterListener(this);
    public void OnEventRaised(string value) => response.Invoke(value);
}