using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public GameObject spawner;
    public GameObject minigameHandler;
    public int startSpawning = 0;
    public int levelNo;
    public void createMinigame()
    {
        levelNo = Convert.ToInt32(gameObject.name);
        minigameHandler.GetComponent<MinigameHandler>().test = levelNo;
        Debug.Log(minigameHandler.GetComponent<MinigameHandler>().test);
        Instantiate(minigameHandler);

    }
}