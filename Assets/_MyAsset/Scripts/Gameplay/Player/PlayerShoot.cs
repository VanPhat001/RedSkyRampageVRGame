using System;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public void Fire()
    {
        if (PlayerManager.Singleton.PlayerWeapon.Gun.Fire())
        {
        }
    }

    public void Reload()
    {
        if (PlayerManager.Singleton.PlayerWeapon.Gun.Reload())
        {
        }
    }
}