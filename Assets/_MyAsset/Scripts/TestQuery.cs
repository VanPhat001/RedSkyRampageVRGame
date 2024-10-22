using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class TestQuery : MonoBehaviour
{
    void Start()
    {
        var dt = DatabaseManager.Singleton.ExecuteReader("select * from tbl_user;");
        foreach (DataRow row in dt.Rows)
        {
            string st = "";
            foreach (DataColumn col in dt.Columns)
            {
                st += row[col] + "\t";
            }
            Debug.Log(st);
        }
    }
}
