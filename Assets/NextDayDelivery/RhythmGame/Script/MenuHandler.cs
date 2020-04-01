using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    public int levelNo;
    public GameObject minigameHandler;
    public void createMinigame()
    {
        levelNo = Convert.ToInt32(this.name);
        Instantiate(minigameHandler);
    }
}