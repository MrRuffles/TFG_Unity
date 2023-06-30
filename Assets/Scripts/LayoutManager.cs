using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LayoutManager : MonoBehaviour
{

    private static LayoutManager _instance;
    public GameObject RegistroLayout;
    public GameObject LoginLayout;
    public GameObject PerfilLayout;
    public GameObject EditarLayout;
    public GameObject HomeLayout;
    public GameObject FormLayout;

    public static LayoutManager Instance
    {
        get
        {
            if (_instance is null)
                Debug.LogError("Layout is NULL");
            return _instance;
        }
    }
    void Awake()
    {
        _instance = this;
    }

    public void GoLogIn()
    {
        RegistroLayout.SetActive(false);
        PerfilLayout.SetActive(false);
        EditarLayout.SetActive(false);
        HomeLayout.SetActive(false);
        FormLayout.SetActive(false);

        LoginLayout.SetActive(true);
    }

    public void GoRegister()
    {
        PerfilLayout.SetActive(false);
        EditarLayout.SetActive(false);
        HomeLayout.SetActive(false);
        FormLayout.SetActive(false);
        LoginLayout.SetActive(false);

        RegistroLayout.SetActive(true);
    }

    public void LogIn()
    {
        PerfilLayout.SetActive(false);
        EditarLayout.SetActive(false);
        FormLayout.SetActive(false);
        LoginLayout.SetActive(false);
        RegistroLayout.SetActive(false);

        HomeLayout.SetActive(true);
    }

    public void Perfil()
    {
        EditarLayout.SetActive(false);
        FormLayout.SetActive(false);
        HomeLayout.SetActive(false);
        LoginLayout.SetActive(false);
        RegistroLayout.SetActive(false);

        PerfilLayout.SetActive(true);
    }

    public void IrForm()
    {
        PerfilLayout.SetActive(false);
        EditarLayout.SetActive(false);
        HomeLayout.SetActive(false);
        LoginLayout.SetActive(false);
        RegistroLayout.SetActive(false);

        FormLayout.SetActive(true);
    }

    public void IrHomePage()
    {
        PerfilLayout.SetActive(false);
        EditarLayout.SetActive(false);
        FormLayout.SetActive(false);
        LoginLayout.SetActive(false);
        RegistroLayout.SetActive(false);

        HomeLayout.SetActive(true);
    }

}
