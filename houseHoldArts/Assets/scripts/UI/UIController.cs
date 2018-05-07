using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour {

    private static UIController _instance;
    public static UIController Instance { get { return _instance; } }

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

    public void Display(bool isShow)
    {
        gameObject.SetActive(isShow);
    }

    public void clickedStartButton()
    {
        Display(false);
    }
}
