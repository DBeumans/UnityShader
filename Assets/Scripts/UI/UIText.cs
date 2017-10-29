using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIText : MonoBehaviour {

    [SerializeField]
    private Text interaction_text;

    [SerializeField]
    private Text notification_text;

    private void Start()
    {
        interaction_text.text = "";
        notification_text.text = "";
    }

    public void SetInteractionText(string text)
    {
        interaction_text.text = text;
    }

    public void SetNotificationText(string text)
    {
        notification_text.text = text;
    }
}
