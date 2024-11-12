using System;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] private WeaponContainer _leftHandWeaponContainer;
    [SerializeField] private WeaponContainer _rightHandWeaponContainer;

    public BaseGun LeftGun => _leftHandWeaponContainer.Gun;
    public BaseGun RightGun => _rightHandWeaponContainer.Gun;


    public bool HaveWeapon(bool isRightHand)
    {
        return (isRightHand ? RightGun : LeftGun) != null;
    }

    public void PickWeapon(bool isRightHand, WeaponSO weaponSO)
    {
        var weaponContainer = isRightHand ? _rightHandWeaponContainer : _leftHandWeaponContainer;

        ThrowWeapon(isRightHand);

        GameObject weaponPrefab;
        weaponPrefab = weaponSO.WeaponType switch
        {
            EWeaponTypes.Gun => weaponSO.Prefab,
            EWeaponTypes.MissionItem => weaponSO.Prefab,
            _ => null
        };

        if (weaponPrefab == null)
        {
            return;
        }

        var weapon = Instantiate(weaponPrefab);
        weapon.transform.SetParent(weaponContainer.Container);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;

        weaponContainer.Gun = weapon.GetComponent<BaseGun>();
    }

    public void ThrowWeapon(bool isRightHand)
    {
        var weaponContainer = isRightHand ? _rightHandWeaponContainer : _leftHandWeaponContainer;
        ThrowWeapon(weaponContainer);
    }

    public void ThrowWeapon(WeaponContainer weaponContainer)
    {
        if (weaponContainer.Gun == null)
        {
            return;
        }

        // !!!TODO: change bellow code to throw weapon instead of destroy it =D
        weaponContainer.Gun = null;
        foreach (Transform child in weaponContainer.Container)
        {
            Destroy(child.gameObject);
        }
    }
}


[Serializable]
public class WeaponContainer
{
    public Transform Container;
    [HideInInspector] public BaseGun Gun;
}