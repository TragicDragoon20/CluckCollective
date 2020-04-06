using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Canvas menu;
    void Interact()
    {
        //Insert way to turn off interact script, freeze wasd movement and stop enemy AI. Re-enable AI once game starts and everything else once game ends. Do this using the spawner script
        Camera.main.GetComponent<MouseLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Instantiate(menu);
    }
}