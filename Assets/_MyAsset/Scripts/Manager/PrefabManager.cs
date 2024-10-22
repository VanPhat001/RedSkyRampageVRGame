using UnityEngine;

public class PrefabManager : MonoBehaviour
{
    public static PrefabManager Singleton { get; private set; }
    [SerializeField] private PrefabDictionarySO _prefabDictionarySO;


    void Awake()
    {
        Singleton = this;
    }

    public GameObject GetPrefab(EPrefabNames prefabName)
    {
        return _prefabDictionarySO.PrefabDict[prefabName];
    }

    // public GameObject this[EPrefabNames prefabName]
    // {
    //     get => _prefabDictionarySO.PrefabDict[prefabName];
    // }
}
