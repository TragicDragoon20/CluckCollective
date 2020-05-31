using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public GameObject minigameHandler;
    public int levelToSpawn;
    public string terminalName;

    public void CreateMinigame()
    {
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
    }

    IEnumerator LevelTiming()
    {
        yield return new WaitForSeconds(1);
        Instantiate(minigameHandler);
        GameObject.Find("Spawner").GetComponent<Spawner>().terminal = this.GetComponentInParent<MenuHandler>().attatchedTerminal;
        GameObject.Find("Spawner").GetComponent<Spawner>().level = levelToSpawn;
        Destroy(GameObject.FindGameObjectWithTag("Menu"));
    }


}