using UnityEngine;

[CreateAssetMenu(menuName = "RedSkyRampageVRGame/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private EWeaponTypes _weaponType;
    public EWeaponTypes WeaponType => _weaponType;

    [SerializeField] private GameObject _prefab;
    public GameObject Prefab => _prefab;

    // [SerializeField] private GameObject _otherWeaponPrefab;
    // public GameObject OtherWeaponPrefab => _otherWeaponPrefab;
}

public enum EWeaponTypes
{
    Gun,
    MissionItem
}