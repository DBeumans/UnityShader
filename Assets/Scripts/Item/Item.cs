using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour{

    [SerializeField]
    private string item_name;
    public string Name { get { return item_name; } }

    [SerializeField]
    private float calories;
    public float Calories { get { return calories; } }

}
