using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class MinigameHandler : MonoBehaviour
{
    public bool destroy = false;
    private int spawnTotal = 0;
    public GameObject minigame;
    private GameObject test;
    void Interact()
    {
        spawnTotal += 1;
        if (spawnTotal == 1)
        {
            test = (GameObject)Instantiate(minigame, gameObject.transform);
        }
    }

    void Update()
    {
        if(destroy == true)
        {
            Destroy(test);
            spawnTotal = 0;
        }
    }
}