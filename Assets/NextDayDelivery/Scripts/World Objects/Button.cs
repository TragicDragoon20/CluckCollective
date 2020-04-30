using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public ShutterDoor shutter;
    public DoorRegular regular;
    public bool activate = false;

    void Update()
    {
        if (activate == true)
        {
            if (regular != null)
            {
                regular.Locked = false;
            }

            if (shutter != null)
            {
                shutter.open();
            }
        }
    }
}
