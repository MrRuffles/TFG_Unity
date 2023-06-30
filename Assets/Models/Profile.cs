using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using Realms;
using MongoDB.Bson;

public class Profile : RealmObject
{

    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId Id { get; set; }
    [MapTo("userID")]
    public string userID { get; set; }
    [MapTo("name")]
    public string name { get; set; }
    [MapTo("email")]
    public string email { get; set; }
    [MapTo("telefono")]
    public string telefono { get; set; }
    [MapTo("localidad")]
    public string localidad { get; set; }

    public Profile()
    {
        Id = new ObjectId();
        userID = "";
        name = "";
        email = "";
        telefono = "";
        localidad = "";
    }

    public Profile(ObjectId id, string userId, string name, string email, string telefono, string localidad)
    {
        Id = id;
        userID = userId;
        this.name = name;
        this.email = email;
        this.telefono = telefono;
        this.localidad = localidad;
    }

}
