using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ItemPickup : MonoBehaviour {

    public static Action<GameObject> ItemPickupEvent;

    private PlayerCheckRange playerCheckRange;

    private void Start()
    {
        ItemPickupEvent += destroyItem;

        playerCheckRange = FindObjectOfType<PlayerCheckRange>();
    }

    private void destroyItem(GameObject obj)
    {
        playerCheckRange.DeleteItem(true,obj);
        Destroy(obj);
    }
}
