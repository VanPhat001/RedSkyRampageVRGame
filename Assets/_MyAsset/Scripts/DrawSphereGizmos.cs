using UnityEngine;

public class DrawSphereGizmos : MonoBehaviour
{
    [SerializeField] private Vector3 _center;
    [SerializeField] private float _radius;
    [SerializeField] private Color _color = Color.magenta;

    void OnDrawGizmos()
    {
        Gizmos.color = _color;
        Gizmos.DrawSphere(_center, _radius);
    }
}