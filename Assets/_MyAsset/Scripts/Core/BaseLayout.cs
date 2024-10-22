using UnityEngine;

public abstract class BaseLayout : MonoBehaviour
{
    [SerializeField] private GameObject _layout;
    public GameObject Layout => _layout;

    public void Open()
    {
        _layout.SetActive(true);
    }

    public void Close()
    {
        _layout.SetActive(false);
    }

}