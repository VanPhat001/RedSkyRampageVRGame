using NUnit.Framework.Constraints;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // private bool _isDeath = false;
    private float _hp = 100;

    public bool IsDeath()
    {
        return _hp <= 0;
    }

    public float GetHP()
    {
        return _hp;
    }

    public void SetHP(float hp)
    {
        if (_hp < 0 || hp > 100)
        {
            Debug.Log("[DEV, ERROR] hp must be between 0 and 100!!!");
            return;
        }
        
        _hp = hp;
    }
}