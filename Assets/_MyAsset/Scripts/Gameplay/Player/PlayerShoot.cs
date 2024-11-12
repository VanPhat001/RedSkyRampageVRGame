using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    private PlayerWeapon _playerWeapon;

    void Start()
    {
        _playerWeapon = PlayerManager.Singleton.PlayerWeapon;
    }

    void Update()
    {
        var isRightHandTriggerHold = InputManager.Singleton.IsRightHand_TriggerHold;
        var isRightHandGripHold = InputManager.Singleton.IsRightHand_GripHold;
        var isLeftHandTriggerHold = InputManager.Singleton.IsLeftHand_TriggerHold;
        var isLeftHandGripHold = InputManager.Singleton.IsLeftHand_GripHold;

        if (isRightHandTriggerHold)
        {
            RightFire();
        }
        if (isRightHandGripHold)
        {
            RightReload();
        }
        if (isLeftHandTriggerHold)
        {
            LeftFire();
        }
        if (isLeftHandGripHold)
        {
            LeftReload();
        }
    }

    public void RightFire()
    {
        try
        {
            if (_playerWeapon.HaveWeapon(true) && _playerWeapon.RightGun.Fire())
            {
            }
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
        }
    }

    public void RightReload()
    {
        try
        {
            if (_playerWeapon.HaveWeapon(true) && _playerWeapon.RightGun.Reload())
            {
            }
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
        }
    }

    public void LeftFire()
    {
        try
        {
            if (_playerWeapon.HaveWeapon(false) && _playerWeapon.LeftGun.Fire())
            {
            }
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
        }
    }

    public void LeftReload()
    {
        try
        {
            if (_playerWeapon.HaveWeapon(false) && _playerWeapon.LeftGun.Reload())
            {
            }
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
        }
    }
}