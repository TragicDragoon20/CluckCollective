using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    FMOD.Studio.EventInstance Audiooo;
    public int counter = 0;
    public int fail = 4;
    public GameObject note;
    private string[][] levels = new string[][] { new[] { "z","space", "v", "space", "f", "space", "j", "space", "u", "space", "p" },
        new[] { "s", "h", "r", "e", "k", },
        new[] { "s", "h", "r", "e", "k", "2" },
        new[] { "s", "h", "r", "e", "k", "3" },
        new[] { "s", "h", "r", "e", "k", "4" } }; //A multidimentional string array that's output by the spawner. The new[] before each array allows them to be of any length.

    private float[][] levelTimes = new float[][] { new[] {3f,7,2,3,3,3,3,2,2,3,9}, //Each number in this array represents the amount of time between each note. Each number is in seconds /10 - so 3 is 0.3 seconds.
        new[] {5,2,1,7,5f},
        new[] {5,2,1,7,5f},
        new[] {5,2,1,7,5f},
        new[] {5,2,1,7,5f} };
    public int level; //Must be replaced with an int that actually represents the level number

    void Awake()
    {
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
        Audiooo = FMODUnity.RuntimeManager.CreateInstance("event:/Audiooo");
        Audiooo.setParameterByName("Section", 2);
        Audiooo.start();
        Audiooo.setPaused(true);
    }

    void Update()
    {
        Audiooo.setParameterByName("Success Level", fail);
        if (fail == 0)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            this.GetComponentInParent<MinigameHandler>().destroy = true;
        }

        if (counter == levels[(level)].Length)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
            Debug.Log("Congrats!");
            this.GetComponentInParent<MinigameHandler>().destroy = true;
        }
    }

    IEnumerator LevelTiming() //Lanuches a time sensitive function
    {
        for (int i = 0; i < levels[(level)].Length; i++) // for each item in the chosen level
        {
            if(counter >= 0)
            {
                levelTimes[level][i] *= 0.1f;
            }
            if (counter == 1)
            {
                Audiooo.setPaused(false);
            }
            Debug.Log(levelTimes[level][i]);
            note.GetComponent<Keypress>().keyType = (levels[level][i]); //Sets the keytype of the note to the current item in the array
            Instantiate(note, gameObject.transform); //instantiates each note
            yield return new WaitForSeconds(levelTimes[level][i]); //Waits for an amount of time specified by the time array and divides it by 10, to allow much quicker times to be allowed.
        }
    }
}