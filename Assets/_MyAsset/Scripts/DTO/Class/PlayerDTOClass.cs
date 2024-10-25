using System;
using System.Data;
using UnityEngine;

public class PlayerDTOClass
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string DisplayName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Location { get; set; }
    public DateTime TimeCreated { get; set; }
    public string Gender { get; set; }
    public string Email { get; set; }


    public PlayerDTOClass(DataRow row)
    {
        Id = (int)row["id"];
        Username = row["username"].ToString();
        Password = row["password"].ToString();
        DisplayName = row["display_name"].ToString();
        DateOfBirth = DateTime.Parse(row["date_of_birth"].ToString());
        Location = row["location"].ToString();
        TimeCreated = DateTime.Parse(row["time_created"].ToString());
        Gender = row["gender"].ToString();
        Email = row["email"].ToString();
    }

    public PlayerDTOClass(int id, string username, string password, string displayName, DateTime dateOfBirth, string location, DateTime timeCreated, string gender, string email)
    {
        Id = id;
        Username = username;
        Password = password;
        DisplayName = displayName;
        DateOfBirth = dateOfBirth;
        Location = location;
        TimeCreated = timeCreated;
        Gender = gender;
        Email = email;
    }

    public PlayerDTOClass()
    {
    }
}