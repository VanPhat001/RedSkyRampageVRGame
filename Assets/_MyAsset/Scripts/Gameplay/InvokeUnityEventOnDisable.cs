using UnityEngine;
using UnityEngine.Events;

public class InvokeUnityEventOnDisable : MonoBehaviour
{
    [SerializeField] private UnityEvent _events;

    void OnDisable()
    {
        _events?.Invoke();
    }
}