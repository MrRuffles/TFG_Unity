using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProfileLoad : MonoBehaviour
{
    public TMP_Text nombre;
    public TMP_Text email;
    public TMP_Text telefono;
    public TMP_Text localidad;

    DatabaseAccess data;
    // Start is called before the first frame update
    void Start()
    {
        nombre.text = PlayerPrefs.GetString("NAME");
        email.text = PlayerPrefs.GetString("EMAIL");
        telefono.text = PlayerPrefs.GetString("TELEFONO");
        localidad.text = PlayerPrefs.GetString("LOCALIDAD");
    }

    public void clickCerrarSesion()
    {
        data.Logout();
        LayoutManager.Instance.GoLogIn();
    }
}
