using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ShutterDoor door;
    public bool activate = false;

    void Update()
    {
        if (activate == true)
        {
            door.open();
        }
    }
}
