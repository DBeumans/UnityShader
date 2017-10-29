using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickup : MonoBehaviour {

    private UIText canvasText;

    private PlayerCheckRange playerCheckRange;

    private void Start()
    {
        playerCheckRange = GetComponent<PlayerCheckRange>();
        canvasText = FindObjectOfType<UIText>();
    }
    
    private void Update()
    {
        if (!Calculate.Range(this.gameObject, PlayerData.ActiveItem, playerCheckRange.Range/3))
        {
            canvasText.SetInteractionText("");
            return;
        }

        Item currentItem = PlayerData.ActiveItem.GetComponent<Item>();
        if (currentItem == null)
            Debug.LogError("Error Couldnt get component <Item> of Active Item");

        canvasText.SetInteractionText("Press E to eat " + currentItem.Name);

        checkInput();
        
    }

    private void checkInput()
    {
        if (!InputManager.Get_Key_E)
            return;

        PlayerIncreaseWeight.WeightEvent();
    }
}
