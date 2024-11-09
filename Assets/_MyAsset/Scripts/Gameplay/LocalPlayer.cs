using UnityEngine;

public class LocalPlayer : MonoBehaviour
{
    public static LocalPlayer Singleton { get; private set; }


    [SerializeField] private Transform _vRHead;
    public Transform VRHead => _vRHead;
    [SerializeField] private Transform _vRLeftHand;
    public Transform VRLeftHand => _vRLeftHand;
    [SerializeField] private Transform _vRRightHand;
    public Transform VRRightHand => _vRRightHand;

    void Awake()
    {
        Singleton = this;
    }
}