using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// This script contains functions to calculate things.
/// For example the distance between 2 objects / locations.
/// </summary>
public class Calculate : MonoBehaviour {

    /// <summary>
    /// Returns true if the object is within the range from the position of the player.
    /// </summary>
    /// <param name="objA"></param>
    /// <param name="objB"></param>
    /// <param name="_range"></param>
    /// <returns></returns>
    public static bool Range(GameObject objA, GameObject objB, float _range)
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
    public static float Distance(GameObject objA, GameObject objB)
    {
        float distance;

        distance = Vector3.Distance(objA.transform.position, objB.transform.position);

        return distance;
    }
}
