using System.Collections.Generic;
using DemoObserver;
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


    private ClientRpcParams CreateClientRpcParams(ulong clientSenderId)
    {
        return new ClientRpcParams
        {
            Send = new ClientRpcSendParams
            {
                TargetClientIds = new List<ulong> {
                    clientSenderId
                }
            }
        };
    }

    private ClientRpcParams CreateClientRpcParams(List<ulong> clientSenderIds)
    {
        return new ClientRpcParams
        {
            Send = new ClientRpcSendParams
            {
                TargetClientIds = clientSenderIds
            }
        };
    }



    [ServerRpc(RequireOwnership = false)]
    public void AuthPlayerByUsernameAndPasswordServerRpc(string username, string password, ServerRpcParams rpcParams = default)
    {
        var clientSenderId = rpcParams.Receive.SenderClientId;
        var toClientRpcParams = CreateClientRpcParams(clientSenderId);

        var player = PlayerService.Singleton.FindPlayerByUsername(username);

        if (player == null)
        {
            AuthPlayerByUsernameAndPasswordClientRpc(
                false,
                -1,
                toClientRpcParams
            );
            return;
        }

        if (!player.Password.Equals(password))
        {
            AuthPlayerByUsernameAndPasswordClientRpc(
                false,
                -1,
                toClientRpcParams
            );
            return;
        }

        AuthPlayerByUsernameAndPasswordClientRpc(
            true,
            player.Id,
            toClientRpcParams
        );
    }

    [ClientRpc]
    public void AuthPlayerByUsernameAndPasswordClientRpc(bool isFound, int dbPlayerId, ClientRpcParams rpcParams = default)
    {
        this.PostEvent(
            EEventIDs.ServerResponseAuthResult,
            new AuthPlayerParams(isFound, dbPlayerId)
        );
    }
}
