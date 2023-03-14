using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ExtensionMethods;

public class IsInsideTest : MonoBehaviour
{
    public Collider2D col;
    public Transform target;

    private void Update()
    {
        if (col.IsPointInside(target.position))
        {
            Debug.Log("Inside!");
        }
        else
        {
            Debug.Log("Outside!");
        }
    }
}
