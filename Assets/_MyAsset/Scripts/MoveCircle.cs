using UnityEngine;

public class MoveCircle : MonoBehaviour
{
    [SerializeField] private float _radius = 5f;
    [SerializeField] private float _speed = 1f;
    private float angle = 0f;

    void Update()
    {
        angle += _speed * Time.deltaTime;

        float x = Mathf.Cos(angle) * _radius;
        float z = Mathf.Sin(angle) * _radius;

        transform.position = new Vector3(x, transform.position.y, z);
    }
}
