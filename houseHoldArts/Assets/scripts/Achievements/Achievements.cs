using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;



public class Achievements : MonoBehaviour
{


    public Dictionary<string, bool> achievementsClass1;
    public Dictionary<string, bool> achievementsClass2;
    public Dictionary<string, bool> achievementsClass3;
    public Dictionary<string, bool> achievementsClass4;
    public Dictionary<string, bool> achievementsClass5;

    private static Achievements _instance;
    public static Achievements Instance { get { return _instance; } }

    AchieventCounter achieventCounter;
    internal AchieventCounter AchieventCounter
    {
        get
        {
            CalculateAchievementsCount();
            return achieventCounter;
        }

        set
        {
            achieventCounter = value;
        }
    }
 

    void Awake()
    {
		
        _instance = this;

        achievementsClass1 = new Dictionary<string, bool>();
        achievementsClass2 = new Dictionary<string, bool>();
        achievementsClass3 = new Dictionary<string, bool>();
        achievementsClass4 = new Dictionary<string, bool>();
        achievementsClass5 = new Dictionary<string, bool>();

        InitClass1Achievements();
        InitClass2Achievements();
        InitClass3Achievements(); 
        InitClass4Achievements(); 
        InitClass5Achievements(); 
    }

    // Use this for initialization
    void Start()
    {
       // UpdateAchievements();
    }

    void Update()
    {

    }

    /// <summary>
    /// Inits the living room achievements.
    /// </summary>
    /// 
    //TODO: Add here all list of livingroom animations
    void InitClass1Achievements()
    {
        achievementsClass1.Add(Constants.Animations.piano, false);
        achievementsClass1.Add(Constants.Animations.armchair, false);
        achievementsClass1.Add(Constants.Animations.fireplace, false);
    }

    /// <summary>
    /// Inits the bath room achievements.
    /// </summary>
    //TODO: Add here all list of bathroom animations
    void InitClass2Achievements()
    {
        achievementsClass2.Add(Constants.Animations.bath, false);
		achievementsClass2.Add(Constants.Animations.sink, false);
		achievementsClass2.Add(Constants.Animations.toilet, false);
    }

    void InitClass3Achievements(){

		achievementsClass3.Add(Constants.Animations.crib, false);
		achievementsClass3.Add(Constants.Animations.dresser, false);
		achievementsClass3.Add(Constants.Animations.playArea, false); 
    }

    void InitClass4Achievements()
    {
		achievementsClass4.Add(Constants.Animations.closet, false);
		achievementsClass4.Add(Constants.Animations.pictures, false);
		achievementsClass4.Add(Constants.Animations.bed, false);
    }

    void InitClass5Achievements()
    {
		achievementsClass5.Add(Constants.Animations.dinnerTable, false);
		achievementsClass5.Add(Constants.Animations.range, false);
		achievementsClass5.Add(Constants.Animations.broom, false);
    }


    //UI
    private void DisplayMessage(string achievement)
    {
        StartCoroutine(ShowPromtAfterSeconds(1,achievement));
    }

    IEnumerator ShowPromtAfterSeconds(int seconds, string achievement)
    {
        yield return new WaitForSeconds(seconds);
        AppUIController.Instance.DisplayPromt(true, achievement + " " + Constants.Promt.animationUnlocked);
        StartCoroutine(HidePromtAfterSeconds(5));
    }

