using UnityEngine;

[CreateAssetMenu(menuName = "RedSkyRampageVRGame/WeaponSO")]
public class WeaponSO : ScriptableObject
{
    [SerializeField] private EWeaponTypes _weaponType;
    public EWeaponTypes WeaponType => _weaponType;

    [SerializeField] private GameObject _gunPrefab;
    public GameObject GunPrefab => _gunPrefab;

    // [SerializeField] private GameObject _otherWeaponPrefab;
    // public GameObject OtherWeaponPrefab => _otherWeaponPrefab;
}

public enum EWeaponTypes
{
    Gun
}