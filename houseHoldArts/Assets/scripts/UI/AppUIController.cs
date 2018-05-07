using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AppUIController : MonoBehaviour {

    public GameObject congratulationUI;
    public GameObject areYouAlive;
    public GameObject promptUI;
    public GameObject stopAnimationUI;

    public GameObject AboutPanel;
    public GameObject AchievementPanel;
    public GameObject ReferencesPanel;

    public GameObject MenuToggle;
    public GameObject AboutToggle;
    public GameObject AchievementToggle;
    public GameObject ReferencesToggle;
    public GameObject SoundToggle;

    private static AppUIController _instance;
    public static AppUIController Instance { get { return _instance; } }


    void Awake()
    {
        _instance = this;

    }

    // Use this for initialization
    void Start()
    {
        AppManager.Instance.isAppStarted = true;
        DisplayPromt(true, Constants.Promt.pointCamera);
        if (Achievements.Instance.IsCompleteAchievements()) {
            DisplayCongratulations(true);
        } else {
            DisplayCongratulations(Achievements.Instance.IsSceneCompleteAchievements(), true);
        }
 
        DisplayAreYouAlive(false);

        ResetScrollPositions();
    }


    // Update is called once per frame
    void Update()
    {
       
    }

    public void DisplayCongratulations(bool isVisible, bool isRoomOnly = false)
    {
        int classNo = SceneManager.Instance.sceneId - 1;
        congratulationUI.SetActive(isVisible);
        if (isVisible) {
            SoundEffectController.Instance.PlayCongratsSound();
        }

        GameObject textPanel = GameObject.Find("CongratsCanvas/TextPanel/classname");
        if (textPanel == null) { return; }
        if (isRoomOnly) {
            textPanel.GetComponent<Text>().text = "You've completed class " + 
                classNo.ToString() + 
                ".\n Please proceed to the next rooms.";
        } else {
            textPanel.GetComponent<Text>().text = "You've completed all classes.";
        }
    }

    public void DisplayAreYouAlive(bool isVisible)
    {
        areYouAlive.SetActive(isVisible);
    }

    public void DisplayPromt(bool isVisible, string text)
    {
        promptUI.GetComponent<Text>().text = text;
        promptUI.SetActive(isVisible);
    }

    public void DisplayStopAnimationPanel(bool isVisible)
    {
        stopAnimationUI.SetActive(isVisible);
    }

    // Display only one panel at time

    private void HideOtherMenuPanels()
    {
        DisplayAboutPanel(false);
        DisplayAchievementPanel(false);
        DisplayReferencesPanel(false);
    }

    private void DisplayAboutPanel(bool isVisible)
    {
        AboutPanel.SetActive(isVisible);
        ResetScrollPositions();
    }

    private void DisplayAchievementPanel(bool isVisible)
    {
        AchievementPanel.SetActive(isVisible);
        ResetScrollPositions();
    }

    private void DisplayReferencesPanel(bool isVisible)
    {
        ReferencesPanel.SetActive(isVisible);
        ResetScrollPositions();
    }

    public void OnAboutToggleClick()
    {
        if (AboutToggle.GetComponent<Toggle>().isOn)
        {
            HideOtherMenuPanels();
            DisplayAboutPanel(true);
            DisplayReferencesToggle(false);
            DisplayAchievementToggle(false);
        }
    }

    public void OnAchievementToggleClick()
    {
        if (AchievementToggle.GetComponent<Toggle>().isOn)
        {
            HideOtherMenuPanels();
            DisplayAchievementPanel(true);
            DisplayAboutToggle(false);
            DisplayReferencesToggle(false);
        }
    }

    public void OnReferencesToggleClick()
    {
        if (ReferencesToggle.GetComponent<Toggle>().isOn)
        {
            HideOtherMenuPanels();
            DisplayReferencesPanel(true);
            DisplayAboutToggle(false);
            DisplayAchievementToggle(false);
        }
    }

    private void DisplayReferencesToggle(bool isOn)
    {
        ReferencesToggle.GetComponent<Toggle>().isOn = isOn;
    }

    private void DisplayAboutToggle(bool isOn)
    {
        AboutToggle.GetComponent<Toggle>().isOn = isOn;
    }

    private void DisplayAchievementToggle(bool isOn)
    {
        AchievementToggle.GetComponent<Toggle>().isOn = isOn;
    }

    private void ResetScrollPositions()
    {
        ReferencesPanel.GetComponent<ScrollRect>().verticalNormalizedPosition = 1.0f;
        AchievementPanel.GetComponent<ScrollRect>().verticalNormalizedPosition = 1.0f;
        AboutPanel.GetComponent<ScrollRect>().verticalNormalizedPosition = 1.0f;
    }


    public void OnSoundToggleClick()
    {
        bool isMute = !SoundToggle.GetComponent<Toggle>().isOn;
        AudioController.Instance.MuteAudio(isMute);
        SoundEffectController.Instance.MuteAudio(isMute);

        if (!isMute) {
            AudioController.Instance.ResumeIntroOrAnimationAudio(); 
        }
    }

    public void OnMenuToggleClick() {
        if (AppManager.Instance.isLostTracking) { return; }

        bool isInteractable = !MenuToggle.GetComponent<Toggle>().isOn;
        AppManager.Instance.isAppUserInteractable = isInteractable;
        if (isInteractable){ 
            AudioController.Instance.ResumeIntroOrAnimationAudio(); 
        } else {
            AudioController.Instance.PauseIntroOrAnimationAudio();
        } 
    }

    public void OnUnlockChatacterClick() {
        SceneManager.Instance.PauseAnimation();
    }

    public bool IsInteractable() {
        return !MenuToggle.GetComponent<Toggle>().isOn;
    }
}