    IEnumerator HidePromtAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        AppUIController.Instance.DisplayPromt(false, "");
    }

    public bool IsCompleteAchievements()
    {
        AchieventCounter counter = Achievements.Instance.AchieventCounter;
        return counter.achieved > 0 ? counter.total == counter.achieved : false;
    }

    public bool IsSceneCompleteAchievements()
    {
        int sceneId = SceneManager.Instance.sceneId;
        Debug.Log("sceneId" + sceneId);
        bool flag = false;
        switch  (sceneId) {
            case (int)Scenes.LivingRoom:
       
                foreach (string key in achievementsClass1.Keys)
                {
                    flag = achievementsClass1[key];
                    if (!flag)
                    {
                        return false;
                    }
                }
                return flag;

            case (int)Scenes.BathRoom:
                foreach (string key in achievementsClass2.Keys)
                {
                    flag = achievementsClass2[key];
                    if (!flag)
                    {
                        return false;
                    }
                }
                return flag;

            case (int)Scenes.Nursery:
                foreach (string key in achievementsClass3.Keys)
                {
                    flag = achievementsClass3[key];
                    if (!flag)
                    {
                        return false;
                    }
                }
                return flag;

            case (int)Scenes.BedRoom:
                foreach (string key in achievementsClass4.Keys)
                {
                    flag = achievementsClass4[key];
                    if (!flag)
                    {
                        return false;
                    }
                }
                return flag;

            case (int)Scenes.Kitchen:
                foreach (string key in achievementsClass5.Keys)
                {
                    flag = achievementsClass5[key];
                    if (!flag)
                    {
                        return false;
                    }
                }
                return flag;

            default:
                return false;
        }
    }

    //Achievements
    /// <summary>
    /// Sets the achievement.
    /// </summary>
    /// <param name="audioSourceName">Audio source name.</param>
    public void SetAchievement(string objectName)
    {
        if (AnimationHelper.GetAnimationName(objectName) == null)
        {
            return;
        }
        string key = AnimationHelper.GetAnimationName(objectName);

        Debug.Log("SetAchievement = " + key);
        if (achievementsClass1.ContainsKey(key))
        {
            Debug.Log("achievementsClass1 SetAchievement = " + key);
            achievementsClass1[key] = true;
        }
        else if (achievementsClass2.ContainsKey(key))
        {
            Debug.Log("achievementsClass2 SetAchievement = " + key);
            achievementsClass2[key] = true;
        }
        else if (achievementsClass3.ContainsKey(key))
        {
            Debug.Log("achievementsClass3 SetAchievement = " + key);
            achievementsClass3[key] = true;
        }
        else if (achievementsClass4.ContainsKey(key))
        {
            Debug.Log("achievementsClass4 SetAchievement = " + key);
            achievementsClass4[key] = true;
        }
        else if (achievementsClass5.ContainsKey(key))
        {
            Debug.Log("achievementsClass5 SetAchievement = " + key);
            achievementsClass5[key] = true;
        }

        if (AchievementsUIController.Instance != null)
        {
            AchievementsUIController.Instance.UpdateUI();
        }

        //Display promt
        DisplayMessage(key);
        if (IsCompleteAchievements()) {
            AppUIController.Instance.DisplayCongratulations(true);
        } else if (IsSceneCompleteAchievements()) {
           AppUIController.Instance.DisplayCongratulations(true, true);
        }

        //UpdateAchievementsCounter();
    }


    /// <summary>
    /// Gets the achievement.
    /// To display in Achievements fadeIn/Out
    /// </summary>
    /// <returns><c>true</c>, if achievement was gotten, <c>false</c> otherwise.</returns>
    /// <param name="key">Key.</param>
    /// <param name="roomName">Room name.</param>
    public bool GetAchievement(string name)
    {
        //class 1
        foreach (string key in achievementsClass1.Keys)
        {
            if (key == name)
            {
                return achievementsClass1[key];
            }
        }
        //class 2
        foreach (string key in achievementsClass2.Keys)
        {
            if (key == name)
            {
                return achievementsClass2[key];
            }
        }
        //class 3
        foreach (string key in achievementsClass3.Keys)
        {
            if (key == name)
            {
                return achievementsClass3[key];
            }
        }
        //class 4
        foreach (string key in achievementsClass4.Keys)
        {
            if (key == name)
            {
                return achievementsClass4[key];
            }
        }
        //class 5
        foreach (string key in achievementsClass5.Keys)
        {
            if (key == name)
            {
                return achievementsClass5[key];
            }
        }
        return false;

    }

    /// <summary>
    /// Gets the achievements count.
    /// To display total count
    /// </summary>
    void CalculateAchievementsCount()
    {

        int total = achievementsClass1.Count + achievementsClass2.Count + achievementsClass3.Count + achievementsClass4.Count + achievementsClass5.Count;
        int achieved = 0;

        foreach (bool flag in achievementsClass1.Values)
        {
            achieved += flag ? 1 : 0;
            Debug.Log("class1 flag = " + flag);
        }

        foreach (bool flag in achievementsClass2.Values)
        {
            achieved += flag ? 1 : 0;
            Debug.Log(" class 2 flag= " + flag);
        }
        foreach (bool flag in achievementsClass3.Values)
        {
            achieved += flag ? 1 : 0;
            Debug.Log("class3 flag= " + flag);
        }
        foreach (bool flag in achievementsClass4.Values)
        {
            achieved += flag ? 1 : 0;
            Debug.Log("class4 flag= " + flag);
        }
        foreach (bool flag in achievementsClass5.Values)
        {
            achieved += flag ? 1 : 0;
            Debug.Log("class5 flag= " + flag);
        }
        Debug.Log(" achieved = " + achieved);

        achieventCounter.total = total;
        achieventCounter.achieved = achieved;
    }

    public void ResetAchievements() {

        int sceneId = SceneManager.Instance.sceneId;
        switch (sceneId)
        {
            case (int)Scenes.Intro:
                break;
            case (int)Scenes.LivingRoom:
                achievementsClass1 = achievementsClass1.ToDictionary(p => p.Key, p => false);
                break;
            case (int)Scenes.BathRoom:
                achievementsClass2 = achievementsClass2.ToDictionary(p => p.Key, p => false);
                break;
            case (int)Scenes.Nursery:
                achievementsClass3 = achievementsClass3.ToDictionary(p => p.Key, p => false);
                break;
            case (int)Scenes.BedRoom:
                achievementsClass4 = achievementsClass4.ToDictionary(p => p.Key, p => false);
                break;
            case (int)Scenes.Kitchen:
                achievementsClass5 = achievementsClass5.ToDictionary(p => p.Key, p => false);
                break;
            default:
                break;
        }


        if (AchievementsUIController.Instance != null)
        {
            AchievementsUIController.Instance.UpdateUI();
        }
    }

}