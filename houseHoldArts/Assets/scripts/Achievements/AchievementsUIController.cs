using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementsUIController : MonoBehaviour {


    public Text achievementsCounter;
    public GameObject unlocked;

    //Class 1
    public Sprite class1lesson1On;
    public Sprite class1lesson1Off;
    public Sprite class1lesson2On;
    public Sprite class1lesson2Off;
    public Sprite class1lesson3On;
    public Sprite class1lesson3Off;

    public GameObject class1lesson1;
    public GameObject class1lesson2;
    public GameObject class1lesson3;


    //Class 2
    public Sprite class2lesson1On;
    public Sprite class2lesson1Off;
    public Sprite class2lesson2On;
    public Sprite class2lesson2Off;
    public Sprite class2lesson3On;
    public Sprite class2lesson3Off;

    public GameObject class2lesson1;
    public GameObject class2lesson2;
    public GameObject class2lesson3;

    //Class 3
    public Sprite class3lesson1On;
    public Sprite class3lesson1Off;
    public Sprite class3lesson2On;
    public Sprite class3lesson2Off;
    public Sprite class3lesson3On;
    public Sprite class3lesson3Off;

    public GameObject class3lesson1;
    public GameObject class3lesson2;
    public GameObject class3lesson3;

    //Class 4
    public Sprite class4lesson1On;
    public Sprite class4lesson1Off;
    public Sprite class4lesson2On;
    public Sprite class4lesson2Off;
    public Sprite class4lesson3On;
    public Sprite class4lesson3Off;

    public GameObject class4lesson1;
    public GameObject class4lesson2;
    public GameObject class4lesson3;


    //Class 5
    public Sprite class5lesson1On;
    public Sprite class5lesson1Off;
    public Sprite class5lesson2On;
    public Sprite class5lesson2Off;
    public Sprite class5lesson3On;
    public Sprite class5lesson3Off;

    public GameObject class5lesson1;
    public GameObject class5lesson2;
    public GameObject class5lesson3;


    private static AchievementsUIController _instance;
    public static AchievementsUIController Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;

    }
    // Use this for initialization
    void Start () {
        Debug.Log("achievements start");
        UpdateUI();
    }

    // Update is called once per frame
    void Update () {

    }

    public void UpdateUI() {
        Debug.Log("achievements UpdateUI");
        UpdateAchievementsCounter();

        UpdateClass1Achievements();
        UpdateClass2Achievements();
        UpdateClass3Achievements();
        UpdateClass4Achievements();
        UpdateClass5Achievements();
    }


    //TODO: think about if we have e.g 2 animations piano in diff rooms
    //Maybe divide class1, class2
    public void UpdateClass1Achievements()
    {
        //Living room
        bool class1lesson1Finished = Achievements.Instance.GetAchievement(Constants.Animations.piano);
        class1lesson1.GetComponent<Image>().sprite =  class1lesson1Finished ? class1lesson1On : class1lesson1Off;

		bool class1lesson2Finished = Achievements.Instance.GetAchievement(Constants.Animations.fireplace);
        class1lesson2.GetComponent<Image>().sprite = class1lesson2Finished ? class1lesson2On : class1lesson2Off;

        bool class1lesson3Finished = Achievements.Instance.GetAchievement(Constants.Animations.armchair);
        class1lesson3.GetComponent<Image>().sprite = class1lesson3Finished ? class1lesson3On : class1lesson3Off;
    }

    public void UpdateClass2Achievements()
    {
        //
        bool class2lesson1Finished = Achievements.Instance.GetAchievement(Constants.Animations.bath);
        class2lesson1.GetComponent<Image>().sprite = class2lesson1Finished ? class2lesson1On : class2lesson1Off;

        bool class2lesson2Finished = Achievements.Instance.GetAchievement(Constants.Animations.sink);
        class2lesson2.GetComponent<Image>().sprite = class2lesson2Finished ? class2lesson2On : class2lesson2Off;

        bool class2lesson3Finished = Achievements.Instance.GetAchievement(Constants.Animations.toilet);
        class2lesson3.GetComponent<Image>().sprite = class2lesson3Finished ? class2lesson3On : class2lesson3Off;
    }

    public void UpdateClass3Achievements()
    {
        //
        bool class3lesson1Finished = Achievements.Instance.GetAchievement(Constants.Animations.crib);
        class3lesson1.GetComponent<Image>().sprite = class3lesson1Finished ? class3lesson1On : class3lesson1Off;

        bool class3lesson2Finished = Achievements.Instance.GetAchievement(Constants.Animations.dresser);
        class3lesson2.GetComponent<Image>().sprite = class3lesson2Finished ? class3lesson2On : class3lesson2Off;

        bool class3lesson3Finished = Achievements.Instance.GetAchievement(Constants.Animations.playArea);
        class3lesson3.GetComponent<Image>().sprite = class3lesson3Finished ? class3lesson3On : class3lesson3Off;
    }

    public void UpdateClass4Achievements()
    {
 
        bool class4lesson1Finished = Achievements.Instance.GetAchievement(Constants.Animations.bed);
        class4lesson1.GetComponent<Image>().sprite = class4lesson1Finished ? class4lesson1On : class4lesson1Off;

        bool class4lesson2Finished = Achievements.Instance.GetAchievement(Constants.Animations.closet);
        class4lesson2.GetComponent<Image>().sprite = class4lesson2Finished ? class4lesson2On : class4lesson2Off;
      
        bool class4lesson3Finished = Achievements.Instance.GetAchievement(Constants.Animations.pictures);
        class4lesson3.GetComponent<Image>().sprite = class4lesson3Finished ? class4lesson3On : class4lesson3Off;
    }

    public void UpdateClass5Achievements()
    {
        //
        bool class5lesson1Finished = Achievements.Instance.GetAchievement(Constants.Animations.dinnerTable);
        class5lesson1.GetComponent<Image>().sprite = class5lesson1Finished ? class5lesson1On : class5lesson1Off;

        bool class5lesson2Finished = Achievements.Instance.GetAchievement(Constants.Animations.range);
        class5lesson2.GetComponent<Image>().sprite = class5lesson2Finished ? class5lesson2On : class5lesson2Off;

        bool class5lesson3Finished = Achievements.Instance.GetAchievement(Constants.Animations.broom);
        class5lesson3.GetComponent<Image>().sprite = class5lesson3Finished ? class5lesson3On : class5lesson3Off;
    }

    public void UpdateAchievementsCounter()
    {
        AchieventCounter counter = Achievements.Instance.AchieventCounter;
        achievementsCounter.text = counter.achieved.ToString() + "/" + counter.total.ToString();

        if (unlocked == null) { return; }
        Image progress = unlocked.GetComponent<Image>();
        float percent = counter.achieved * 100 / counter.total;
        float fill = percent / 100.0f;
        progress.fillAmount = fill;
    }

    public void ResetAchievements() {
        Achievements.Instance.ResetAchievements();
        UpdateUI();
    }

}
