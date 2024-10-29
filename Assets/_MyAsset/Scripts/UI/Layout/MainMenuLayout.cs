using UnityEngine;
using UnityEngine.UI;

public class MainMenuLayout : BaseLayout
{
    [SerializeField] private Button _multiplayerButton;
    [SerializeField] private Button _singleplayerButton;
    [SerializeField] private Button _changeSkinButton;


    void Start()
    {
        _multiplayerButton.onClick.AddListener(() => {
            Debug.Log("_multiplayerButton clicked");
        });
        
        _singleplayerButton.onClick.AddListener(() => {
            _singleplayerButton.interactable = false;

            Debug.Log("_singleplayerButton clicked");
            Loader.LoadSceneAdditive(ESceneNames.MapLevelScene);

            _singleplayerButton.interactable = true;
        });
        
        _changeSkinButton.onClick.AddListener(() => {
            Debug.Log("_changeSkinButton clicked");
        });
    }
}