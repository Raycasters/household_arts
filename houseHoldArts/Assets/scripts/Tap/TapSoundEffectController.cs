using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapSoundEffectController : MonoBehaviour, TapInterface {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        ObserveTap();
	}
 
    public void ObserveTap()
    {

        #if UNITY_EDITOR
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform.name == gameObject.name)
                {
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

    public void PerformAction(string objectName) {
        if (!AppUIController.Instance.IsInteractable() || TapHelper.isAnimationPlays() || TapHelper.IsZivMoving(SceneManager.Instance.getCharacter())) { return; }
        SoundEffectController.Instance.PlayObjectSoundEffect(objectName);
    }
}
