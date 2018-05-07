using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtMe : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //Look At Camera
         transform.LookAt(Camera.main.transform);
         transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
	}
}
