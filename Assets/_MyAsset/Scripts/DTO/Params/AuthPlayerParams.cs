using UnityEngine;

public class AuthPlayerParams
{
    public bool IsFound { get; set; }
    public int DBPlayerId { get; set; }

    public AuthPlayerParams(bool isFound, int dBPlayerId)
    {
        IsFound = isFound;
        DBPlayerId = dBPlayerId;
    }
}