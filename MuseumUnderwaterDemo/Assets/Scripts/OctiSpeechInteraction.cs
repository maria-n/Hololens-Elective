using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class OctiSpeechInteraction : MonoBehaviour, ISpeechHandler
{

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.RecognizedText)
        {
            case "Hello":
                Debug.Log("Recognized Hello");
                gameObject.GetComponent<AudioSource>().Play();
                break;

            case "Test":
                Debug.Log("Testing");
                //gameObject.GetComponent<AudioSource>().Play();
                break;


        }
    }
}