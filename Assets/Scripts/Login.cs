using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Login : MonoBehaviour
{
    public TMP_InputField emailIn;
    public TMP_InputField passIn;
    public DatabaseAccess data;
    public async void clickLogin()
    {
        var res = data.Login(emailIn.text, passIn.text);
        string ss = await res;

        if (ss == "")
        {
            LayoutManager.Instance.LogIn();
        }
        else
        {
            //TODO
            //Error Message
        }
        

    }
}
