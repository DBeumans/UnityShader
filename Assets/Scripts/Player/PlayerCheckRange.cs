using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script will check from the player which items are near the player.
/// All the items within a certain range will be saved in a array ( list ).
/// The script will set the closest item to the player as the active item.
/// </summary>
public class PlayerCheckRange : MonoBehaviour {

    [SerializeField]
    private float range;
    public float Range { get { return range; } }

    [SerializeField]
    private List<GameObject> itemsInRange = new List<GameObject>();

    private GameObject currentActiveObject;

    private void Start()
    {
        currentActiveObject = PlayerData.ActiveItem;
    }

    private void Update()
    {
        sphereCast();
        checkItemDistance();
    }

    /// <summary>
    /// Check which item is the closest to the player.
    /// </summary>
    private void checkItemDistance()
    {
        for (int i = 0; i < itemsInRange.Count; i++)
        {

            if (!Calculate.Range(this.gameObject, itemsInRange[i], range))
            {
                if (itemsInRange[i] != null)
                {
                    DeleteItem(false,itemsInRange[i]);
                    return;
                }
            }

            if (currentActiveObject == null)
            {
                currentActiveObject = itemsInRange[i];
                PlayerData.ActiveItem = currentActiveObject;
                return;
            }

            if(Calculate.Distance(this.gameObject,currentActiveObject) > Calculate.Distance(this.gameObject,itemsInRange[i]))
            {
                currentActiveObject = itemsInRange[i];
                PlayerData.ActiveItem = currentActiveObject;
            }

        }


    }

    /// <summary>
    /// Cast a sphere cast on the player.
    /// </summary>
    private void sphereCast()
    {
        Collider[] colliders;

        colliders = Physics.OverlapSphere(this.transform.position, range);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (!colliders[i].CompareTag("pickup"))
                return;

            addItem(colliders[i].gameObject);
        }
    }

    /// <summary>
    /// Add game object to the list.
    /// </summary>
    /// <param name="obj"></param>
    private void addItem(GameObject obj)
    {
        for (int i = 0; i < itemsInRange.Count; i++)
        {
            if (itemsInRange[i].gameObject == obj)
                return;
        }
        itemsInRange.Add(obj);
    }

    public void DeleteItem(bool checker, GameObject obj)
    {
        if(!checker)
        {
            itemsInRange.Remove(obj);
            return;
        }
        for (int i = 0; i < itemsInRange.Count; i++)
        {
            if(obj == itemsInRange[i] && obj == PlayerData.ActiveItem)
                itemsInRange.Remove(obj);
        }
       
    }


}
