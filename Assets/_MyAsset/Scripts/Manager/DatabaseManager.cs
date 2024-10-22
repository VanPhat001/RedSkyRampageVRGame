using System.Data;
using MySql.Data.MySqlClient;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Singleton { get; private set; }

    [SerializeField] private DBConfigSO _databaseInfo;
    private MySqlConnectionStringBuilder _builder;


    void Awake()
    {
        Singleton = this;
    }

    private void Start()
    {
        _builder = new MySqlConnectionStringBuilder
        {
            Server = _databaseInfo.Host,
            UserID = _databaseInfo.User,
            Password = _databaseInfo.Password,
            Database = _databaseInfo.Database,
            Port = _databaseInfo.Port,
        };
    }

    public int ExecuteNonQuery(string query, params (string, object)[] parameters)
    {
        using (MySqlConnection connection = new MySqlConnection(_builder.ToString()))
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {

                foreach (var para in parameters)
                {
                    cmd.Parameters.AddWithValue(para.Item1, para.Item2);
                }

                return cmd.ExecuteNonQuery();
            }
        }
    }

    public object ExecuteScalar(string query, params (string, object)[] parameters)
    {
        using (MySqlConnection connection = new MySqlConnection(_builder.ToString()))
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {

                foreach (var para in parameters)
                {
                    cmd.Parameters.AddWithValue(para.Item1, para.Item2);
                }

                return cmd.ExecuteScalar();
            }
        }
    }

    public DataTable ExecuteReader(string query, params (string, object)[] parameters)
    {
        using (MySqlConnection connection = new MySqlConnection(_builder.ToString()))
        {
            connection.Open();
            using (MySqlCommand cmd = new MySqlCommand(query, connection))
            {
                foreach (var para in parameters)
                {
                    cmd.Parameters.AddWithValue(para.Item1, para.Item2);
                }

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    return dt;
                }
            }

        }
    }
}
