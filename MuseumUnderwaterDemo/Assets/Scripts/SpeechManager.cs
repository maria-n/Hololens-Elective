using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;


public class SpeechManager : MonoBehaviour, ISpeechHandler
{

    public GameObject[] placementObjects;
    public string[] placementObjectStrings;

    public GameObject devModeIndicator;

    public static SpeechManager Instance { set; get; }
    public bool developerMode = false;

    private GameObject heldObject;

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
        devModeIndicator.SetActive(developerMode);
        if (developerMode)
        {

        }
    }

    public void OnSpeechKeywordRecognized(SpeechEventData eventData)
    {


        //if (developerMode)
        //{
            for (int i = 0; i < placementObjects.Length; i++)
            {
                if (eventData.RecognizedText == placementObjectStrings[i])
                {
                    heldObject = Instantiate(placementObjects[i]);
                    heldObject.GetComponent<TapToPlace>().IsBeingPlaced = true;
                    //set placementObjects as placement thingy
                }
            }

        //}
    }

    public void placeHole()
    {
        placeObjectIndex(0);
    }

    public void placeKelp()
    {
        placeObjectIndex(1);
    }

    public void placeReef()
    {
        placeObjectIndex(2);
    }

    public void placeCoral()
    {
        placeObjectIndex(3);
    }

    public void placeObjectIndex(int index)
    {
        //need to check for developer mode still
        heldObject = Instantiate(placementObjects[index]);
        heldObject.GetComponent<TapToPlace>().IsBeingPlaced = true;
    }

    public void toggleDeveloper()
    {
        Debug.Log("Dev Mode toggled");
        developerMode = !developerMode;
    }
}
