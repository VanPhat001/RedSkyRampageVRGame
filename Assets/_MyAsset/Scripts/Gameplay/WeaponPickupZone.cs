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

        var leftHand = other.GetComponent<LeftHand>();
        var rightHand = other.GetComponent<RightHand>();
        if (leftHand == null && rightHand == null)
        {
            return;
        }

        // PlayerManager.Singleton.PlayerWeapon.ActiveWeapon();
        // Debug.Log("trigger " + other.name + " " + other.attachedRigidbody.name);
        PlayerManager.Singleton.PlayerWeapon.PickWeapon(rightHand != null, _weaponSO);
        this.gameObject.SetActive(false);
    }
}
