using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorUIController : MonoBehaviour {

    public GameObject floorUI;
    public Transform positionFloorUI;

	// Use this for initialization
	void Start () {
        DisplayObject(false);
	}
	
	// Update is called once per frame
	void Update () {

	}

    public void DisplayObject(bool isShow)
    {
        SceneFloorUI.Instance.Display(floorUI, positionFloorUI.transform);
    }

}
