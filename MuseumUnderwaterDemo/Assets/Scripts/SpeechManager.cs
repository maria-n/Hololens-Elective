using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;


public class SpeechManager : MonoBehaviour, ISpeechHandler
{

    public GameObject[] placementKelp;
    public GameObject[] placementReef;
    public GameObject[] placementHole;
    public GameObject[] placementCoral;
    public GameObject dino;
    public string[] placementObjectStrings;

    public GameObject devModeIndicator;

    public static SpeechManager Instance { set; get; }
    public bool developerMode = false;

    private GameObject heldObject;
    private AudioSource audioPlayer;


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
        audioPlayer = GetComponent<AudioSource>();
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
            /*for (int i = 0; i < placementObjects.Length; i++)
            {
                if (eventData.RecognizedText == placementObjectStrings[i])
                {
                    heldObject = Instantiate(placementObjects[i]);
                    heldObject.GetComponent<TapToPlace>().IsBeingPlaced = true;
                    //set placementObjects as placement thingy
                }
            }*/

        //}
    }

    public GameObject getObject(int objectIndex)
    {
        switch(objectIndex)
        {
            case 0:
                for(int i = 0; i < placementHole.Length; i++)
                {
                    if(Vector3.Distance(placementHole[i].transform.position, Camera.main.transform.position) > 300.0f)
                    {
                        return placementHole[i];
                    }
                }
                break;

            case 1:
                for (int i = 0; i < placementKelp.Length; i++)
                {
                    if (Vector3.Distance(placementKelp[i].transform.position, Camera.main.transform.position) > 300.0f)
                    {
                        return placementKelp[i];
                    }
                }
                break;

            case 2:
                for (int i = 0; i < placementReef.Length; i++)
                {
                    if (Vector3.Distance(placementReef[i].transform.position, Camera.main.transform.position) > 300.0f)
                    {
                        return placementReef[i];
                    }
                }
                break;

            case 3:
                for (int i = 0; i < placementCoral.Length; i++)
                {
                    if (Vector3.Distance(placementCoral[i].transform.position, Camera.main.transform.position) > 300.0f)
                    {
                        return placementCoral[i];
                    }
                }
                break;
            case 4:
                return dino;
        }
        return null;
        
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
        audioPlayer.Play();
        heldObject = getObject(index);
        heldObject.GetComponent<TapToPlace>().IsBeingPlaced = true;
    }

    public void toggleDeveloper()
    {
        audioPlayer.Play();
        Debug.Log("Dev Mode toggled");
        developerMode = !developerMode;
    }

    void soundFeedbackPlay()
    {
        audioPlayer.Play();
    }
}
