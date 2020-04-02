using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuCreator : MonoBehaviour
{
    public Canvas menu;
    // Start is called before the first frame update
    void Interact()
    {
        Camera.main.GetComponent<MouseLook>().enabled = false;
        Cursor.visible = true;
        Instantiate(menu);
    }
}
