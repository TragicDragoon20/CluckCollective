using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ShutterDoor door;
    public bool activate;

    void update()
    {
        if(activate = true)
        {
            door.open();
        }
    }
}
