using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // [SerializeField] private Transform _weaponPoint;
    [SerializeField] private Transform _gunContainer;
    [SerializeField] private BaseGun _gun;
    public BaseGun Gun { get => _gun; private set => _gun = value; }

    public bool HaveWeapon()
    {
        return Gun != null;
    }

    public void ActiveWeapon()
    {
        Gun.gameObject.SetActive(true);
    }

    public void PickWeapon(WeaponSO weaponSO)
    {
        ThrowWeapon();

        GameObject weaponPrefab;
        weaponPrefab = weaponSO.WeaponType switch
        {
            EWeaponTypes.Gun => weaponSO.GunPrefab,
            _ => null
        };

        if (weaponPrefab == null)
        {
            return;
        }

        var weapon = Instantiate(weaponPrefab);
        weapon.transform.SetParent(_gunContainer);
        weapon.transform.localPosition = Vector3.zero;
        weapon.transform.localRotation = Quaternion.identity;

        Gun = weapon.GetComponent<BaseGun>();
    }

    public void ThrowWeapon()
    {
        if (Gun == null)
        {
            return;
        }

        // !!!TODO: change bellow code to throw weapon instead of destroy it =D
        Gun = null;
        foreach (Transform child in _gunContainer)
        {
            Destroy(child.gameObject);
        }
    }

    // public void PickGun(BaseGun gun)
    // {
    //     _gun = gun;
    //     Gun.transform.position = _weaponPoint.position;
    //     Gun.transform.rotation = _weaponPoint.rotation;
    // }
}