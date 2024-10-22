using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

[CreateAssetMenu(menuName = "RedSkyRampageVRGame/PrefabDictionarySO")]
public class PrefabDictionarySO : ScriptableObject
{
    [SerializeField] private SerializedDictionary<EPrefabNames, GameObject> _prefabDictionary;
    public Dictionary<EPrefabNames, GameObject> PrefabDict => _prefabDictionary;
}

public enum EPrefabNames
{
    NetworkCommunication
}