using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour {


	public Transform positionPoint;
	private Bounds _colliderBounds;
	public GameObject netsedObject;
	private Animator animator;

	// Use this for initialization
	void Start () {
		BoxCollider boxCollider = transform.GetComponent<BoxCollider>();
		_colliderBounds = boxCollider.bounds;
	}

	// Update is called once per frame
	void Update () {
        if (gameObject.name == Constants.Objects.Armchair)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("_read") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}
        if (gameObject.name == Constants.Objects.Fireplace)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("throw") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}

        if (gameObject.name == Constants.Objects.crib)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("peekaboo") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}
        if (gameObject.name == Constants.Objects.dresser)
        {
            if (animator != null)
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.IsName("holdbaby") && !isDisplayedNestedObject())
                {
                    DisplayNestedObject(true);
                }
            }
        }

        if (gameObject.name == Constants.Objects.closet)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("arrange") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
	    }
        if (gameObject.name == Constants.Objects.Bath)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("Idle") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}
        if (gameObject.name == Constants.Objects.pictures)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("hangpic") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}

        if (gameObject.name == Constants.Objects.dinnerTable)
		
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("placing") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}

        if (gameObject.name == Constants.Objects.range)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("cooking") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}
        if (gameObject.name == Constants.Objects.PlayArea)
		{
			if (animator != null)
			{
				AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
				if (stateInfo.IsName("sitplay") && !isDisplayedNestedObject())
				{
					DisplayNestedObject(true);
				}
			}
		}

   
	 
	}

	public Vector3 getPosition() {
		Vector3 newPlayerPos = new Vector3(positionPoint.position.x, positionPoint.position.y, positionPoint.position.z);
		return Vector3.MoveTowards(transform.position, newPlayerPos, 1);
	}

	public Quaternion getRotaton()
	{
		return positionPoint.transform.rotation;
	}

	public bool isDisplayedNestedObject()
	{
		if (netsedObject != null)
		{
			return false;
		}
		return netsedObject.activeSelf;
	}

	public void DisplayNestedObject(bool isShow) {
		if (netsedObject != null) {
			netsedObject.SetActive(isShow);
		} 
	}

	void OnTriggerEnter(Collider other)
	{
		GameObject go = other.gameObject;
		animator = go.GetComponent<Animator>();

        if (gameObject.name == Constants.Objects.broom)
        {
            DisplayNestedObject(false);
        }
	}
	void OnTriggerExit(Collider other)
	{
		DisplayNestedObject(false);

        if (gameObject.name == Constants.Objects.broom)
        {
            DisplayNestedObject(true);
        }
	}

	public bool IsAnimationDisabled()
	{
		string animName = AnimationHelper.GetAnimationName(gameObject.name);
		return Achievements.Instance.GetAchievement(animName);
	}
}
