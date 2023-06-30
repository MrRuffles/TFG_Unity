using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Threading.Tasks;

public class Register : MonoBehaviour
{
    public TMP_InputField nombreIn;
    public TMP_InputField emailIn;
    public TMP_InputField passIn;
    public TMP_InputField passConIn;
    public TMP_InputField telIn;
    public TMP_InputField locIn;

    public DatabaseAccess data;

    public async void clickRegisterAsync()
    {

        if (!passConIn.text.Equals(passIn.text))
        {
            //TODO
            //Error Message
        }
        else
        {
            string s = await data.Register(nombreIn.text, emailIn.text, passIn.text, telIn.text, locIn.text);

            if(s == "")
            {
                LayoutManager.Instance.GoLogIn();
            }
        }

    }

}
