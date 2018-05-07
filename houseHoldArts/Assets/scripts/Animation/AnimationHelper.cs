using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AnimationHelper
{

    public static string GetAnimationName(string goName)
    {

        // Living room - class1
        if (goName == Constants.Objects.Piano)
        {
            return Constants.Animations.piano;
        }
        else if (goName == Constants.Objects.Armchair)
        {
            return Constants.Animations.armchair;
        }
        else if (goName == Constants.Objects.Fireplace)
        {
			return Constants.Animations.fireplace;
        }


        // class 2
        else if (goName == Constants.Objects.Bath)
        {
            return Constants.Animations.bath;
        }
        else if (goName == Constants.Objects.Sink)
        {
            return Constants.Animations.sink;
        }
        else if (goName == Constants.Objects.Toilet)
        {
            return Constants.Animations.toilet;
        }

        // class 3
        else if (goName == Constants.Objects.crib)
        {
            return Constants.Animations.crib;
        }
        else if (goName == Constants.Objects.dresser)
        {
            return Constants.Animations.dresser;
        }
        else if (goName == Constants.Objects.PlayArea)
        {
            return Constants.Animations.playArea;
        }

        // class 4
        else if (goName == Constants.Objects.closet)
        {
            return Constants.Animations.closet;
        }
        else if (goName == Constants.Objects.pictures)
        {
            return Constants.Animations.pictures;
        }
        else if (goName == Constants.Objects.Bed)
        {
            return Constants.Animations.bed;
        }

        // class 4
        else if (goName == Constants.Objects.dinnerTable)
        {
            return Constants.Animations.dinnerTable;
        }
        else if (goName == Constants.Objects.range)
        {
            return Constants.Animations.range;
        }
        else if (goName == Constants.Objects.broom)
        {
            return Constants.Animations.broom;
        }

        return null;
    }


    public static bool IsAnimationActive() {
        return AudioController.Instance.IsAnimationAudioPlaying();
    }

    public static void StartInitialAnimation()
    {
        GameObject character = SceneManager.Instance.getCharacter();
        Debug.Log("StartInitialAnimation");

        if (character == null) { return; }
        Debug.Log("character not null");
        if (character.GetComponent<Ziv>() == null) { return; } 
        Debug.Log("character.GetComponent<Ziv> not null");

        int sceneId = SceneManager.Instance.sceneId;
        switch (sceneId)
        {
            case (int)Scenes.Intro:
                character.GetComponent<Ziv>().assignAnimator("animations/mainZiv_intro");
                break;
            case (int)Scenes.LivingRoom:
                break;
            case (int)Scenes.BathRoom:
                character.GetComponent<Ziv>().assignAnimator("animations/introBathroom");
                break;
            case (int)Scenes.Nursery:
                break;
            case (int)Scenes.BedRoom:
                break;
            case (int)Scenes.Kitchen:
                break;
            default:
                break;
        }

    }

}