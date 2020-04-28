﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMOD;
using System;
using UnityEditor;

public class Spawner : MonoBehaviour
{
    FMOD.Studio.EventInstance Audiooo;
    public int level;
    public bool destroy = false;
    public int counter = 0;
    public int fail = 4;
    public GameObject note;
    private string[][] levels = new string[][] { new string[] { "z","space", "v", "space", "f", "space", "j", "space", "u", "space", "p" },
        new string[] { "s", "h", "r", "e", "k", "s", "h", "r"},
        new string[] { "2", "h", "r", "e", "k", "2" },
        new string[] { "s", "h", "r", "e", "k", "3" },
        new string[] { "s", "h", "r", "e", "k", "4" } }; //A multidimentional string array that's output by the spawner. The new[] before each array allows them to be of any length.

    private float[][] levelTimes = new float[][] { new float[] {3f,7f,2,3,3,3,2,2,2,3,9}, //Each number in this array represents the amount of time between each note. Each number is in seconds /10 - so 3 is 0.3 seconds.
        new float[] {3f,12f,2,3,3,3,2,2,5},
        new float[] {5f,2,1,7,5,2},
        new float[] {5f,2,1,7,5},
        new float[] {5f,2,1,7,5f} };

    void Awake()
    {

        level = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuHandler>().e;
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
        Audiooo = FMODUnity.RuntimeManager.CreateInstance("event:/Audiooo");
        Audiooo.setParameterByName("Section", level+1);
        Audiooo.start();
        Audiooo.setPaused(true);
    }

    void Update()
    {
        UnityEngine.Debug.Log(level);
        Audiooo.setParameterByName("Success Level", fail);
        if (fail == 0)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Audiooo.release();
            destroy = true;
        }

        if (counter == levels[level].Length)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Audiooo.release();
            UnityEngine.Debug.Log("Congrats!"); //here use varying effects based off of the level value. EG if you beat level 1, then effect no 1 will happen which should be opening the door. Maybe create a nested array of effects like the level and timing arrays?
            GameObject.Find("1").GetComponent<StartGame>().victory = 1;
            destroy = true;
        }
    }

    IEnumerator LevelTiming() //Lanuches a time sensitive function
    {
        for (int i = 0; i < levels[level].Length; i++) // for each item in the chosen level
        {
            if(counter >= 0)
            {
                levelTimes[level][i] *= 0.1f;
            }
            if (counter == 1)
            {
                Audiooo.setPaused(false);
            }
            note.GetComponent<Keypress>().keyType = (levels[level][i]); //Sets the keytype of the note to the current item in the array
            Instantiate(note, gameObject.transform); //instantiates each note
            yield return new WaitForSeconds(levelTimes[level][i]); //Waits for an amount of time before spawing the next note specified by the time array and divides it by 10, to allow much quicker times to be allowed.
        }
    }
}