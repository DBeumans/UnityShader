using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum itemType
{
    good,
    bad
}

public class Item : MonoBehaviour{

    [SerializeField]
    private string name;
    public string Name { get { return name; } }

    [SerializeField]
    private float calories;
    public float Calories { get { return calories; } }

    [SerializeField]
    private itemType type;
    public itemType Type { get { return type; } }

}
