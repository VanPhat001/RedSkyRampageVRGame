using UnityEngine;

public class WeaponPickupZone : MonoBehaviour
{
    [SerializeField] private LayerMask _detectLayer;

    void OnTriggerEnter(Collider other)
    {
        if (1 << other.gameObject.layer != _detectLayer.value)
        {
            return;
        }

        PlayerManager.Singleton.PlayerWeapon.ActiveWeapon();
        this.gameObject.SetActive(false);
    }
}
