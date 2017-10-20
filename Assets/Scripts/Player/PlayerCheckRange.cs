using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script will check from the player which items are near the player.
/// All the items within a certain range will be saved in a array ( list ).
/// The script will set the closest item to the player as the active item that you will be able in the PlayerData script ( PlayerData.ActiveItem ).
/// </summary>
public class PlayerCheckRange : MonoBehaviour {

    [SerializeField]
    private float range;
    public float Range { get { return range; } }

    [SerializeField]
    private List<GameObject> itemsInRange = new List<GameObject>();

    private void Update()
    {
        sphereCast();
        checkItemDistance();
    }

    /// <summary>
    /// Check which item is the closest to the player.
    /// </summary>
    /// <param name="obj"></param>
    private void checkItemDistance()
    {
        GameObject currentActiveObject;
        currentActiveObject = PlayerData.ActiveItem;

        for (int i = 0; i < itemsInRange.Count; i++)
        {

            if (!CheckRange(this.gameObject, itemsInRange[i], range))
            {
                if (itemsInRange[i] == null)
                    return;
                DeleteItem(itemsInRange[i]);
                return;
            }

            if (currentActiveObject == null)
            {
                currentActiveObject = itemsInRange[i];
                PlayerData.ActiveItem = currentActiveObject;
                return;
            }

            if(getDistance(currentActiveObject) > getDistance(itemsInRange[i]))
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

        colliders = Physics.OverlapSphere(this.transform.position + Vector3.up, range, LayerMask.NameToLayer("Items"));
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

    public void DeleteItem(GameObject obj)
    {
        for (int i = 0; i < itemsInRange.Count; i++)
        {
            if (obj.name != itemsInRange[i].name)
                break;
            itemsInRange.Remove(obj);
        }
    }

    /// <summary>
    /// Returns true if the object is within the range from the position of the player.
    /// </summary>
    /// <param name="objA"></param>
    /// <param name="objB"></param>
    /// <param name="_range"></param>
    /// <returns></returns>
    public bool CheckRange(GameObject objA, GameObject objB, float _range)
    {
        if (objA == null || objB == null)
            return false;
        float distance;

        distance = Vector3.Distance(objA.transform.position, objB.transform.position);

        if (distance <= _range)
            return true;

        return false;
    }

    /// <summary>
    /// Get the distance in float.
    /// </summary>
    /// <param name="obj"></param>
    /// <returns></returns>
    private float getDistance(GameObject obj)
    {
        float distance;

        distance = Vector3.Distance(this.transform.position, obj.transform.position);

        return distance;
    }
}
