using Unity.Netcode;
using UnityEngine;

public class NetworkEventFunctions : MonoBehaviour
{
    [SerializeField] private GameObject _networkCommunicationPrefab;

    void OnValidate()
    {
#if UNITY_EDITOR
        var valid = _networkCommunicationPrefab && _networkCommunicationPrefab.GetComponent<NetworkObject>();
        if (!valid)
        {
            Debug.LogWarning(nameof(_networkCommunicationPrefab) + " is not valid");
        }
#endif
    }

    public void OnServerStarted()
    {
        if (NetworkManager.Singleton.IsServer)
        {
            Debug.Log("START SERVER!!!");
            NetworkManager.Singleton.OnClientConnectedCallback += OnClientConnectedCallback;
            NetworkManager.Singleton.OnClientDisconnectCallback += OnClientDisconnectedCallback;

            SpawnNetworkCommunication();
        }

        void SpawnNetworkCommunication()
        {
            Instantiate(_networkCommunicationPrefab)
                .GetComponent<NetworkObject>()
                .Spawn();
        }
    }

    public void OnClientConnectedCallback(ulong clientId)
    {
        Debug.Log("New Client " + clientId);
    }

    public void OnClientDisconnectedCallback(ulong clientId)
    {
        Debug.Log("Client Disconnected " + clientId);
    }
}