using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameHandler : MonoBehaviour
{
    private Vector3 angles;
    private Camera minigameCam;
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
            test = (GameObject)Instantiate(minigame, MGLocation, Quaternion.Euler(angles), gameObject.transform);
            minigameCam = test.transform.Find("Camera").GetComponent<Camera>();
            spawnTotal += 1;
        }
    }

    void Update()
    {
        Debug.Log(spawnTotal);
        if (test != null)
        {
            if (minigameCam.enabled != true)
            {
                minigameCam.enabled = true;
            }
            if (test.GetComponentInChildren<Spawner>().destroy == true)
            {
                spawnTotal = 0;
                minigameCam.enabled = false;
                Destroy(test);
            }
        }
    }
}