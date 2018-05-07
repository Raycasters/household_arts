using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ziv : MonoBehaviour {



	private Animator animator;
	private AudioController audioController;
    private SoundEffectController soundEffectController;
	private bool isLocked;
	//private bool isLostTracking;
	private bool isMovingTracking;
	public GameObject currentCollidedObject;

	// Use this for initialization
	void Start () {
		isLocked = false;
		isMovingTracking = false;
		audioController = AudioController.Instance;
        soundEffectController = SoundEffectController.Instance;
		animator = gameObject.GetComponent<Animator>();
	}

	void Update()
	{
		//for (int i = 0; i < Input.touchCount; ++i)
		//{
		//    if (Input.GetTouch(i).phase == TouchPhase.Began)
		//    {
		//        Debug.Log("User click on Device");
		//        UIController.Instance.Display(true);
		//    }
		//}

		////TODO: uncomment for unity
		//if (Input.GetMouseButton(0))
		//{
		//   Debug.Log("User click in Unity"); 
		//   UIController.Instance.Display(true);
		//}

	}

    public void assignAnimator(string animationName)
    {
        //animator.enabled = true;
        animator.runtimeAnimatorController = Resources.Load(animationName) as RuntimeAnimatorController;
    }

	private bool isAnimationObject(GameObject otherObject) {
		if (otherObject.GetComponent<AnimationController>() != null) {
			return true;
		}
		return false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (!isAnimationObject(other.gameObject)) { return; }

		currentCollidedObject = other.gameObject;

		GameObject go = other.gameObject;
		SetUpUserPosition(go);
		StartAnimation(go);
	}

	void SetUpUserPosition(GameObject go) {
		AnimationController animController = go.GetComponent<AnimationController>();

		if (animController != null)
		{
			transform.position = animController.getPosition();
			transform.rotation = animController.getRotaton();
		}
	}

	void StartAnimation(GameObject go) {
		string colliderName = go.name;

        //Livingroom
        if (colliderName == Constants.Objects.Piano)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/ziv_piano") as RuntimeAnimatorController;
            audioController.activeAnimationAudio(colliderName);
			LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}
        if (colliderName == Constants.Objects.Armchair)
        {
            animator.runtimeAnimatorController = Resources.Load("animations/zivCouch") as RuntimeAnimatorController;
            audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
        }
        if (colliderName == Constants.Objects.Fireplace)
        {
            animator.runtimeAnimatorController = Resources.Load("animations/fireziv") as RuntimeAnimatorController;
            audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
        }

        ///Bathroom///
        if (colliderName == Constants.Objects.Toilet)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/zivtoilet") as RuntimeAnimatorController;
            audioController.activeAnimationAudio(colliderName);
			LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}
        if (colliderName == Constants.Objects.Bath)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/ZivBathroom") as RuntimeAnimatorController;
            audioController.activeAnimationAudio(colliderName);
			LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}
        if (colliderName == Constants.Objects.Sink)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/ZivSink") as RuntimeAnimatorController;
            audioController.activeAnimationAudio(colliderName);
			LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}
		if (colliderName == Constants.Objects.range)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/rangeZiv") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
			LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}

        //if (colliderName == Constants.Objects.Couch)
		//{
			//animator.runtimeAnimatorController = Resources.Load("animations/zivcouch") as RuntimeAnimatorController;
			//audioController.activeDeskAudio(colliderName);
			//LockPosition(true);
		//}

		///nursery///
        if (colliderName == Constants.Objects.crib)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/ZivDresser") as RuntimeAnimatorController;
            audioController.activeAnimationAudio(colliderName);
			LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}
        if (colliderName == Constants.Objects.PlayArea)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/zivPlayarea") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}

		if (colliderName == Constants.Objects.dresser)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/ZivCrib") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}

		/////bedroom////

        if (colliderName == Constants.Objects.Bed)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/zivBed") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}
		if (colliderName == Constants.Objects.closet)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/zivCloset") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}
		if (colliderName == Constants.Objects.pictures)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/zivHangPic") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}

		////kitchen and dining room///
        if (colliderName == Constants.Objects.dinnerTable)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/zivDinner") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
			LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}

		if (colliderName == Constants.Objects.broom)
		{
			animator.runtimeAnimatorController = Resources.Load("animations/zivBroom") as RuntimeAnimatorController;
			audioController.activeAnimationAudio(colliderName);
            LockPosition(true);
            AppUIController.Instance.DisplayStopAnimationPanel(true);
		}

	}

	void OnTriggerExit(Collider other)
	{
		if (!isAnimationObject(other.gameObject)) { return; }

		Debug.Log("OnTriggerExit: " + other.gameObject.name);
		animator.runtimeAnimatorController = Resources.Load("animations/mainZiv") as RuntimeAnimatorController;

		if (audioController.IsAnimationAudioPlaying()) {
            audioController.PauseAnimationAudio();
		}

		LockPosition(false);
		ResetCurrentCollidedObject();
        AppUIController.Instance.DisplayStopAnimationPanel(false);
	}

	public void moveToStartPosition(GameObject startPoint)
	{
		transform.position = startPoint.transform.position;
		transform.rotation = startPoint.transform.rotation;
		animator.runtimeAnimatorController = Resources.Load("animations/mainZiv") as RuntimeAnimatorController;
		LockPosition(false);
		ResetCurrentCollidedObject();
	}

	public void LockPosition(bool isLock){
		isLocked = isLock;
	} 

	public bool IsLocked() {
		return isLocked;
	}

	public void ResetCurrentCollidedObject() {
        if (AppManager.Instance.isLostTracking) { return; }
		currentCollidedObject = null;
	}

	public void PauseAnimation() {
		animator.runtimeAnimatorController = Resources.Load("animations/mainZiv") as RuntimeAnimatorController;
        if (audioController.IsAnimationAudioPlaying())
        {
            audioController.PauseAnimationAudio(); 
        }
	}

	public void PauseOnLostTrackinAnimation()
	{
		//Debug.Log("PauseBeforeLostTrackinAnimation");
	}

	public void ResumeOnLostTrackingAnimation()
	{
		if (currentCollidedObject == null) { return; }

		GameObject go = currentCollidedObject;
		SetUpUserPosition(go);
		StartAnimation(go);
	} 

	public void SetMovingState(bool isDragging) 
    {
		isMovingTracking = isDragging;
	}

	public bool IsMovingState()
	{
		return isMovingTracking;
	}
}
