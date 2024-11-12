using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectsOnDisable : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectList;

    void OnDisable()
    {
        _objectList.ForEach(item => item.SetActive(true));
    }
}