using DG.Tweening;
using UnityEngine;

public class NavigationArrow : MonoBehaviour
{
    [SerializeField] private Transform _destination;
    [SerializeField] private Transform _source;
    [SerializeField] private float _distance = 1.2f;

    void FixedUpdate()
    {
        var direction = (_source.position - _destination.position).normalized;
        // this.transform.position = _source.position + direction * _distance;
        this.transform.DOMove(_source.position - direction * _distance, .2f);
        this.transform.LookAt(_destination);
    }
}