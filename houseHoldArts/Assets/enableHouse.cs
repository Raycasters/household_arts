using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableHouse : MonoBehaviour {

	public GameObject objectToshow;
	public GameObject objectToshow2;
	public GameObject objectToshow3;
	public GameObject objectToshow4;
	public GameObject objectToshow5;
	public GameObject objectToshow6;
	public GameObject objectToshow7;
	public GameObject objectToshow8;



	// Use this for initialization
	public  float timetowaitforObject;
	public  float timetowaitforObject2;
	public  float timetowaitforObject3;
	public  float timetowaitforObject4;
	public  float timetowaitforObject5;
	public  float timetowaitforObject6;
	public  float timetowaitforObject7;
	public  float timetowaitforObject8;


	public void Start() 
	{
		
		StartCoroutine(showObject1(timetowaitforObject));
		StartCoroutine(showObject2(timetowaitforObject2));
		StartCoroutine(showObject3(timetowaitforObject3));
		StartCoroutine(showObject4(timetowaitforObject4));
		StartCoroutine(showObject5(timetowaitforObject5));
		StartCoroutine(showObject6(timetowaitforObject6));
		StartCoroutine(showObject7(timetowaitforObject7));
		StartCoroutine(showObject8(timetowaitforObject8));


	}

	// Update is called once per frame
	void Update () {

	}

	IEnumerator showObject1(float waitfor){
		objectToshow.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow.SetActive (true);

	}

	IEnumerator showObject2(float waitfor){
		objectToshow2.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow2.SetActive (true);

	}
	IEnumerator showObject3(float waitfor){
		objectToshow3.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow3.SetActive (true);

	}

	IEnumerator showObject4(float waitfor){
		objectToshow4.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow4.SetActive (true);

	}


	IEnumerator showObject5(float waitfor){
		objectToshow5.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow5.SetActive (true);

	}

	IEnumerator showObject6(float waitfor){
		objectToshow6.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow6.SetActive (true);

	}

	IEnumerator showObject7(float waitfor){
		objectToshow7.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow7.SetActive (true);

	}
	IEnumerator showObject8(float waitfor){
		objectToshow8.SetActive(false);
		yield return new WaitForSeconds(waitfor);
		objectToshow8.SetActive (true);

	}
}