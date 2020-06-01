using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    Material[] mats;

    public DoorRegular regular;
    public DroppingObjects light;
    public ShutterDoor shutter;
    public bool activate = false;
    public Material passmaterial;
    public GameObject terminal;

    void Update()
    {
        if (activate == true)
        {
            mats = terminal.GetComponent<Renderer>().materials;
            mats[1] = passmaterial;
            terminal.GetComponent<Renderer>().materials = mats;

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
