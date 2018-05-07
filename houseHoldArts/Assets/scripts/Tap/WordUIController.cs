using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WordUIController : MonoBehaviour
{

    public enum Type { Small, Middle, Big };
    public Transform positionPointUI;
    public int id;
    public Type type = Type.Small;

    private bool isMenuActive;
    private WorldUI worldUI;

    // Use this for initialization
    void Start()
    {
        isMenuActive = false;
        if (id != 0)
        {
            worldUI = WorldUIDataManager.Instance.GetWorldUIById(this.id);
        }

    }

    void Update()
    {
        if (SceneWorldUI.Instance.isActiveAndEnabled && SceneWorldUI.Instance.currentObject == gameObject.name)
        {
            SceneWorldUI.Instance.UpdatePosition(positionPointUI);
        }
        ObserveTap();
    }

    public void ObserveTap() {


        #if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("tappppp 0 gameObject.name: " + gameObject.name);
                Debug.Log("tappppp 0 hit.transform.name: " + hit.transform.name);
                if (hit.transform.name == gameObject.name)
                {
                    Debug.Log("tappppp 1");
                    PerformAction(hit.transform.name);
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
                    if (Physics.Raycast(ray, out hit))
                    {
                        if (hit.transform.name == gameObject.name)
                        { 
                             PerformAction(hit.transform.name);
                        }
                    }

            }
        }
        #endif
    }

    public void PerformAction(string objectName)
    {
        //if (TapHelper.isAnimationPlays() || TapHelper.IsZivMoving(SceneManager.Instance.getCharacter())) { return; }
        if (TapHelper.IsZivMoving(SceneManager.Instance.getCharacter())) { return; }

        Debug.Log("tappppp 2");
        DisplayNestedObject();
    }

    public void DisplayNestedObject() {
        if (!AppManager.Instance.isAppUserInteractable) { return; }

        SceneWorldUI.Instance.Display(positionPointUI, gameObject.name);
        SceneWorldUI.Instance.HideAllMenu();

        GetMenu().SetActive(true);
        UpdateUI();
    }


    public GameObject GetMenu() {
        switch (type) {
            case Type.Small:
                return SceneWorldUI.Instance.small;
            case Type.Middle:
                return SceneWorldUI.Instance.mid;
            case Type.Big:
                return SceneWorldUI.Instance.big;

        }
        return GameObject.Find("small").gameObject;
    }

    public void UpdateUI() {
        WorldDataUIController.Instance.UpateUI(worldUI);
    }
}
