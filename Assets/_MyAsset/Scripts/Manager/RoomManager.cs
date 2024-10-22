using System;
using System.Collections.Generic;
using AYellowpaper.SerializedCollections;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Singleton { get; private set; }

    [SerializeField] private SerializedDictionary<int, RoomInfo> _roomDict;
    public SerializedDictionary<int, RoomInfo> RoomDict { get => _roomDict; set => _roomDict = value; }

    public readonly uint MAX_ROOMS = 10;
    public readonly uint MAX_PLAYERS_IN_ROOM = 4;


    void Awake()
    {
        Singleton = this;
    }

    public int CreateRoom(GameObject roomGO)
    {
        try
        {
            if (RoomDict.Keys.Count >= MAX_ROOMS)
            {
                Debug.Log("[DEV] max rooms");
                return -1;
            }

            var roomInfo = new RoomInfo();
            roomInfo.RoomId = RoomDict.Keys.Count;
            roomInfo.RoomGO = roomGO;

            RoomDict.Add(roomInfo.RoomId, roomInfo);

            return roomInfo.RoomId;
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
            return -1;
        }
    }

    // public void DeleteRoom() {}

    public EAddPlayerToRooms AddPlayerToRoom(int roomId, int playerId)
    {
        try
        {
            var roomInfo = RoomDict[roomId];
            if (roomInfo == null)
            {
                Debug.Log("[DEV] room is not exists");
                return EAddPlayerToRooms.RoomNotExists;
            }

            if (roomInfo.PlayerIdList.Count >= MAX_PLAYERS_IN_ROOM)
            {
                Debug.Log("[DEV] reach max player");
                return EAddPlayerToRooms.ReachMaxPlayer;
            }

            if (roomInfo.PlayerIdList.Contains(playerId))
            {
                Debug.Log("[DEV] player id exists");
                return EAddPlayerToRooms.PlayerIdExists;
            }

            roomInfo.PlayerIdList.Add(playerId);

            return EAddPlayerToRooms.OK;
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
            return EAddPlayerToRooms.Error;
        }
    }

    public ERemovePlayerFromRooms RemovePlayerFromRoom(int roomId, int playerId)
    {
        try
        {
            var roomInfo = RoomDict[roomId];
            if (roomInfo == null)
            {
                Debug.Log("[DEV] room is not exists");
                return ERemovePlayerFromRooms.RoomNotExists;
            }

            roomInfo.PlayerIdList.Remove(playerId);

            return ERemovePlayerFromRooms.OK;
        }
        catch (Exception e)
        {
            Debug.Log("[DEV, ERROR] " + e);
            return ERemovePlayerFromRooms.Error;
        }
    }
}

public enum EAddPlayerToRooms
{
    Error, RoomNotExists, ReachMaxPlayer, PlayerIdExists, OK,
}

public enum ERemovePlayerFromRooms
{
    Error, OK, RoomNotExists,
}

[Serializable]
public class RoomInfo
{
    public int RoomId;
    public GameObject RoomGO;

    public List<int> PlayerIdList = new();

    public int LeaderId => PlayerIdList[0];
}