using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

    private InteractionText interactionText;

    /// <summary>
    /// Is the player in a item ?
    /// </summary>
    private bool inItem;

    private void Start()
    {
        interactionText = FindObjectOfType<InteractionText>();
    }

    private void Update()
    {
        if (!inItem)
            return;

        if (!InputManager.Get_Key_E)
            return;


        PlayerIncreaseWeight.WeightEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "pickup")
        {
            interactionText.SetText("Press E to eat " + other.name);            
            inItem = true;
            PlayerData.ActiveItem = other.gameObject;
        }
    }

    private void OnTriggerExit()
    {
        interactionText.SetText("");
        inItem = false;
    }
}
