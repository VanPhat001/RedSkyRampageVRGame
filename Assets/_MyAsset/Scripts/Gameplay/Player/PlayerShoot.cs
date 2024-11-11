using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    // [SerializeField] private InputActionProperty _rightActivate;
    // [SerializeField] private InputActionProperty _rightSelect;
    private PlayerWeapon _playerWeapon;

    void Start()
    {
        _playerWeapon = PlayerManager.Singleton.PlayerWeapon;
    }

    void Update()
    {
        // var isHoldRightTrigger = _rightActivate.action.ReadValue<float>() > 0;
        // var isHoldRightSelect = _rightSelect.action.ReadValue<float>() > 0;
        var isRightHandTriggerHold = InputManager.Singleton.IsRightHand_TriggerHold;
        var isRightHandGripHold = InputManager.Singleton.IsRightHand_GripHold;

        if (isRightHandTriggerHold)
        {
            Fire();
        }
        if (isRightHandGripHold)
        {
            Reload();
        }
    }

    public void Fire()
    {
        if (_playerWeapon.HaveWeapon() && _playerWeapon.Gun.Fire())
        {
        }
    }

    public void Reload()
    {
        if (_playerWeapon.HaveWeapon() && _playerWeapon.Gun.Reload())
        {
        }
    }
}