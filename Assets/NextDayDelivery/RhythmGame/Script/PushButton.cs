using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public GameObject minigameHandler;

    public void CreateMinigame()
    {
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
    }

    IEnumerator LevelTiming()
    {
        GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuHandler>().e = Convert.ToInt32(gameObject.name);
        yield return new WaitForSeconds(2);
        Instantiate(minigameHandler);
        Destroy(GameObject.FindGameObjectWithTag("Menu"));
    }


}