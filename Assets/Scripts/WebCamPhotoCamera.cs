using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WebCamPhotoCamera : MonoBehaviour
{
    Texture2D photo;
    int cont = 0;
    public Button button;
    public List<Texture2D> textures;
    public List<GameObject> images;

    // Start is called before the first frame update

    public void OnClickTakeScreenshotAndSaveButton()
    {
        if (NativeCamera.IsCameraBusy())
        {
            return;
        }
        else
        {
            photo = TakePicture(620);
            textures.Add(photo);
            GetComponent<Formulario>().ChargeImages();
            cont++;

            if (cont > 2)
            {
                button.interactable = false;
            }
        }
        
        
    }

    private Texture2D TakePicture (int height)
    {
        Texture2D t = null; 
        NativeCamera.Permission per = NativeCamera.TakePicture((path) => {
            Debug.Log(path);
            if(path != null)
            {
                t = NativeCamera.LoadImageAtPath(path, height);
            }
                
        });

        return t;
    }

    void OnDisable()
    {
        cont = 0;
        textures = null;
        images = null;
        button.interactable = true;
        Destroy(photo);
    }

}