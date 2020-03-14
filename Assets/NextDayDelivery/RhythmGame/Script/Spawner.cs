using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner : MonoBehaviour
{
    FMOD.Studio.EventInstance Audiooo;
    public bool destroy = false;
    public int counter = 0;
    public int fail = 4;
    public GameObject note;
    private string[][] lvOne = new string[][] { new[] { "z","space", "v", "space", "f", "space", "j", "space", "u", "space", "p" },
        new[] { "s", "h", "r", "e", "k", },
        new[] { "s", "h", "r", "e", "k", "2" },
        new[] { "s", "h", "r", "e", "k", "3" },
        new[] { "s", "h", "r", "e", "k", "4" } }; //A multidimentional string array that's output by the spawner. The new[] before each array allows them to be of any length.
    public int level; //Must be replaced with an int that actually represents the level number

    void Awake()
    {
        StartCoroutine(LevelTiming()); //Allows the script to use WaitForSeconds
        Audiooo = FMODUnity.RuntimeManager.CreateInstance("event:/Audiooo");
        Audiooo.start();
        Audiooo.setParameterByName("Section", 2);
    }

    void Update()
    {
        UnityEngine.Debug.Log(counter);
        Audiooo.setParameterByName("Success Level", fail);
        if (fail == 0)
        {
            Audiooo.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            destroy = true;
        }

        if (counter == lvOne[(level)].Length)
        {
            Debug.Log("Congrats!");
            destroy = true;
        }
    }

    IEnumerator LevelTiming() //Lanuches a time sensitive function
    {
        for (int i = 0; i < lvOne[(level)].Length; i++) // for each item in the chosen level
        {
            note.GetComponent<Keypress>().keyType = (lvOne[(level)][i]); //Sets the keytype of the note to the current item in the array
            Instantiate(note, gameObject.transform); //instantiates each note
            yield return new WaitForSeconds(1 / 2f); //Waits for an amount
        }
    }
}