using UnityEngine;
using UnityEngine.Events;

public class GameEventListenerFloat : MonoBehaviour
{
    [SerializeField] GameEventFloat gameEvent;
    [SerializeField] UnityEvent<float> response;

    void OnEnable() => gameEvent.RegisterListener(this);
    void OnDisable() => gameEvent.UnregisterListener(this);
    public void OnEventRaised(float value) => response.Invoke(value);
}