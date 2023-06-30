using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Android;

public class GPSLocation : MonoBehaviour
{
    private static GPSLocation _instance;
    public TMP_Text localizacion;
    public bool isUpdating;
    public string latitud;
    public string longitud;
    public string direccion;
    public static GPSLocation Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("GPS is NULL");
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (!isUpdating)
        {
            StartCoroutine(GetLoc());
            isUpdating = !isUpdating;
        }
    }

    IEnumerator GetLoc()
    {
        if (!Permission.HasUserAuthorizedPermission(Permission.FineLocation))
        {
            Permission.RequestUserPermission(Permission.FineLocation);
            Permission.RequestUserPermission(Permission.CoarseLocation);
        }

        if (!Input.location.isEnabledByUser)
        {
            yield return new WaitForSeconds(3);
        }
        Input.location.Start();

        int maxWait = 3;
        while(Input.location.status == LocationServiceStatus.Initializing && maxWait > 0)
        {
            yield return new WaitForSeconds(1);
            maxWait--;
        }

        if(maxWait < 1)
        {
            localizacion.text = "";
            print("No se ha podido acceder a tu ubicacion");
            yield break;
        }
        else
        {

            latitud = Input.location.lastData.latitude.ToString();
            longitud = Input.location.lastData.longitude.ToString();

            localizacion.text = "Direccion: " + "\n" + "Latitud: " + Input.location.lastData.latitude + "\n" +
                "Longitud: " + Input.location.lastData.longitude;
        }

        isUpdating = !isUpdating;
        Input.location.Stop();
    }


   
}
