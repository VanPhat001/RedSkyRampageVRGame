using UnityEngine;

public class DrawSphereGizmos : MonoBehaviour
{
    public Color Color;
    public float Radius;

    void OnDrawGizmos()
    {
        Gizmos.color = Color;
        Gizmos.DrawSphere(this.transform.position, Radius);
    }
}