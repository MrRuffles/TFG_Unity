using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using Realms;
using Realms.Sync;
using Realms.Sync.Exceptions;
using System;
using System.Linq;
using static Realms.Sync.MongoClient;
using MongoDB.Bson;

public class DatabaseAccess : MonoBehaviour
{
    private static DatabaseAccess _instance;

    public string appId = "tfg-app-zsokw";

    private Realm _realm;
    private App _realmApp;
    private User _realmUser;

    void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void OnDisable()
    {
        if(_realm != null)
        {
            _realm.Dispose();
        }
    }

    public async Task<string> Login(string email, string password)
    {
        if(email != "" && password != "")
        {
            _realmApp = App.Create(new AppConfiguration(appId)
            {
                MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
            });

            try
            {
                _realmUser = await _realmApp.LogInAsync(Credentials.EmailPassword(email, password));

                Profile pr = await GetProfile();
                PlayerPrefs.SetString("EMAIL", pr.email);
                PlayerPrefs.SetString("NAME", pr.name);
                PlayerPrefs.SetString("TELEFONO", pr.telefono);
                PlayerPrefs.SetString("LOCALIDAD", pr.localidad);
                PlayerPrefs.SetString("USERID", _realmUser.Id);

            } catch (ClientResetException cli)
            {
                if(_realm != null)
                {
                    _realm.Dispose();
                }
                cli.InitiateClientReset();
            } catch (Exception ex)
            {
                Debug.LogError(ex);
                return ex.Message;
            }
            return "";
        }

        return "Email / Contraseña Necesarios!";
    }

    public async void Logout()
    {
        if(_realm != null)
        {
            await _realmUser.LogOutAsync();
            _realm.Dispose();
        }
    }

    public async Task<string> Register(string name, string email, string password, string telefono, string localidad)
    {
        if(name != "" && email != "" && password != "" && telefono != "" && localidad != "")
        {
            try
            {
                _realmApp = App.Create(new AppConfiguration(appId)
                {
                    MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
                });
                await _realmApp.EmailPasswordAuth.RegisterUserAsync(email, password);
                _realmUser = await _realmApp.LogInAsync(Credentials.EmailPassword(email, password));
                Profile pr = await CreateProfile(_realmUser.Id, name, email, telefono, localidad);
                return "";
            }catch(Exception ex)
            {
                Debug.LogError(ex);
                return ex.Message;
            }
        }
        return "Todos los campos son necesarios!";
    }


    public async Task<Profile> CreateProfile(string id, string name, string email, string telefono, string localidad)
    {
        Realms.Sync.MongoClient mongoClient = _realmUser.GetMongoClient("mongodb-atlas");
        Realms.Sync.MongoClient.Database dbTFG = mongoClient.GetDatabase("TFG");
        Collection<Profile> profileCollection = dbTFG.GetCollection<Profile>("profile");
        Profile pr = new Profile(new ObjectId(),_realmUser.Id, name, email, telefono, localidad) ;

        InsertResult insertResult = await profileCollection.InsertOneAsync(pr);
        
        return pr;
    }

    public async Task<Profile> GetProfile()
    {
        Realms.Sync.MongoClient mongoClient = _realmUser.GetMongoClient("mongodb-atlas");
        Realms.Sync.MongoClient.Database dbTFG = mongoClient.GetDatabase("TFG");
        Collection<Profile> profileCollection = dbTFG.GetCollection<Profile>("profile");
        Profile[] pr = await profileCollection.FindAsync(new { userID = _realmUser.Id });

        return pr[0];
    }


    public async void SaveIncidenciaToDataBase(string titulo, string desc, string lat, string lon, string dir,string localidad ,string imagen1, string imagen2, string imagen3)
    {

        if(titulo != "" && desc != "" && lat != "" && localidad != "" && imagen1 != "")
        {

            Realms.Sync.MongoClient mongoClient = _realmUser.GetMongoClient("mongodb-atlas");
            Realms.Sync.MongoClient.Database dbTFG = mongoClient.GetDatabase("TFG");
            Collection<Incidencia> incidenciaCollection = dbTFG.GetCollection<Incidencia>("incidencia");
            Incidencia inc = new Incidencia(new ObjectId(),_realmUser.Id, titulo, imagen1, imagen2, imagen3, desc, lat, lon, localidad, dir);

            try
            {
                _realmApp = App.Create(new AppConfiguration(appId)
                {
                    MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
                });

                InsertResult insertResult = await incidenciaCollection.InsertOneAsync(inc);

            }
            catch (Exception ex)
            {
                Debug.LogError(ex);
            }
        }
        
    }

    public async Task<IList<Incidencia>> GetIncidenciaByLocalidadFromDataBase(string localidad)
    {

        try
        {
            _realmApp = App.Create(new AppConfiguration(appId)
            {
                MetadataPersistenceMode = MetadataPersistenceMode.NotEncrypted
            });

            IList<Incidencia> incidencias = null;

            Realms.Sync.MongoClient mongoClient = _realmUser.GetMongoClient("mongodb-atlas");
            Realms.Sync.MongoClient.Database dbTFG = mongoClient.GetDatabase("TFG");
            Collection<Incidencia> incidenciaCollection = dbTFG.GetCollection<Incidencia>("incidencia");

            incidencias = await incidenciaCollection.FindAsync(new { localidad = localidad });

            return incidencias;

        }
        catch(Exception ex)
        {
            Debug.LogError(ex);
            return null;
        }
        
    }

}