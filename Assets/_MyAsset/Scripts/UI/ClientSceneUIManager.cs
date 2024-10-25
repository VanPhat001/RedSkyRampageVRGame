using UnityEngine;

public class ClientSceneUIManager : MonoBehaviour
{
    public static ClientSceneUIManager Singleton { get; private set; }

    [SerializeField] private LoginLayout _loginLayout;
    public LoginLayout LoginLayout => _loginLayout;

    [SerializeField] private MainMenuLayout _mainMenuLayout;
    public MainMenuLayout MainMenuLayout => _mainMenuLayout;

    [SerializeField] private QuitLayout _quitLayout;
    public QuitLayout QuitLayout => _quitLayout;

    [SerializeField] private ConfirmLayout _confirmLayout;
    public ConfirmLayout ConfirmLayout => _confirmLayout;
    
    [SerializeField] private LockLayout _lockLayout;
    public LockLayout LockLayout => _lockLayout;

    [SerializeField] private WarningLayout _warningLayout;
    public WarningLayout WarningLayout => _warningLayout;

    [SerializeField] private LogoLayout _logoLayout;
    public LogoLayout LogoLayout => _logoLayout;



    void Awake()
    {
        Singleton = this;
    }
}