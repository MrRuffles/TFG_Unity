using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Formulario : MonoBehaviour
{
    public Image im1;
    public Image im2;
    public Image im3;

    public TMP_InputField titulo;
    public TMP_InputField descripcion;

    public DatabaseAccess data;


    // Start is called before the first frame update
    void Start()
    {
        ChargeImages();
    }

    public void clickSend()
    {
        string image1 = Convert.ToBase64String(im1.sprite.texture.EncodeToPNG());
        string image2 = Convert.ToBase64String(im2.sprite.texture.EncodeToPNG());
        string image3 = Convert.ToBase64String(im3.sprite.texture.EncodeToPNG());

        data.SaveIncidenciaToDataBase(titulo.text, descripcion.text, gameObject.GetComponent<GPSLocation>().latitud, gameObject.GetComponent<GPSLocation>().longitud, gameObject.GetComponent<GPSLocation>().direccion, PlayerPrefs.GetString("LOCALIDAD"), image1, image2, image3);
        LayoutManager.Instance.IrHomePage();
    }

    public void clicBack()
    {
        im1.sprite = null;
        im2.sprite = null;
        im3.sprite = null;
        titulo.text = "";
        descripcion.text = "";
        LayoutManager.Instance.IrHomePage();
    }

    public void ChargeImages()
    {
        int c = gameObject.GetComponent<WebCamPhotoCamera>().textures.Count;
        if (c > 0)
        {
            switch (c)
            {
                case 1:
                    im1.sprite = Sprite.Create(gameObject.GetComponent<WebCamPhotoCamera>().textures[0], new Rect(0, 0, gameObject.GetComponent<WebCamPhotoCamera>().textures[0].width, gameObject.GetComponent<WebCamPhotoCamera>().textures[0].height), Vector2.zero);
                    break;
                case 2:
                    im1.sprite = Sprite.Create(gameObject.GetComponent<WebCamPhotoCamera>().textures[0], new Rect(0, 0, gameObject.GetComponent<WebCamPhotoCamera>().textures[0].width, gameObject.GetComponent<WebCamPhotoCamera>().textures[0].height), Vector2.zero);
                    im2.sprite = Sprite.Create(gameObject.GetComponent<WebCamPhotoCamera>().textures[1], new Rect(0, 0, gameObject.GetComponent<WebCamPhotoCamera>().textures[1].width, gameObject.GetComponent<WebCamPhotoCamera>().textures[1].height), Vector2.zero);
                    break;
                case 3:
                    im1.sprite = Sprite.Create(gameObject.GetComponent<WebCamPhotoCamera>().textures[0], new Rect(0, 0, gameObject.GetComponent<WebCamPhotoCamera>().textures[0].width, gameObject.GetComponent<WebCamPhotoCamera>().textures[0].height), Vector2.zero);
                    im2.sprite = Sprite.Create(gameObject.GetComponent<WebCamPhotoCamera>().textures[1], new Rect(0, 0, gameObject.GetComponent<WebCamPhotoCamera>().textures[1].width, gameObject.GetComponent<WebCamPhotoCamera>().textures[1].height), Vector2.zero);
                    im3.sprite = Sprite.Create(gameObject.GetComponent<WebCamPhotoCamera>().textures[2], new Rect(0, 0, gameObject.GetComponent<WebCamPhotoCamera>().textures[2].width, gameObject.GetComponent<WebCamPhotoCamera>().textures[2].height), Vector2.zero);
                    break;
            }

        }
    }

}
