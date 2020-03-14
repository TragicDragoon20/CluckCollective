using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FMOD;

public class MinigameHandler : MonoBehaviour
{
    public GameObject minigame;
    void Interact()
    {
        Instantiate(minigame, gameObject.transform);
    }

}