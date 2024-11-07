using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class MapLevelSceneUIManager : BaseLayout
{
    public static MapLevelSceneUIManager Singleton { get; private set; }

    #region Test
#if true
    [SerializeField] private Button _backToHomeButton;


    void Start()
    {
        _backToHomeButton.onClick.AddListener(() =>
        {
            // teleport player to `client scene plane`
            var player = GameObject.FindFirstObjectByType<XROrigin>();
            Loader.UnLoadAdditiveScene(ESceneNames.MapLevelScene, player.GetComponent<MonoBehaviour>(), () =>
            {
                player.transform.position = Vector3.forward * -4;
                player.transform.rotation = Quaternion.identity;
            });
        });
    }
#endif
    #endregion


    [SerializeField] private MapLevelLayout _mapLevelLayout;
    public MapLevelLayout MapLevelLayout => _mapLevelLayout;
    
    [SerializeField] private LevelInfoLayout _levelInfoLayout;
    public LevelInfoLayout LevelInfoLayout => _levelInfoLayout;

    void Awake()
    {
        Singleton = this;
    }
}