using UnityEngine;

public class PlayerService
{
    private static PlayerService _singleton;
    public static PlayerService Singleton
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

    private PlayerService() {}


    public PlayerDTOClass FindPlayerByUsername(string username) { 
        var dt = DatabaseManager.Singleton.ExecuteReader(
            "select * from tbl_player where username=@username;",
            ("@username", username)
        );

        if (dt.Rows.Count == 0)
        {
            return null;
        }

        return new PlayerDTOClass(dt.Rows[0]);
    }
}