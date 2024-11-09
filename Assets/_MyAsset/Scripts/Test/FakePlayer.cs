using UnityEngine;


// [RequireComponent(typeof(CapsuleCollider))]
[RequireComponent(typeof(Rigidbody))]
public class FakePlayer : MonoBehaviour
{
    [SerializeField] private float _speed = 4f;
    private Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        var move = new Vector3(
            Input.GetAxis("Horizontal"),
            0,
            Input.GetAxis("Vertical")
        );

        var hor = Input.GetAxis("Mouse X");
        // var ver = Input.GetAxis("Mouse Y");

        this.transform.Translate(move * Time.deltaTime * _speed);
        this.transform.Rotate(new Vector3(0, hor, 0));
    }
}