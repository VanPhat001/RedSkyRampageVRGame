using UnityEngine;

public class WeaponPickupZone : MonoBehaviour
{
    [SerializeField] private LayerMask _detectLayer;
    [SerializeField] private WeaponSO _weaponSO;

    void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer != _detectLayer.value)
        {
            return;
        }

        // PlayerManager.Singleton.PlayerWeapon.ActiveWeapon();
        PlayerManager.Singleton.PlayerWeapon.PickWeapon(_weaponSO);
        this.gameObject.SetActive(false);
    }
}
