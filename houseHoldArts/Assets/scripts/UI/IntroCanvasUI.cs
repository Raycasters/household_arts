using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroCanvasUI : MonoBehaviour {

    public GameObject canvasIntro;
    public GameObject canvasLivingroom;
    public GameObject canvasBathroom;
    public GameObject canvasNursery;
    public GameObject canvasBedroom;
    public GameObject canvasKitchen;

    private static IntroCanvasUI _instance;
    public static IntroCanvasUI Instance { get { return _instance; } }


    void Awake()
    {
        _instance = this;

    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void DisplayCanvas() 
    {
        int sceneId = SceneManager.Instance.sceneId;

        switch (sceneId)
        {
            case (int)Scenes.Intro:
                canvasIntro.SetActive(true); 
                break;
            case (int)Scenes.LivingRoom:
                canvasLivingroom.SetActive(true);
                break;
            case (int)Scenes.BathRoom:
                canvasBathroom.SetActive(true);
                break;
            case (int)Scenes.Nursery:
                canvasNursery.SetActive(true);
                break;
            case (int)Scenes.BedRoom:
                canvasBedroom.SetActive(true);
                break;
            case (int)Scenes.Kitchen:
                canvasKitchen.SetActive(true);
                break;
            default:
                break;
        }
    }
}
