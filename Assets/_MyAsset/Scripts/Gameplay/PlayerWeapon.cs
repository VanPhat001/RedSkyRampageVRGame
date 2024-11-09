using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    // [SerializeField] private Transform _weaponPoint;
    [SerializeField] private Pistol _gun;
    public Pistol Gun => _gun;

    public void ActiveWeapon()
    {
        Gun.gameObject.SetActive(true);
    }

    // public void PickGun(BaseGun gun)
    // {
    //     _gun = gun;
    //     Gun.transform.position = _weaponPoint.position;
    //     Gun.transform.rotation = _weaponPoint.rotation;
    // }
}