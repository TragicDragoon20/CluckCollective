using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : Spawner
{
    public GameObject minigameHandler;
    public int startSpawning = 0;
    public int level;

    public override void SetLevel()
    {
        base.SetLevel();
    }

    public void CreateMinigame()
    {
        SetLevel();
        Instantiate(minigameHandler);
    }
}