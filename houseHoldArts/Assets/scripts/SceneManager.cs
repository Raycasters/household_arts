using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour {

    public int sceneId;


    private static SceneManager _instance;
    public static SceneManager Instance { get { return _instance; } }

    private AudioController audioController;
    void Awake()
    {
        _instance = this;
    }


	void Start () {

	}

	// Update is called once per frame
	void Update () {
		
	}

    public void StartScene() {
        StartIntroAudio();
        moveToStartPosition(null);
        AnimationHelper.StartInitialAnimation();
    }


    private void StartIntroAudio() {
        audioController = AudioController.Instance;
        if (sceneId != 0)
        {
            audioController.activeIntroAudio(sceneId);
        }
    }

    public void moveToStartPosition(string colliderName)
    {
        GameObject character = getCharacter();
        GameObject stPoint = getStartPoint();

        if (character != null && stPoint != null) {
            if (colliderName == null) { 
                character.GetComponent<Ziv>().moveToStartPosition(stPoint);
            } 
            else if (character.GetComponent<Ziv>().currentCollidedObject != null)
            {
                character.GetComponent<Ziv>().moveToStartPosition(stPoint);
            }
        }
        if (colliderName == null) { return; }
        Achievements.Instance.SetAchievement(colliderName);
    }

    public void EnableCharacter(bool isEnable) {
        GameObject character = getCharacter();
        if (character == null)
        {
            return;
        }
        character.GetComponent<Lean.Touch.LeanTranslate>().enabled = isEnable;
        character.GetComponent<Lean.Touch.LeanSelectable>().enabled = isEnable;
    }

    public void PauseAnimation()
    {
       if (getCharacter() != null) {
            getCharacter().GetComponent<Ziv>().PauseAnimation();   
       }
       moveToStartPosition(null);
    }

    public void UnLockCharacter()
    {
        if (getCharacter() != null)
        {
            getCharacter().GetComponent<Ziv>().LockPosition(false);
        }
       
    }
 
    public GameObject getCharacter() 
    { 
        switch (sceneId) {
            case (int)Scenes.Intro:
                return GameObject.Find(Constants.SceneNames.intro + "/Scene0/scene1avatar/Oneziv");
            case (int)Scenes.LivingRoom:
                return GameObject.Find(Constants.SceneNames.livingroom + "/Scene2/scene2avatar/Oneziv");
            case (int)Scenes.BathRoom:
                return GameObject.Find(Constants.SceneNames.bathroom + "/Scene2/scene3Avatar/Oneziv");
            case (int)Scenes.Nursery:
                return GameObject.Find(Constants.SceneNames.nursery + "/Scene3_nursery/avatar_3/Oneziv");
            case (int)Scenes.BedRoom:
                return GameObject.Find(Constants.SceneNames.bedroom + "/Scene4/avatarBedroom/Oneziv");
            case (int)Scenes.Kitchen:
                return GameObject.Find(Constants.SceneNames.kitchen + "/Scene6/avatarKitchen/Oneziv");
            default:
                return null;
        }
    }

    public GameObject getStartPoint()
    {
        switch (sceneId)
        {
            case (int)Scenes.Intro:
                return GameObject.Find(Constants.SceneNames.intro + "/Scene0/Intro_scene1_point");
            case (int)Scenes.LivingRoom:
                return GameObject.Find(Constants.SceneNames.livingroom + "/Scene2/scene2_livingroom_startpoint");
            case (int)Scenes.BathRoom:
                return GameObject.Find(Constants.SceneNames.bathroom + "/Scene2/startPointBath");
            case (int)Scenes.Nursery:
                return GameObject.Find(Constants.SceneNames.nursery + "/Scene3_nursery/startpoint3");
            case (int)Scenes.BedRoom:
                return GameObject.Find(Constants.SceneNames.bedroom + "/Scene4/Scene4_bedroo_startpoint");
            case (int)Scenes.Kitchen:
                return GameObject.Find(Constants.SceneNames.kitchen + "/Scene6/Scene6_Kitchen_startPoint");
            default:
                return null;
        }
    }
}
