using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerInt : MonoBehaviour
{
    [SerializeField] GameEventInt gameEvent;
    [SerializeField] UnityEvent<int> response;

    void OnEnable() => gameEvent.RegisterListener(this);
    void OnDisable() => gameEvent.UnregisterListener(this);
    public void OnEventRaised(int value) => response.Invoke(value);
}