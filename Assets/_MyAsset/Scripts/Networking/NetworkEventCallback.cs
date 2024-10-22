using Unity.Netcode;
using UnityEngine;

public class NetworkEventCallback
{
    private static NetworkEventCallback _singleton;
    public static NetworkEventCallback Singleton
    {
        get
        {
            if (_singleton == null)
            {
                _singleton = new();
            }
            return _singleton;
        }
    }

    public void OnServerStarted()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log("[DEV] start server!!!");
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectedCallback;

            SpawnNetworkCommunication();
        }

        void SpawnNetworkCommunication()
        {
            var prefab = PrefabManager.Singleton.GetPrefab(EPrefabNames.NetworkCommunication);
            Object.Instantiate(prefab)
                .GetComponent<NetworkObject>()
                .Spawn();
        }
    }

    public void OnClientConnectedCallback(ulong clientId)
    {
        Debug.Log("[DEV] New Client " + clientId);
    }

    public void OnClientDisconnectedCallback(ulong clientId)
    {
        Debug.Log("[DEV] Client Disconnected " + clientId);
    }
}