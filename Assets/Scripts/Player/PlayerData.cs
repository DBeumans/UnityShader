using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour {

    private static float playerWeight;
    public static float PlayerWeight
    {
        get { return playerWeight; }
        set
        {
            if (value > 0.3f)
                return;
            playerWeight = value;
        }
    }

    private static GameObject activeItem;
    public static GameObject ActiveItem
    {
        get { return activeItem; }
        set
        {
            if (value == null)
                return;
            activeItem = value;
        }
    }
    
}
