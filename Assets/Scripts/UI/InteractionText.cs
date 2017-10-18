using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour {

    [SerializeField]
    private Text interaction_text;

    private void Start()
    {
        interaction_text.text = "";
    }

    public void SetText(string text)
    {
        interaction_text.text = text;
    }
}
