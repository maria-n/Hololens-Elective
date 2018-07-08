using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity.InputModule;
using HoloToolkit.Unity.SpatialMapping;
using HoloToolkit.Unity.InputModule.Utilities.Interactions;


public class SpeechManager : MonoBehaviour, ISpeechHandler
{

    public GameObject[] placementKelp;
    public GameObject[] placementReef;
    public GameObject[] placementHole;
    public GameObject[] placementCoral;
    public string[] placementObjectStrings;

    public GameObject dino;
    public GameObject dinoCube;

    public GameObject devModeIndicator;

    public static SpeechManager Instance { set; get; }
    public bool developerMode = false;

    private GameObject heldObject;
    private AudioSource audioPlayer;

    public AudioSource octiAudio;


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
        dinoEditingMode(developerMode);
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
        if (developerMode)
        {
            heldObject = getObject(index);
            if (heldObject)
                audioPlayer.Play();
            heldObject.GetComponent<TapToPlace>().IsBeingPlaced = true;
            heldObject.GetComponent<TapToPlace>().HandlePlacement();
        }
    }

    public void placeDino()
    {
        audioPlayer.Play();
        dino.GetComponent<TapToPlace>().IsBeingPlaced = true;
    }

    public void toggleDeveloper()
    {
        audioPlayer.Play();
        Debug.Log("Dev Mode toggled");
        developerMode = !developerMode;
        dinoEditingMode(developerMode);

    }

    public void dinoEditingMode(bool editModeOn)
    {
        if(editModeOn)
        {
            dino.GetComponent<TapToPlace>().enabled = true;
            dino.GetComponent<TwoHandManipulatable>().enabled = true;
            dino.GetComponent<BoxCollider>().enabled = true;
            dinoCube.SetActive(false);
        }
        else
        {
            dino.GetComponent<TapToPlace>().enabled = false;
            dino.GetComponent<TwoHandManipulatable>().enabled = false;
            dino.GetComponent<BoxCollider>().enabled = false;
            dinoCube.SetActive(true);
        }
    }

    void soundFeedbackPlay()
    {
        audioPlayer.Play();
    }

    public void RequestInformation()
    {

    }

    public void OctiTalk()
    {
        octiAudio.Play();
    }
}