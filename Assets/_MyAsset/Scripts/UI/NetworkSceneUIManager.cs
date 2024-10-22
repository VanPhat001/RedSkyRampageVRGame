using TMPro;
using UnityEngine;

public class NetworkSceneUIManager : BaseLayout
{
    public static NetworkSceneUIManager Singleton { get; private set; }

    [SerializeField] private TMP_Text _text;
    public TMP_Text Text => _text;



    void Awake()
    {
        Singleton = this;
    }
}