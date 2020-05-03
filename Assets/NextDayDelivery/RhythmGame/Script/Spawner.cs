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
        new string[] { "space","f", "u", "j", "a", "f", "j", "l", "space", "v", "r"},
        new string[] { "v", "f", "f", "f", "h", "j","p", "q", "f", "m", "l", "e","u"},
        new string[] { "e", "space","v", "space", "e", "space", "v", "space", "e", "space", "v", "space", "e", "space", "v", "space", "e", "space", "v", "space", "e", "space", "v", "space", "e", "space", "v", "space", "e"},
        new string[] { "u", "space", "space", "u", "space", "u", "space", "q", "f", "j", "m", "v", "j", "p", "m"},
        new string[] {"n","u","l","l"},
        new string[] { "space","z", "f", "z", "v", "v", "m", "j", "l", "v", "r", "space", "space", "j", "l", "space", "q", "r", "space", "u", "p"},
        new string[] {"a", "v","j", "m", "r", "u", "f", "v", "z", "f", "j", "m", "a", "f", "v", "m", "l", "m"} };
    //A multidimentional string array that's output by the spawner.

    private float[][] levelTimes = new float[][] { new float[] {3f,7,16,13,9,13,4,11,10,10,10}, //Each number in this array represents the amount of time between each note. Each number is in seconds /10 - so 3 in this case is = 0.3 seconds.
        new float[] {20f,7f,12,3,12,7,6,7,19,4,15,3},
        new float[] {20f,3f,2,2,10,4,14,7,6,14,8,6,6},
        new float[] {3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3,3,4.85f,2,3},
        new float[] {3f,6,6,6,7,8,18,6,8,4,7,5,13,4,3},
        new float[] {1,1,1,1},
        new float[] {1.5f,6,9,5,8,5,1,4,8,5,3,7,5,2.5f,6,4.5f,3,5,4,4,6,5},
        new float[] {6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f, 6.5f}};

    void Awake()
    {

        level = GameObject.FindGameObjectWithTag("Menu").GetComponent<MenuHandler>().e;
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
        Audiooo = FMODUnity.RuntimeManager.CreateInstance("event:/Audiooo");
        Audiooo.setParameterByName("Section", level + 1);
        Audiooo.start();
        Audiooo.setPaused(true);
        Audiooo.setVolume(0.1f);
    }

    void Update()
    {
        Audiooo.setParameterByName("Success Level", fail);
        if (fail == 0)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            Audiooo.release();
            GameObject.Find((level + 1).ToString()).GetComponent<StartGame>().OnDefeat();
            destroy = true;
        }

        if (counter == levels[level].Length)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Audiooo.release();
            UnityEngine.Debug.Log("Congrats!"); //here use varying effects based off of the level value. EG if you beat level 1, then effect no 1 will happen which should be opening the door. Maybe create a nested array of effects like the level and timing arrays?
            GameObject.Find((level + 1).ToString()).GetComponent<StartGame>().OnVictory(); //CHANGE THIS SO 1 IS EQUAL TO WHATEVER THE LEVEL VALUE IS!
            destroy = true;
        }
        if (counter == 1)
        {
            Audiooo.setPaused(false);
        }
    }

    IEnumerator LevelTiming() //Lanuches a time sensitive function
    {
        for (int i = 0; i < levels[level].Length; i++) // for each item in the chosen level
        {
            if (counter >= 0)
            {
                levelTimes[level][i] *= 0.1f;
            }
            note.GetComponent<Keypress>().keyType = (levels[level][i]); //Sets the keytype of the note to the current item in the array
            Instantiate(note, gameObject.transform); //instantiates each note
            yield return new WaitForSeconds(levelTimes[level][i]); //Waits for an amount of time before spawing the next note specified by the time array and divides it by 10, to allow much quicker times to be allowed.
        }
    }
}