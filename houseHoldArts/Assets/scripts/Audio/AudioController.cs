using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{

    private AudioSource currentAudioSource;
    private AudioSource pausedIntroAudioSource;
    private AudioSource NoneAudio;
    private AudioSource introAudio;

    public AudioSource introAudio1;
    public AudioSource introAudio2;
    public AudioSource introAudio3;
    public AudioSource introAudio4;
    public AudioSource introAudio5;
	public AudioSource introAudio6;

    public AudioSource pianoAudio;
    public AudioSource armchairAudio;
    public AudioSource fireplaceAudio;

	public AudioSource bathtubAudio;
	public AudioSource toiletAudio;
	public AudioSource sinkAudio;

	public AudioSource cribaudio;
	public AudioSource dresseraudio;
	public AudioSource playareaaudio;


	public AudioSource frameseaudio;
	public AudioSource closetaudio;
	public AudioSource bedaudio;

	public AudioSource dinnerTableaudio;
	public AudioSource rangeaudio;
	public AudioSource broomaudio;


    private bool isMuted = false;


    private string colliderName;
    private bool isPaused;
    // Use this for initialization

    private static AudioController _instance;
    public static AudioController Instance { get { return _instance; } }

    void Awake()
    {
		
        _instance = this;
        isPaused = false;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void activeIntroAudio(int sceneId)
    {
        PauseIntroOrAnimationAudio();
        introAudio = getIntro(sceneId);
        currentAudioSource = introAudio;
        PlayOrUnPauseAudio();
        SubtitlesManager.Instance.SwitchSubtitles("intro" + sceneId, currentAudioSource.time);
    }

    public void activeAnimationAudio(string collider) {
        PauseIntroOrAnimationAudio();
        currentAudioSource = getAnimationAudio(collider);
        PlayOrUnPauseAudio();
        colliderName = collider;
        SubtitlesManager.Instance.SwitchSubtitles(colliderName, currentAudioSource.time);
    }

    public void stopAudio(bool isStopGradually = false)
    {
        colliderName = null;
        if (currentAudioSource == NoneAudio)
        {
            print("No audio to Stop");
            return;
        }
        if (currentAudioSource.isPlaying)
        {
            currentAudioSource.Stop();
        }
    }

    public void PauseAnimationAudio()
    {
        if (currentAudioSource == NoneAudio)
        {
            print("No intro audio to Pause");
            return;
        }
        if (currentAudioSource.isPlaying)
        {
            currentAudioSource.Pause();
            AudioSource audioSourceToPause = getAnimationAudio(currentAudioSource);
            audioSourceToPause = currentAudioSource;

            //SubtitlesManager.Instance.StopSubtitles();
        }
        isPaused = true;
    }

    //Intro
    public void PauseIntroAudio()
    {
        if (currentAudioSource == NoneAudio)
        {
            print("No intro audio to Pause");
            return;
        }
        if (currentAudioSource.isPlaying)
        {
            currentAudioSource.Pause();
            pausedIntroAudioSource = currentAudioSource;
        }
        isPaused = true;
    }

    public void ResumeAnimationAudio()
    {
        if (currentAudioSource == NoneAudio)
        {
            print("No animation audio to Restart");
            return;
        }
        if (!currentAudioSource.isPlaying)
        {
            AudioSource audioSourceToUnPause = getAnimationAudio(currentAudioSource);
            currentAudioSource = audioSourceToUnPause;
            currentAudioSource.UnPause();
            StartAudioTracking();
            SetAudioVolume();
            ResumeSubtitles();
        }
        isPaused = false;
    }


    public void ResumeIntroAudio()
    {
        if (pausedIntroAudioSource == NoneAudio)
        {
            print("No intro audio to Restart");
            return;
        }
        if (!currentAudioSource.isPlaying)
        {
            currentAudioSource = pausedIntroAudioSource;
            currentAudioSource.UnPause();
            //StartAudioTracking();
            SetAudioVolume();
            ResumeSubtitles();
        }
        isPaused = false;
    }

    // Is playing
    public bool IsIntroAudioPlaying()
    {
        if (currentAudioSource == NoneAudio)
        {
            return false;
        }
        if (currentAudioSource.isPlaying && currentAudioSource == pausedIntroAudioSource)
        {
            return true;
        }
        return false;
    }

    public bool IsAnimationAudioPlaying()
    {
        if (currentAudioSource == NoneAudio)
        {
            return false;
        }
        if (currentAudioSource.isPlaying && currentAudioSource != introAudio)
        {
            return true;
        }
        return false;
    }

    public void StartAudioTracking() {
        isPaused = false;
        StartCoroutine(WaitForSound(currentAudioSource.clip));
    }

    private IEnumerator WaitForSound(AudioClip Sound)
    {
        if  (currentAudioSource == NoneAudio) {
            yield return null;
        }
        yield return new WaitUntil(() => currentAudioSource.isPlaying == false);
        // or yield return new WaitWhile(() => audiosource.isPlaying == true);

        if (!isPaused) {
           SubtitlesManager.Instance.StopSubtitles();
        }

        if (!isPaused && currentAudioSource != introAudio) {
            SceneManager.Instance.moveToStartPosition(colliderName);
            colliderName = null;
        }

        if (!AppManager.Instance.isLostTracking && AppManager.Instance.isAppUserInteractable) {
            ResumeIntroAudio();
        }
       
    }

    private AudioSource getIntro(int sceneId){

        switch(sceneId){
            case (int)Scenes.Intro:
                return introAudio1;
            case (int)Scenes.LivingRoom:
                return introAudio2;
            case (int)Scenes.BathRoom:
                return introAudio3;
            case (int)Scenes.Nursery:
                return introAudio4;
            case (int)Scenes.BedRoom:
                return introAudio5;
            case (int)Scenes.Kitchen:
				return introAudio6;
            default:
                return null;
        }
    }

    private AudioSource getAnimationAudio(AudioSource current)
    {
        // Living
        if (current == armchairAudio)
        {
            return armchairAudio;
        }
        if (current == pianoAudio)
        {
            return pianoAudio;
        }
        if (current == fireplaceAudio)
        {
            return fireplaceAudio;
        }

        // Bathroom
        if (current == bathtubAudio)
        {
            return bathtubAudio;
        }
        if (current == toiletAudio)
        {
            return toiletAudio;
        }
        if (current == sinkAudio)
        {
            return sinkAudio;
        }

        // Nursery
        if (current == cribaudio)
        {
            return cribaudio;
        }
        if (current == dresseraudio)
        {
            return dresseraudio;
        }
        if (current == playareaaudio)
        {
            return playareaaudio;
        }

        //Bedroom
        if (current == frameseaudio)
        {
            return frameseaudio;
        }
        if (current == closetaudio)
        {
            return closetaudio;
        }
        if (current == bedaudio)
        {
            return bedaudio;
        }

        // Kitchen
        if (current == dinnerTableaudio)
        {
            return dinnerTableaudio;
        }
        if (current == rangeaudio)
        {
            return rangeaudio;
        }
        if (current == broomaudio)
        {
            return broomaudio;
        }

        return null;
    }


    private AudioSource getAnimationAudio(string objectName)
    {
        // Livingroom
        if (objectName == Constants.Objects.Armchair)
        {
            return armchairAudio;
        }
        if (objectName == Constants.Objects.Piano)
        {
            return pianoAudio;
        }
        if (objectName == Constants.Objects.Fireplace)
        {
            return fireplaceAudio;
        }

        // Bathroom
        if (objectName == Constants.Objects.Bath)
        {
            return bathtubAudio;
        }
        if (objectName == Constants.Objects.Toilet)
        {
            return toiletAudio;
        }
        if (objectName == Constants.Objects.Sink)
        {
            return sinkAudio;
        }

        // Nursery
        if (objectName == Constants.Objects.crib)
        {
            return cribaudio;
        }
        if (objectName == Constants.Objects.dresser)
        {
            return dresseraudio;
        }
        if (objectName == Constants.Objects.PlayArea)
        {
            return playareaaudio;
        }

        // Bed
        if (objectName == Constants.Objects.Bed)
        {
            return bedaudio;
        }
        if (objectName == Constants.Objects.pictures)
        {
            return frameseaudio;
        }
        if (objectName == Constants.Objects.closet)
        {
            return closetaudio;
        }

        // Kitchen
        if (objectName == Constants.Objects.dinnerTable)
        {
            return dinnerTableaudio;
        }
        if (objectName == Constants.Objects.range)
        {
            return rangeaudio;
        }
        if (objectName == Constants.Objects.broom)
        {
            return broomaudio;
        }

        return null;
    }

    // Reset Audio 
    public void ResetAudio()
    {
        isPaused = false;
        colliderName = null;

        if (currentAudioSource != NoneAudio)
        {
            currentAudioSource.Stop();
            currentAudioSource = NoneAudio;
        }
        if (pausedIntroAudioSource != NoneAudio)
        {
            pausedIntroAudioSource = NoneAudio;
        }

        if (introAudio1 != NoneAudio)
        {
            introAudio1.time = 0;
        }
        if (introAudio2 != NoneAudio)
        {
            introAudio2.time = 0;
        }
        if (introAudio3 != NoneAudio)
        {
            introAudio3.time = 0;
        }
        if (introAudio4 != NoneAudio)
        {
            introAudio4.time = 0;
        }
        if (introAudio5 != NoneAudio)
        {
            introAudio5.time = 0;
        }
        if (pianoAudio != NoneAudio)
        {
            //pianoAudio.Stop();
            pianoAudio.time = 0;
        }
        if (armchairAudio != NoneAudio)
        {
            armchairAudio.time = 0;
        }
        if (fireplaceAudio != NoneAudio)
        {
            fireplaceAudio.time = 0;
        }

        if (bathtubAudio != NoneAudio)
        {
            bathtubAudio.time = 0;
        }

        if (toiletAudio != NoneAudio)
        {
            toiletAudio.time = 0;
        }
        if (sinkAudio != NoneAudio)
        {
            sinkAudio.time = 0;
        }

        if (cribaudio != NoneAudio)
        {
            cribaudio.time = 0;
        }
        if (dresseraudio != NoneAudio)
        {
            dresseraudio.time = 0;
        }
        if (playareaaudio != NoneAudio)
        {
            playareaaudio.time = 0;
        }

        if (frameseaudio != NoneAudio)
        {
            frameseaudio.time = 0;
        }
        if (closetaudio != NoneAudio)
        {
            closetaudio.time = 0;
        }
        if (bedaudio != NoneAudio)
        {
            bedaudio.time = 0;
        }
 
        if (dinnerTableaudio != NoneAudio)
        {
            dinnerTableaudio.time = 0;
        }
        if (rangeaudio != NoneAudio)
        {
            rangeaudio.time = 0;
        }
        if (broomaudio != NoneAudio)
        {
            broomaudio.time = 0;
        }
    }

    void ResumeSubtitles()
    {
        if (!currentAudioSource.isPlaying) { 
            SubtitlesManager.Instance.StopSubtitles();
            return; 
        }
        if (currentAudioSource == NoneAudio) {
            return;
        }
        if (currentAudioSource == introAudio)
        {

            SubtitlesManager.Instance.ResumeSubtitlesIntro(currentAudioSource.time);
        }
        else
        {
            SubtitlesManager.Instance.ResumeSubtitlesAnimation(colliderName, currentAudioSource.time);
        }
    }
       

    public void PlayOrUnPauseAudio()
    {
        if (currentAudioSource == NoneAudio)
        {
            return;
        }

        if (currentAudioSource.time > 0)
        {
            currentAudioSource.UnPause();
        }
        else
        {
            currentAudioSource.Play();
        }
        SetAudioVolume();
        StartAudioTracking();
    }

    public void PauseIntroOrAnimationAudio()
    {
        if (currentAudioSource == NoneAudio)
        {
            print("No audio to Pause");
            return;
        }
        if (currentAudioSource == introAudio)
        {
            PauseIntroAudio();
        }
        else
        {
            PauseAnimationAudio();
        }
 
        SubtitlesManager.Instance.StopSubtitles();
    }

    public void ResumeIntroOrAnimationAudio()
    {
        if (currentAudioSource == NoneAudio)
        {
            print("No audio to Pause");
            return;
        }
        if (currentAudioSource == introAudio)
        {
            ResumeIntroAudio();
        }
        else
        {
            ResumeAnimationAudio();
        }
    }

    // AR traking only Pause/UnPause during tracking interruption
    public void PauseOnLostTracking()
    {
        PauseIntroOrAnimationAudio();
    }

    public void ResumeOnActiveTracking()
    {
        ResumeIntroOrAnimationAudio();
    } 

    public void MuteAudio(bool isMute) {
        if (currentAudioSource == NoneAudio)
        {
            return;
        }
        isMuted = isMute;
        SetAudioVolume();
    }

    private void SetAudioVolume() {
        currentAudioSource.volume = isMuted ? 0 : 1; 
    }
}
