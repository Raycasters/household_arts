using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubtitlesManager : MonoBehaviour {

    public TextAsset SubtitleIntro;
    public TextAsset SubtitlePiano;
    public TextAsset SubtitleArmChair;
    public TextAsset SubtitleFireplace;

	public TextAsset SubtitleBathtub;
	public TextAsset SubtitleSink;
	public TextAsset SubtitleToilet;


	public TextAsset SubtitlePlayarea;
	public TextAsset SubtitleCrib;
	public TextAsset SubtitleDressingtable;

	public TextAsset SubtitleBed;
	public TextAsset SubtitleCloset;
	public TextAsset SubtitlePictures;

	public TextAsset SubtitleRange;
	public TextAsset SubtitleDinnerTable;
	public TextAsset SubtitleCleaning;

	public TextAsset SubtitleIntro2;
	public TextAsset SubtitleIntro3;
	public TextAsset SubtitleIntro4;
	public TextAsset SubtitleIntro5;
	public TextAsset SubtitleIntro6;

    private string currentSubtitle;
    //private IEnumerator subtitlesCoroutine;

    private static SubtitlesManager _instance;
    public static SubtitlesManager Instance { get { return _instance; } }
	// Use this for initialization
    void Awake()
    {

        _instance = this;
    }
	void Start () {

        _instance = this;
	}

	
    public void SwitchSubtitles(string goName, float audioTime)
    {
        Debug.Log("SwitchSubtitles: " + goName);
        StopSubtitles();
        if (goName == "intro1")
        {
            if (SubtitleIntro == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleIntro, audioTime);
        }
        else if (goName == "intro2")
        {
            if (SubtitleIntro2 == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleIntro2, audioTime);
        }
        else if (goName == "intro3")
        {
            if (SubtitleIntro3 == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleIntro3, audioTime);
        }
        else if (goName == "intro4")
        {
            if (SubtitleIntro4 == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleIntro4, audioTime);
        }
        else if (goName == "intro5")
        {
            if (SubtitleIntro5 == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleIntro5, audioTime);
        }
        else if (goName == "intro6")
        {
            if (SubtitleIntro6 == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleIntro6, audioTime);
        }
        else if (goName == Constants.Objects.Piano)
        {
            if (SubtitlePiano == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitlePiano, audioTime);
        }
        else if (goName == Constants.Objects.Armchair)
        {
       
            if (SubtitleArmChair == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleArmChair, audioTime);
          
        }
		else if (goName == Constants.Objects.Fireplace)
        {
            if (SubtitleFireplace == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleFireplace, audioTime);
        }
		else if (goName == Constants.Objects.Bath)
		{
            if (SubtitleBathtub == null) { return; }
            FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleBathtub, audioTime);
		}
		else if (goName == Constants.Objects.Toilet)
		{
			if (SubtitleBathtub == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleToilet, audioTime);
		}
		else if (goName == Constants.Objects.Sink)
		{
			if (SubtitleSink == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleSink, audioTime);
		}
		else if (goName == Constants.Objects.crib)
		{
			if (SubtitleCrib == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleCrib, audioTime);
		}
		else if (goName == Constants.Objects.dresser)
		{
			if (SubtitleDressingtable == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleDressingtable, audioTime);
		}
		else if (goName == Constants.Objects.PlayArea)
		{
			if (SubtitlePlayarea == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitlePlayarea, audioTime);
		}
		else if (goName == Constants.Objects.Bed)
		{
			if (SubtitleBed == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleBed, audioTime);
		}
		else if (goName == Constants.Objects.closet)
		{
			if (SubtitleCloset == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleCloset, audioTime);
		}
		else if (goName == Constants.Objects.pictures)
		{
			if (SubtitlePictures == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitlePictures, audioTime);
		}
		else if (goName == Constants.Objects.range)
		{
			if (SubtitleRange == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleRange, audioTime);
		}
		else if (goName == Constants.Objects.dinnerTable)
		{
			if (SubtitleDinnerTable == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleDinnerTable, audioTime);
		}
		else if (goName == Constants.Objects.broom)
		{
			if (SubtitleCleaning == null) { return; }
			FindObjectOfType<SubtitleDisplayer>().StartSubtitles(SubtitleCleaning, audioTime);
		}


        currentSubtitle = goName;
    }
 
    public void StopSubtitles() {
        if (FindObjectOfType<SubtitleDisplayer>() != null) {
            FindObjectOfType<SubtitleDisplayer>().StopSubtitles();
        }

        currentSubtitle = null;
    }
 

	// Update is called once per frame
	void Update () {
		
	}

    public void ResumeSubtitlesIntro(float audioTime)
    {

        int sceneId = AppManager.Instance.GetSceneId(null);
        if (sceneId != 0)
        {
            SubtitlesManager.Instance.SwitchSubtitles("intro" + sceneId, audioTime);
        }
        else
        {
            SubtitlesManager.Instance.SwitchSubtitles("intro" + SceneManager.Instance.sceneId, audioTime);
        }
    }

    public void ResumeSubtitlesAnimation(string audioName, float audioTime)
    {
 
        SubtitlesManager.Instance.SwitchSubtitles(audioName, audioTime);
    }
}
