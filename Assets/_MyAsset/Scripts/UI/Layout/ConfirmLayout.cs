using UnityEngine;
using UnityEngine.UI;

public class ConfirmLayout : BaseLayout
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    void Start()
    {
        _yesButton.onClick.AddListener(() =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#endif
            Application.Quit();
        });

        _noButton.onClick.AddListener(() =>
        {
            CloseLayout();
        });
    }
}