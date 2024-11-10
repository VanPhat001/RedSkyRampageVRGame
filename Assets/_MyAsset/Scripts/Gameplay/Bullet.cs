using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;

    private Vector3? _oldPos = null;


    public void Init(Vector3 pos, Quaternion rot)
    {
        _oldPos = null;
        this.transform.position = pos;
        this.transform.rotation = rot;
        _rigidbody.linearVelocity = this.transform.forward.normalized * _speed;

    }

    // void Start()
    // {
    //     Init(this.transform.position, this.transform.rotation);
    // }

    void Update()
    {
        HandleCollision();
        _oldPos = this.transform.position;
    }

    void HandleCollision()
    {
        if (_oldPos == null)
        {
            return;
        }

        var direction = this.transform.position - _oldPos.Value;
        if (Physics.Raycast(_oldPos.Value, direction, out var hit, direction.magnitude))
        {
            if (hit.transform.gameObject.layer == this.gameObject.layer)
            {
                return;
            }

            OnCottactWithObject(hit);
        }
    }

    void OnCottactWithObject(RaycastHit hit)
    {
        Debug.Log("[DEV] contact" + hit.transform.gameObject.name);
        hit.transform.GetComponent<IDamageable>()?.GetHit(_damage);
        Destroy(this.gameObject);
    }
}