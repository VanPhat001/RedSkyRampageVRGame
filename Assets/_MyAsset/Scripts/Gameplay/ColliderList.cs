using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ColliderList
{
    [SerializeField] private List<Collider> _colliders;

    public void SetEnableAll(bool isEnable)
    {
        _colliders.ForEach(item => item.enabled = isEnable);
    }

    public void EnableAll()
    {
        SetEnableAll(true);
    }

    public void DisableAll()
    {
        SetEnableAll(false);
    }
}