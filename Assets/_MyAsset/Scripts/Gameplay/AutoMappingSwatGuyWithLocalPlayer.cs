using System.Collections;
using UnityEngine;

public class AutoMappingSwatGuyWithLocalPlayer : MonoBehaviour
{
    [SerializeField] private IKTargetFollowVRRig _iKTargetFollowVRRig;

    void Start()
    {
        StartCoroutine(MappingCoroutine());
    }

    IEnumerator MappingCoroutine()
    {
        yield return new WaitUntil(() => LocalPlayer.Singleton != null);

        _iKTargetFollowVRRig.head.vrTarget = LocalPlayer.Singleton.VRHead;
        _iKTargetFollowVRRig.leftHand.vrTarget = LocalPlayer.Singleton.VRLeftHand;
        _iKTargetFollowVRRig.rightHand.vrTarget = LocalPlayer.Singleton.VRRightHand;

        this.gameObject.SetActive(false);
    }
}