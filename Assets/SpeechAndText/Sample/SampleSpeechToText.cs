using UnityEngine;
using UnityEngine.UI;
using TextSpeech;
using UnityEngine.Android;
using TMPro;

public class SampleSpeechToText : MonoBehaviour
{
    public bool isShowPopupAndroid = true;
    public TMP_InputField inputText;
    public float pitch;
    public float rate;



    void Start()
    {
        Setting("es-ES");
        SpeechToText.Instance.onResultCallback = OnResultSpeech;
#if UNITY_ANDROID
        SpeechToText.Instance.isShowPopupAndroid = isShowPopupAndroid;
        Permission.RequestUserPermission(Permission.Microphone);
#endif

    }


    public void StartRecording()
    {
#if UNITY_EDITOR
#else
        SpeechToText.Instance.StartRecording("Habla");
#endif
    }

    public void StopRecording()
    {
#if UNITY_EDITOR
        OnResultSpeech("No soportado en Editor.");
#else
        SpeechToText.Instance.StopRecording();
#endif
    }
    void OnResultSpeech(string _data)
    {
        inputText.text = _data;
    }
    public void OnClickSpeak()
    {
        TextToSpeech.Instance.StartSpeak(inputText.text);
    }

    /// <summary>
    /// </summary>
    public void  OnClickStopSpeak()
    {
        TextToSpeech.Instance.StopSpeak();
    }

    /// <summary>
    /// </summary>
    /// <param name="code"></param>
    public void Setting(string code)
    {
        SpeechToText.Instance.Setting(code);
        TextToSpeech.Instance.Setting(code, pitch, rate);
    }

}
