using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDoor : MonoBehaviour
{
    Animator anim;

    public bool Opened = false;
    public bool canOpen = false;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canOpen = false;
        }
    }

    public void Interact()
    {
        if (canOpen == true)
        {
            anim.SetBool("Open?", true);
            Opened = true;
        }

        else
        {

        }
    }
}
