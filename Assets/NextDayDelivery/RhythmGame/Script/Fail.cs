using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fail : MonoBehaviour
{

    public int failLevel = 4;

    void OnTriggerEnter2D(Collider2D note) //If anything collides with the object
    {
        failLevel -= 1;
        Debug.Log(failLevel);
    }
}