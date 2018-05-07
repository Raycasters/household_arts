using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneFloorUI : MonoBehaviour {


    private GameObject currentFloorUI;

    private static SceneFloorUI _instance;
    public static SceneFloorUI Instance { get { return _instance; } }


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

    public void Display(GameObject floorUI, Transform positionUI) {
        if (currentFloorUI != null) {
            currentFloorUI.SetActive(false);
            currentFloorUI = null;
        }
        currentFloorUI = floorUI;
        currentFloorUI.SetActive(true);
        currentFloorUI.transform.position = positionUI.position;
    }

    public void Hide()
    {
        if (currentFloorUI == null) { return;  }
        currentFloorUI.SetActive(false);
        currentFloorUI = null;
    }
}
