using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Climb : MonoBehaviour
{
    public GameObject player;

    public GameObject bottom;
    public GameObject top;

    public bool atBottom = false;
    public bool atTop = false;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            if(atBottom)
            {
                player.transform.position = top.transform.position;
                atBottom = false;
            }

            if(atTop)
            {
                player.transform.position = bottom.transform.position;
                atTop = false;
            }
            
            else
            {

            }
        }
    }
}
