using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectsWhenDisable : MonoBehaviour
{
    [SerializeField] private List<GameObject> _goList;

    void OnDisable()
    {
        _goList.ForEach(item => item.SetActive(true));
    }
}