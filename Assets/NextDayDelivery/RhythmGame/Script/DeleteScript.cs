using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteScript : MonoBehaviour
{
    void Update()
    {
        if (this.GetComponentInChildren<Spawner>().destroy == true)
        {
            Destroy(this);
        }
    }
}
