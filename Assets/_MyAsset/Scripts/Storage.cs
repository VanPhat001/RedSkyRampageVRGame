using UnityEngine;

public static class Storage
{
    public static int DBPlayerId = -1;


    public static bool IsLogin => DBPlayerId >= 0;
}