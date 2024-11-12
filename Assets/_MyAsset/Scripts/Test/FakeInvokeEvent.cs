using UnityEngine;
using UnityEngine.Events;

public class FakeInvokeEvent : MonoBehaviour
{
    public UnityEvent events;

    void Start()
    {
        events?.Invoke();
    }

    public void Log()
    {
        Debug.Log("xin chao the gioi");
    }
}