using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneWorldUI : MonoBehaviour
{

    public GameObject small;
    public GameObject mid;
    public GameObject big;

    private GameObject ziv;

    private float seconds = 0;
    private float displayTime = 5;
    public string currentObject;

    private static SceneWorldUI _instance;
    public static SceneWorldUI Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
    }

    // Use this for initialization
    void Start()
    {
        DisplayObject(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkIfNeedHideUI();

        #if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            Debug.Log("mouse click Unity UI");

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.name == gameObject.name)
                {
                    DisplayObject(false);
                }
            }
        }
        #else
        for (int i = 0; i < Input.touchCount; ++i)
        {
            if (Input.GetTouch(i).phase == TouchPhase.Began)
            {
                // Construct a ray from the current touch coordinates
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
                Debug.Log("tap");
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.name == gameObject.name)
                        { 
                            DisplayObject(false);
                        }
                    }

            }
        }
        #endif
       
    }

    void resetSeconds() 
    {
        seconds = 0;
    }

    void increaseSeconds()
    {
        seconds += Time.deltaTime;
    }
    public void checkIfNeedHideUI() {
        if (!gameObject.activeSelf) {
            return;
        }

        increaseSeconds();
        if (seconds >= displayTime) {
            DisplayObject(false);
            currentObject = null;
        }
    }

    public void DisplayObject(bool isShow) {
        gameObject.SetActive(isShow);
        if (!isShow) {
            resetSeconds();
        }
    }

    public void Display(Transform positionPointUI, string objectName)
    {
        DisplayObject(true);
        currentObject = objectName;
        transform.position = new Vector3(positionPointUI.position.x, positionPointUI.position.y, positionPointUI.position.z);
    }

    public void UpdatePosition(Transform positionPointUI){
        transform.position = new Vector3(positionPointUI.position.x, positionPointUI.position.y, positionPointUI.position.z);
    }

    public void HideAllMenu()
    {
        small.SetActive(false);
        mid.SetActive(false);
        big.SetActive(false);
    }

}
