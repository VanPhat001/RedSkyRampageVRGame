using UnityEngine;
using UnityEngine.Events;

public class InvokeUnityEventOnEnable : MonoBehaviour
{
    [SerializeField] private UnityEvent _events;

    private void OnEnable() {
        _events?.Invoke();
    }
}