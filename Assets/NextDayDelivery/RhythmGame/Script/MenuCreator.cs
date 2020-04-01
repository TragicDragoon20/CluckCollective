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
        Instantiate(menu);
    }
}
