using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public DoorRegular regular;
    public DroppingObjects light;
    public ShutterDoor shutter;
    public bool activate = false;

    void Update()
    {
        if (activate == true)
        {
            //someone add the terminal change to success screen here
            if (regular != null)
            {
                regular.Locked = false;
            }

            if (shutter != null)
            {
                shutter.open();
            }

            if (light != null)
            {
                light.canDrop = true;
            }
        }
    }
}
