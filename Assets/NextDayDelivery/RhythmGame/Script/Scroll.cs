using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private float speed = 1;
    void Update()
    {
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2((Time.time * (speed/3)) % 1, 0f);
    }
}
