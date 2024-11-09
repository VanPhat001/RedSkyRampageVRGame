using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class BaseGun : MonoBehaviour
{
    [SerializeField] private Transform _firePoint;
    public Transform FirePoint => _firePoint;

    public abstract bool Fire();
    public abstract bool Reload();
    public abstract bool CanShoot();
    
    protected virtual void Update() { }

    protected virtual void OnTriggerEnter(Collider other){ }
    protected virtual void OnTriggerStay(Collider other){ }
    protected virtual void OnTriggerExit(Collider other){ }
    
    protected virtual void OnCollisionEnter(Collision other){ }
    protected virtual void OnCollisionStay(Collision other){ }
    protected virtual void OnCollisionExit(Collision other){ }
}