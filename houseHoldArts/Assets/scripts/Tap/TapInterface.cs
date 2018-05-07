using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface TapInterface {

    // Update is called once per frame
    void ObserveTap();

    void PerformAction(string objectName);


    //private bool IsZivMoving()
    //{
    //    return GameObject.FindGameObjectsWithTag("ziv")[0].GetComponent<Ziv>().IsMovingState();
    //}

    //private bool isAnimationPlays()
    //{
    //    return AnimationHelper.IsAnimationActive();
    //}
}
