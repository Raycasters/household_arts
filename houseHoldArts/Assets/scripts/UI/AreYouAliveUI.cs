using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AreYouAliveUI : MonoBehaviour {



    private static AreYouAliveUI _instance;
    public static AreYouAliveUI Instance { get { return _instance; } }


    private void Awake()
    {
        _instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnYesClick() 
    {
       // UserInactivityHelper.StartUserActivityTracking();
    }

    public void OnNoClick()
    {
      //  Achievements.Instance.ResetAchievements();
    }
}
