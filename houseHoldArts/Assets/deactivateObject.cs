using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deactivateObject : MonoBehaviour {
	public GameObject objectTohide;
	// Use this for initialization
	public  float timetowaitObject1;

	void Start () {
		StartCoroutine(hideObject1(timetowaitObject1));
	}
	
	// Update is called once per frame
	void Update () {
		
		
	}
	IEnumerator hideObject1(float waitfor){
		yield return new WaitForSeconds(waitfor);
		objectTohide.SetActive (false);

	}
}
