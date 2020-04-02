using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public Canvas menu;
    void Interact()
    {
        Camera.main.GetComponent<MouseLook>().enabled = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Instantiate(menu);
    }
}