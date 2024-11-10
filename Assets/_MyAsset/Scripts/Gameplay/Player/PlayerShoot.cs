using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private InputActionProperty _rightActivate;
    [SerializeField] private InputActionProperty _rightSelect;

    void Update()
    {
        var isHoldRightTrigger = _rightActivate.action.ReadValue<float>() > 0;
        var isHoldRightSelect = _rightSelect.action.ReadValue<float>() > 0;

        if (isHoldRightTrigger)
        {
            Fire();
        }
        if (isHoldRightSelect)
        {
            Reload();
        }
    }

    public void Fire()
    {
        if (PlayerManager.Singleton.PlayerWeapon.Gun.gameObject.activeSelf && PlayerManager.Singleton.PlayerWeapon.Gun.Fire())
        {
        }
    }

    public void Reload()
    {
        if (PlayerManager.Singleton.PlayerWeapon.Gun.gameObject.activeSelf && PlayerManager.Singleton.PlayerWeapon.Gun.Reload())
        {
        }
    }
}