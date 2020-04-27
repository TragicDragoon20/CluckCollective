using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushButton : MonoBehaviour
{
    public GameObject minigameHandler;

    public void CreateMinigame()
    {
        GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuHandler>().e = Convert.ToInt32(gameObject.name);
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
    }

    IEnumerator LevelTiming()
    {

        yield return new WaitForSeconds(1);
        Instantiate(minigameHandler);
        Destroy(GameObject.FindGameObjectWithTag("Menu"));
    }


}