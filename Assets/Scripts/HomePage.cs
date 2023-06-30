using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading.Tasks;

public class HomePage : MonoBehaviour
{

    public DatabaseAccess data;
    public GameObject cardInstance;
    public GameObject parentCard;
    IList<Incidencia> cards;

    async void OnEnable()
    {
        cards = await data.GetIncidenciaByLocalidadFromDataBase(PlayerPrefs.GetString("LOCALIDAD"));
        OnStart();
    }
    // Start is called before the first frame update
    void OnStart()
    {
        int cont = 0;
        foreach(Incidencia card in cards)
        {
            GameObject c = Instantiate(cardInstance,parentCard.transform);
            c.name = "Card" + cont;
            c.transform.localScale = Vector2.one;
            c.SetActive(true);
            Array array = c.GetComponentsInChildren<TMP_Text>();
            TMP_Text title = (TMP_Text)array.GetValue(0);
            TMP_Text desc = (TMP_Text)array.GetValue(1);
            TMP_Text dir = (TMP_Text)array.GetValue(2);

            title.text = card.titulo;
            desc.text = card.descripcion;
            dir.text = card.direccion;

            cont++;
        }
    }

    public void clickIncidencia()
    {
        LayoutManager.Instance.IrForm();
    }

    public void clickPerfil()
    {
        LayoutManager.Instance.Perfil();
    }
}
