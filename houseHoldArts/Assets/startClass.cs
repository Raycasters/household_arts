using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startClass : MonoBehaviour {

	public GameObject SeeYouCanvas;
	// Use this for initialization

	void Start () {
		SeeYouCanvas.SetActive (false);
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider Coll)
	{
		if (Coll.gameObject.tag == "ziv"){
			SeeYouCanvas.SetActive (true);
	}
}
}
