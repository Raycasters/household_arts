using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TapHelper {
    
    public static bool IsZivMoving(GameObject ziv)
    {

        if (ziv == null) {
            return false;
        }
        return ziv.GetComponent<Ziv>().IsMovingState();
    }

    public static bool isAnimationPlays()
    {
        return AnimationHelper.IsAnimationActive();
    }

}
