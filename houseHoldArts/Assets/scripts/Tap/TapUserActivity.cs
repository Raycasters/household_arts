using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapUserActivity : MonoBehaviour, TapInterface {

	// Use this for initialization
	void Start () {
		
	}
    // Update is called once per frame
    void Update()
    {
        UserInactivityHelper.IfAchievedInactiveLimit();

        ObserveTap();
        UpdateInactivityTime();
       
    }

    private void  UpdateInactivityTime() {
        
        if (TapHelper.isAnimationPlays() || TapHelper.IsZivMoving(SceneManager.Instance.getCharacter())) { return; }
        UserInactivityHelper.IncreaseInactiveTime();
    }

    public void ObserveTap()
    {



        #if UNITY_EDITOR
                if (Input.GetMouseButton(0))
                {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray, out hit, 10.0f))
                    {
                        PerformAction(null);
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
                        if (Physics.Raycast(ray, out hit, 10.0f))
                            {
                                
                                PerformAction(null);
                            }
                    }
                }
        #endif
    }

    public void PerformAction(string objectName)
    {
        UserInactivityHelper.ResetInactiveTime();
    }
}
