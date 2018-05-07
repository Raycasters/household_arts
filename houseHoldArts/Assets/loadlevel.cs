using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loadlevel : MonoBehaviour {


	void Start(){
		StartCoroutine("Wait");

	}

	IEnumerator Wait()
	{
		yield return new WaitForSeconds(4);

		UnityEngine.SceneManagement.SceneManager.LoadScene (1);	




	}
}