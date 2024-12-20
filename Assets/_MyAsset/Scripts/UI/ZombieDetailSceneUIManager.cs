using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class ZombieDetailSceneUIManager : BaseLayout
{
    public static ZombieDetailSceneUIManager Singleton { get; private set; }
    [SerializeField] private Button _backToHomeButton;


    void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        _backToHomeButton.onClick.AddListener(() =>
        {
            // teleport player to `client scene plane`
            var player = GameObject.FindFirstObjectByType<XROrigin>();
            Loader.UnLoadAdditiveScene(ESceneNames.ZombieDetailScene, player.GetComponent<MonoBehaviour>(), () =>
            {
                player.transform.position = Vector3.forward * -4;
                player.transform.rotation = Quaternion.identity;
            });
        });
    }
}