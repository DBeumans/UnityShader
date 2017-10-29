using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerIncreaseWeight : MonoBehaviour {
    
    private Renderer[] materials;

    [SerializeField]
    private float currentWeight;

    [SerializeField]
    private float max_weight;

    private float amount;

    public static Action WeightEvent;

    private UIText canvasText;
    
    private void Start()
    {
        canvasText = FindObjectOfType<UIText>();
        materials = GetComponentsInChildren<Renderer>();
        WeightEvent += addWeight;
        
    }

    private void addWeight()
    {
        if (currentWeight >= max_weight)
        {
            canvasText.SetNotificationText("<color=red> You're to fat ! </color>");
            return;
        }

        GameObject go = PlayerData.ActiveItem;
        Item goItem = go.GetComponent<Item>();

        if (goItem == null)
            Debug.LogError("Please add Item script to " + go.name);

        amount = goItem.Calories;

        for (int i = 0; i < materials.Length; i++)
        {
            Material mat = materials[i].material;

            currentWeight = mat.GetFloat("_Amount");
            currentWeight += amount;
            mat.SetFloat("_Amount", currentWeight);
            PlayerData.PlayerWeight = currentWeight;
        }

        ItemPickup.ItemPickupEvent(PlayerData.ActiveItem);
    }
}
