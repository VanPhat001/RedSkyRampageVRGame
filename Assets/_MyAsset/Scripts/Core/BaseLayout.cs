using UnityEngine;

public abstract class BaseLayout : MonoBehaviour
{
    [SerializeField] private GameObject _layout;
    public GameObject Layout => _layout;

    public virtual void OpenLayout()
    {
        _layout.SetActive(true);
    }

    public virtual void CloseLayout()
    {
        _layout.SetActive(false);
    }

    public void SetActiveLayout(bool active)
    {
        _layout.SetActive(active);
    }
}