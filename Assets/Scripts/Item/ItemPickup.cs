using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemPickup : MonoBehaviour {

    public static Action<GameObject> ItemPickupEvent;

    private void Start()
    {
        ItemPickupEvent += destroyItem;
    }

    private void destroyItem(GameObject obj)
    {
        Destroy(obj);
    }
}
