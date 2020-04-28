using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class StartGame : MonoBehaviour
{
    private int counter = 0;
    public int victory = 0;
    public Canvas menu;
    void Interact()
    {
        if(counter == 0)
        {
            MonoBehaviour[] playerScripts = GameObject.Find("Player").GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in playerScripts)
            {
                script.enabled = false;
            }
            MonoBehaviour[] canvasScripts = GameObject.Find("Canvas").GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in canvasScripts)
            {
                script.enabled = false;
            }

            //Insert way to turn off interact script, freeze wasd movement and stop enemy AI. Re-enable AI once game starts and everything else once game ends. Do this using the spawner script
            Camera.main.GetComponent<MouseLook>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Instantiate(menu);
            counter += 1;
        }
        if(victory == 1)
        {
            MonoBehaviour[] playerScripts = GameObject.Find("Player").GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in playerScripts)
            {
                script.enabled = true;
            }
            MonoBehaviour[] canvasScripts = GameObject.Find("Canvas").GetComponents<MonoBehaviour>();
            foreach (MonoBehaviour script in canvasScripts)
            {
                script.enabled = true;
            }
            Camera.main.GetComponent<MouseLook>().enabled = true;
            Cursor.lockState = CursorLockMode.Locked;
            GetComponent<Button>().activate = true;
            Cursor.visible = false;
            Input.GetMouseButtonDown(1);
        }
    }
}