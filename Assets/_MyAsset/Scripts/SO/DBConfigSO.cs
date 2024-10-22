using UnityEngine;

[CreateAssetMenu(menuName = "RedSkyRampageVRGame/DBConfigSO")]
public class DBConfigSO : ScriptableObject
{
    [SerializeField] private string _host;
    public string Host => _host;

    [SerializeField] private string _user;
    public string User => _user;

    [SerializeField] private string _password;
    public string Password => _password;

    [SerializeField] private string _database;
    public string Database => _database;

    [SerializeField] private uint _port;
    public uint Port => _port;
}