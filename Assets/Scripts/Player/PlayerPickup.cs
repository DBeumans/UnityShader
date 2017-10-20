using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

    private InteractionText interactionText;

    private PlayerCheckRange playerCheckRange;

    private void Start()
    {
        playerCheckRange = GetComponent<PlayerCheckRange>();
        interactionText = FindObjectOfType<InteractionText>();
    }
    
    private void Update()
    {
        if (!playerCheckRange.CheckRange(this.gameObject, PlayerData.ActiveItem, playerCheckRange.Range/3))
        {
            interactionText.SetText("");
            return;
        }
        interactionText.SetText("Press E to eat " + PlayerData.ActiveItem);

        checkInput();
        
    }

    private void checkInput()
    {
        if (!InputManager.Get_Key_E)
            return;

        PlayerIncreaseWeight.WeightEvent();
    }
}
