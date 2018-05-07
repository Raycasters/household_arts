using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffectController : MonoBehaviour {

    public AudioSource ButtonSoundAudio;
    public AudioSource CongratsSoundAudio;

    public AudioSource ChairSoundAudio;
    public AudioSource PianoSoundAudio;

	public AudioSource FireplaceSoundAudio;

    public AudioSource BathSoundAudio;
    public AudioSource SinkSoundAudio;
    public AudioSource ToiletSoundAudio;

    public AudioSource CribSoundAudio;
    public AudioSource PlayAreaSoundAudio;

    public AudioSource DresserSoundAudio;

	public AudioSource BedSoundAudio;
	public AudioSource ClosetSoundAudio;
	public AudioSource PicturesSoundAudio;


	public AudioSource TableSoundAudio;
	public AudioSource StoveSoundAudio;
	public AudioSource BroomSoundAudio;


    private bool isMuted = false;
    private static SoundEffectController _instance;
    public static SoundEffectController Instance { get { return _instance; } }

    void Awake()
    {
        _instance = this;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PlayButtonUISound() {

        if (isMuted) { return; }
        if (ButtonSoundAudio == null) {  return; }
        ButtonSoundAudio.Play();
    }

    public void PlayCongratsSound()
    {
        if (isMuted) { return; }
        if (CongratsSoundAudio == null) {  return; }
        CongratsSoundAudio.Play();
    }

    public void PlayObjectSoundEffect(string objectname)
    {
        if (isMuted) { return; }
        AudioSource soundEffect = getSoundSource(objectname);
        soundEffect.Play();
    }

    private AudioSource getSoundSource(string objectname) {

        if (objectname == Constants.Objects.Armchair && ChairSoundAudio != null)
        {
            return ChairSoundAudio;
        }
        if (objectname == Constants.Objects.Piano && PianoSoundAudio != null)
        {
            return PianoSoundAudio;
        }
        // bath
        if (objectname == Constants.Objects.Bath && BathSoundAudio != null)
        {
            return BathSoundAudio;
        }

        if (objectname == Constants.Objects.Sink && SinkSoundAudio != null)
        {
            return SinkSoundAudio;
        }

        if (objectname == Constants.Objects.Toilet && ToiletSoundAudio != null)
        {
            return ToiletSoundAudio;
        }

        if (objectname == Constants.Objects.crib && CribSoundAudio != null)
        {
            return CribSoundAudio;
        }

        if (objectname == Constants.Objects.PlayArea && PlayAreaSoundAudio != null)
        {
            return PlayAreaSoundAudio;
        }

        if (objectname == Constants.Objects.dresser && DresserSoundAudio != null)
        {
            return DresserSoundAudio;
        }
		if (objectname == Constants.Objects.Bed && BedSoundAudio != null)
		{
			return BedSoundAudio;
		}

		if (objectname == Constants.Objects.closet && ClosetSoundAudio != null)
		{
			return ClosetSoundAudio;
		}
		if (objectname == Constants.Objects.pictures && PicturesSoundAudio != null)
		{
			return PicturesSoundAudio;
		}
		if (objectname == Constants.Objects.range && StoveSoundAudio != null)
		{
			return StoveSoundAudio;
		}

		if (objectname == Constants.Objects.broom && BroomSoundAudio != null)
		{
			return BroomSoundAudio;
		}
		if (objectname == Constants.Objects.dinnerTable && BroomSoundAudio != null)
		{
			return BroomSoundAudio;
		}
		if (objectname == Constants.Objects.Fireplace && FireplaceSoundAudio != null)
		{
			return FireplaceSoundAudio;
		}


        return null;
    }

    public void MuteAudio(bool isMute)
    {
        isMuted = isMute;
    }
}
