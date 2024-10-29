using UnityEngine;
using UnityEngine.UI;

public class QuitLayout : BaseLayout
{
    [SerializeField] private Button _zombieDetailButton;
    [SerializeField] private Button _quitButton;

    void Start()
    {
        _zombieDetailButton.onClick.AddListener(() => {
            _zombieDetailButton.interactable = false;

            Debug.Log("_zombieDetailButton clicked");
            Loader.LoadSceneAdditive(ESceneNames.ZombieDetailScene);
            
            _zombieDetailButton.interactable = true;
        });

        _quitButton.onClick.AddListener(() =>
        {
            ClientSceneUIManager.Singleton.ConfirmLayout.OpenLayout();
        });
    }
}