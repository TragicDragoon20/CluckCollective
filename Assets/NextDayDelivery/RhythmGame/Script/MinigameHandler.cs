using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class MinigameHandler : MonoBehaviour
{
    private Vector3 angles;
    private Camera minigameCam;
    public bool destroy = false;
    private int spawnTotal = 0;
    public GameObject minigame;
    private GameObject test;
    Vector3 MGLocation;
    void Interact()
    {
        Vector3 newRotate = new Vector3(0, 180, 0);
        angles = transform.rotation.eulerAngles;
        angles = newRotate;
        MGLocation = new Vector3(0, -50, 0);
        spawnTotal += 1;
        if (spawnTotal == 1)
        {
            test = (GameObject)Instantiate(minigame, MGLocation, Quaternion.Euler(angles));
            minigameCam = minigame.transform.Find("Camera").GetComponent<Camera>();
            minigameCam.enabled = true;
        }
    }

    void Update()
    {
        if(destroy == true)
        {
            minigameCam.enabled = false;
            Destroy(test);
            spawnTotal = 0;
        }
    }
}