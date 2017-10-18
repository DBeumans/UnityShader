using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    
    private Renderer rend;

    [SerializeField]
    private float amount;

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        if (amount >= 0.05)
            return;
        amount = rend.material.GetFloat("_Amount");
        amount += 0.001f;
        rend.material.SetFloat("_Amount", amount);
        
    }
}
