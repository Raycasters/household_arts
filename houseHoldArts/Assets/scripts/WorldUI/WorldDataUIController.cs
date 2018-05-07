using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WorldDataUIController : MonoBehaviour {


    public Text txtTitle;
    public Text txtDetails;

    private static WorldDataUIController _instance;
    public static WorldDataUIController Instance { get { return _instance; } }


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

    public void UpateUI(WorldUI worldUI){
        UpdateText(worldUI);
    }

    void UpdateText(WorldUI worldUI) {
        if (txtTitle == null) { return; }
        txtTitle.text = worldUI.title;

        if (txtDetails == null) { return; }
        txtDetails.text = worldUI.details;
    }

    public void StartAnimation() {
        Animator animator = gameObject.GetComponent<Animator>();
        animator.Play(animator.name);
    }
}
