using System.Collections.Generic;
using UnityEngine;

public class ClientSpawnedObjectManager
{
    private static ClientSpawnedObjectManager _singleton;
    public static ClientSpawnedObjectManager Singleton
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


    private Dictionary<int, GameObject> _dict;

    public GameObject Get(int serverObjectId)
    {
        return _dict[serverObjectId];
    }

    public void Add(int serverObjectId, GameObject go)
    {
        _dict.Add(serverObjectId, go);
    }

    public void Remove(int serverObjectId)
    {
        _dict.Remove(serverObjectId);
    }
}