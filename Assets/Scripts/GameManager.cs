using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.GetString("UserLog") != null)
        {
            LayoutManager.Instance.IrHomePage();
        }
        else
        {
            LayoutManager.Instance.GoLogIn();
        }
    }

}
