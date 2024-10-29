using Unity.XR.CoreUtils;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    void Start()
    {
        var player = GameObject.FindFirstObjectByType<XROrigin>();
        player.transform.position = this.transform.position;
        player.transform.rotation = this.transform.rotation;

        this.gameObject.SetActive(false);
    }
}
