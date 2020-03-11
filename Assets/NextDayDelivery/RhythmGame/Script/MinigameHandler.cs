using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class MinigameHandler : MonoBehaviour
{
    FMOD.Studio.EventInstance Audiooo;
    public GameObject minigame;
    private Fail fail;
    void Interact()
    {
        Instantiate(minigame, gameObject.transform);
        Audiooo = FMODUnity.RuntimeManager.CreateInstance("event:/Audiooo");
        Audiooo.start();
        Audiooo.setParameterByName("Section", 2);
    }
    void Update()
    {
        fail = GameObject.FindObjectOfType<Fail>();
        Audiooo.setParameterByName("Success Level", fail.failLevel);
        if (fail.failLevel == 0)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Destroy(gameObject);
        }
    }
}