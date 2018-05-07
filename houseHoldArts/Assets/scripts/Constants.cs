using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Constants {

    // Rooms
    public struct Rooms
    {
        public const string livingRoom = "livingroom";
        public const string bathRoom = "bathroom";
    }

    public struct Promt {
        public const string pointCamera = "point the camera at a floor plan";
        public const string doubleTap = "";
        public const string animationUnlocked = "unlocked";
    }

    public struct SceneNames
    {
        public const string intro = "Scene1_ImageTarget";
        public const string livingroom = "Scene2_LivingRoom_ImageTarget";
        public const string bathroom = "Scene3_Bathroom_imagetarget";
        public const string nursery = "Scene4_Nursery_imagetarget";
        public const string bedroom = "Scene5_Bedroom_imagetarget";
        public const string kitchen = "Scene6_KitchenandDiningRoom_ImageTarget";
    }

    //ANIMATIONS = Resources animations names
    // Living room
    public struct Animations {
        //class one
        public const string piano = "piano"; //"ziv_piano";
        public const string armchair = "armchair"; //"zivCouch";
        public const string fireplace = "fireplace";

        //class two
        public const string sink = "sink";  
        public const string bath = "bath"; 
        public const string toilet = "toilet";

        //class three
        public const string crib = "crib";
        public const string dresser = "dresser";
        public const string playArea = "play area";

        //class four
        public const string closet = "closet";
        public const string pictures = "pictures";
        public const string bed = "bed";

        //class five
        public const string dinnerTable = "dinnerTable";
        public const string range = "range";
        public const string broom = "broom";

    }


    //AUDIO = AudioManager -> AudiouSources
    public struct Audio
    {
        public const string audioPiano = "Piano";
        public const string audioArmChair = "ArmChair";
        public const string audioFirePlace = "Fireplace";
	
    }

    //The objects' names which character touch to play animation
    public struct Objects
    {
        //class 1
        public const string Piano = "Piano";
        public const string Armchair = "armchair";
        public const string Fireplace = "fireplace";
     

        //TODO: recheck the names for all scenes
        //class 2
        public const string Sink = "sink";
        public const string Bath = "bathtub";
        public const string Toilet = "toilet";

        //class 3
        public const string crib= "crib";
        public const string dresser = "dresser";
        public const string PlayArea = "playarea";

        //class 4
        public const string closet = "closet";
        public const string pictures = "pictures";
        public const string Bed = "bed";

        //class five
        public const string dinnerTable = "dinnerTable";
        public const string range = "range";
        public const string broom = "broom";

        public const string Couch = "couch";
    }

    // world UI data
    public const string dataPath = "MockData/worldUI";

}
