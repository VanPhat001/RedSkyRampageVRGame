using Unity.Netcode;
using UnityEngine;
using UnityEngine.Networking;

public class NetworkCommunication : NetworkBehaviour
{
    public static NetworkCommunication Singleton { get; private set; }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        Singleton = this;
    }
}
