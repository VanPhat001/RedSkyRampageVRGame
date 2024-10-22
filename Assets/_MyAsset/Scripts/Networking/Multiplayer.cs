using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;

public class Multiplayer : MonoBehaviour
{
    public static Multiplayer Singleton { get; private set; }

    private Lobby _joinedLobby;
    private float _sendHeartBeatTimer = 0;
    private readonly float SEND_HEART_BEAT_TIME = 5f;
    public readonly string RELAY_JOIN_CODE = "RelayJoinCode";
    public bool IsReady { get; private set; } = false;


    void Awake()
    {
        Singleton = this;
    }

    async void Start()
    {
        NetworkManager.Singleton.OnServerStarted += NetworkEventCallback.Singleton.OnServerStarted;

        try
        {
            await SignInAnonymouslyAsync();
            IsReady = true;
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
        }
    }


    void Update()
    {
        SendHeartBeat();
    }


    public async Task<bool> StartServer()
    {
        return await CreateLobbyAsync("server_room");
    }

    public async Task<bool> StartClient()
    {
        return await QuickJoinLobbyAsync();
    }


    public async Task SignInAnonymouslyAsync()
    {
        InitializationOptions options = new InitializationOptions()
            .SetProfile("Profile" + UnityEngine.Random.Range(0, 1000));

        await UnityServices.InitializeAsync(options);
        await AuthenticationService.Instance.SignInAnonymouslyAsync();

        Debug.Log("[DEV] SignInAnonymouslyAsync");
    }


    #region Lobby & Relay
    public async Task<bool> CreateLobbyAsync(string lobbyName, bool isPrivate = false, bool isLocked = false)
    {
        try
        {
            Allocation allocation = await Relay.Instance.CreateAllocationAsync(50);
            var relayJoinCode = await Relay.Instance.GetJoinCodeAsync(allocation.AllocationId);

            CreateLobbyOptions options = new CreateLobbyOptions()
            {
                IsLocked = isLocked,
                IsPrivate = isPrivate,
                Data = new System.Collections.Generic.Dictionary<string, DataObject> {
                    {
                        RELAY_JOIN_CODE,
                        new DataObject(DataObject.VisibilityOptions.Public, relayJoinCode)
                    }
                }
            };

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetHostRelayData(
                allocation.RelayServer.IpV4,
                (ushort)allocation.RelayServer.Port,
                allocation.AllocationIdBytes,
                allocation.Key,
                allocation.ConnectionData
            );

            var lobby = await LobbyService.Instance.CreateLobbyAsync(lobbyName, 50, options);
            _joinedLobby = lobby;

            return true;
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
            return false;
        }
    }

    public async Task<bool> QuickJoinLobbyAsync()
    {
        try
        {
            QuickJoinLobbyOptions options = new QuickJoinLobbyOptions();

            var lobby = await LobbyService.Instance.QuickJoinLobbyAsync(options);
            _joinedLobby = lobby;

            var relayJoinCode = lobby.Data[RELAY_JOIN_CODE].Value;
            var allocation = await Relay.Instance.JoinAllocationAsync(relayJoinCode);

            NetworkManager.Singleton.GetComponent<UnityTransport>().SetClientRelayData(
                allocation.RelayServer.IpV4,
                (ushort)allocation.RelayServer.Port,
                allocation.AllocationIdBytes,
                allocation.Key,
                allocation.ConnectionData,
                allocation.HostConnectionData
            );

            return true;
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
            return false;
        }
    }

    public void SendHeartBeat()
    {
        bool isLobbyOwner = _joinedLobby != null && _joinedLobby.HostId == AuthenticationService.Instance.PlayerId;
        if (!isLobbyOwner)
        {
            return;
        }

        this._sendHeartBeatTimer -= Time.deltaTime;
        if (this._sendHeartBeatTimer <= 0)
        {
            this._sendHeartBeatTimer = SEND_HEART_BEAT_TIME;
            LobbyService.Instance.SendHeartbeatPingAsync(_joinedLobby.Id);
        }
    }
    #endregion
}