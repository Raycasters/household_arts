using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UserInactivityHelper: MonoBehaviour {

    private const float maxUserInactiveTime = 180; //300;
    private static float inactiveSeconds = 0;
    private static bool isUserActivityTracking = false;

    public static void UpdateTime()
    {
 
    }

    public static void ResetInactiveTime()
    {
        inactiveSeconds = 0;
    }

    public static void IncreaseInactiveTime()
    {
        if (!isUserActivityTracking) { return; }
        inactiveSeconds += Time.deltaTime;
    }

    public static void StartUserActivityTracking()
    {
        inactiveSeconds = 0;
        isUserActivityTracking = true;
    }

    public static void StopUserActivityTracking()
    {
        inactiveSeconds = 0;
        isUserActivityTracking = false;
    }

    //If Alive functional
    public static void IfAchievedInactiveLimit()
    {
        if (inactiveSeconds >= maxUserInactiveTime)
        {
            Achievements.Instance.ResetAchievements();
        }
    }

}
