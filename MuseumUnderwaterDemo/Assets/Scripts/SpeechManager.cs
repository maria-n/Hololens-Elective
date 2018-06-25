using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;

public class SpeechManager : MonoBehaviour, ISpeechHandler
{

    public GameObject[] placementObjects;
    public string[] placementObjectStrings;

    public static SpeechManager Instance { set; get; }
    public bool developerMode = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void Start()
    {

    }

    void Update()
    {
        if (developerMode)
        {

        }
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {
        switch (eventData.RecognizedText)
        {
            case "Developer":
                Debug.Log("Dev Mode toggled");
                developerMode = !developerMode;
                break;
        }

        if (developerMode)
        {
            for (int i = 0; i < placementObjects.Length; i++)
            {
                if (eventData.RecognizedText == placementObjectStrings[i])
                {
                    //set placementObjects as placement thingy
                }
            }

        }
    }

}
