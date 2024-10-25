using UnityEngine;
using UnityEngine.UI;

public class QuitLayout : BaseLayout
{
    [SerializeField] private Button _zombieDetailButton;
    [SerializeField] private Button _quitButton;

    void Start()
    {
        _zombieDetailButton.onClick.AddListener(() => {
            Debug.Log("_zombieDetailButton clicked");
        });

        _quitButton.onClick.AddListener(() =>
        {
            ClientSceneUIManager.Singleton.ConfirmLayout.OpenLayout();
        });
    }
}