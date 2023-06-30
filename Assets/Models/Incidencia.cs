using MongoDB.Bson;
using Realms;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Incidencia : RealmObject
{
    [PrimaryKey]
    [MapTo("_id")]
    public ObjectId Id { get; set; }

    [MapTo("userID")]
    public string userID { get; set; }
    [MapTo("titulo")]
    public string titulo { get; set; }
    [MapTo("imagen1")]
    public string imagen1 { get; set; }
    [MapTo("imagen2")]
    public string imagen2 { get; set; }
    [MapTo("imagen3")]
    public string imagen3 { get; set; }
    [MapTo("descripcion")]
    public string descripcion { get; set; }
    [MapTo("latitud")]
    public string latitud { get; set; }
    [MapTo("longitud")]
    public string longitud { get; set; }
    [MapTo("localidad")]
    public string localidad { get; set; }
    [MapTo("direccion")]
    public string direccion { get; set; }

    public Incidencia(ObjectId id ,string userId, string titulo, string imagen1, string imagen2, string imagen3, string descripcion, string latitud, string longitud, string localidad, string direccion)
    {
        Id = id;
        userID = userId;
        this.titulo = titulo;
        this.imagen1 = imagen1;
        this.imagen2 = imagen2;
        this.imagen3 = imagen3;
        this.descripcion = descripcion;
        this.latitud = latitud;
        this.longitud = longitud;
        this.localidad = localidad;
        this.direccion = direccion;
    }
    public Incidencia()
    {
        Id = new ObjectId();
        userID = "";
        titulo = "";
        imagen1 = "";
        imagen2 = "";
        imagen3 = "";
        descripcion = "";
        latitud = "";
        longitud = "";
        localidad = "";
        direccion = "";
    }
}
