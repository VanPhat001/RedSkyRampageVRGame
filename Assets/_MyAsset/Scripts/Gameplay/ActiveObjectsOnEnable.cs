using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectsOnEnable : MonoBehaviour
{
    [SerializeField] private List<GameObject> _objectList;

    void OnEnable()
    {
        _objectList.ForEach(item => item.SetActive(true));
    }    
}