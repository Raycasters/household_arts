using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum Scenes
{
    Intro = 1,
    LivingRoom = 2,
    BathRoom = 3,
    Nursery = 4,
    BedRoom = 5,
    Kitchen = 6
}

public class AppManager : MonoBehaviour
{

    private string currentTrackableName;
    private float counter = 0.0f;
    private float maxAccidentSeconds = 0.5f;
    private float maxAccidentSecondsCurrentScene = 6.0f;
    public bool isAppUserInteractable = true;
 
    public bool isAppStarted;
    private bool isAppActive;
    public bool isLostTracking;

    private static AppManager _instance;
    public static AppManager Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
        isAppStarted = false;
        isAppActive = false;
        isLostTracking = false;
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isAppActive)
        {
            counter += Time.deltaTime;
            //Debug.Log("__counter__" + counter);
        }

    }

    public void FoundTrackable(string name)
    {
        isAppActive = true;
        int sceneId = GetSceneId(name);
        Debug.Log("FoundTrackable__sceneId__" + sceneId);

        SceneManager.Instance.sceneId = sceneId;
        SceneManager.Instance.UnLockCharacter();

        if ((currentTrackableName != name && counter > maxAccidentSeconds) ||
            (currentTrackableName == name && counter > maxAccidentSecondsCurrentScene))
        {   
            currentTrackableName = name;
            ResetSceneState();
            SceneManager.Instance.moveToStartPosition(null);
            IntroCanvasUI.Instance.DisplayCanvas();
            //StartIntro();
        }
        else
        {
            currentTrackableName = name;
            ResumeSceneState();
        }
        AppUIController.Instance.DisplayPromt(false, "");
        UserInactivityHelper.StopUserActivityTracking();
    }

    public void LostTrackable()
    {
        isAppActive = false;
        ResetCounter();
        PauseSceneState();

        AppUIController.Instance.DisplayPromt(true, Constants.Promt.pointCamera);
        UserInactivityHelper.StartUserActivityTracking();
    }

    public void ResetCounter()
    {
        counter = 0.0f;
    }

    private void ResetSceneState()
    {
        isLostTracking = false;
        AudioController.Instance.ResetAudio();
    }

    private void ResumeSceneState()
    {
        if (SceneManager.Instance.getCharacter() != null)
        {
            SceneManager.Instance.getCharacter().GetComponent<Ziv>().ResumeOnLostTrackingAnimation();
        }
        isLostTracking = false;
        AudioController.Instance.ResumeOnActiveTracking();
    }

    private void PauseSceneState()
    {
        isLostTracking = true;
        AudioController.Instance.PauseOnLostTracking();
        if (SceneManager.Instance.getCharacter() != null)
        {
            SceneManager.Instance.getCharacter().GetComponent<Ziv>().PauseOnLostTrackinAnimation();
        }
    }


    public int GetSceneId(string scenename)
    {
        string target = currentTrackableName;
        if (scenename != null) {
            target = scenename;
        }  
     
        Debug.Log("AppManager GetSceneId currentTrackableName: " + target);

		if (target == "postcards_intro-01" || target == "introWoodupdate")
		{
			return (int)Scenes.Intro;
		}
		if (target == "livinRoomScene" || target == "livingroomWoodNew")
		{
			return (int)Scenes.LivingRoom;
		}
		if (target == "bathroomScene"  || target == "Bathroom")
		{
			return (int)Scenes.BathRoom;
		}
		if (target == "nurseryScene" || target == "nurserywood")
		{
			return (int)Scenes.Nursery;
		}
		if (target == "bedroomScene" || target == "bedroomWood")
		{
			return (int)Scenes.BedRoom;
		}
		if (target == "kitchenScene"|| target == "kitchenWood")
		{
			return (int)Scenes.Kitchen;
		}
		return 0;
	}
}




