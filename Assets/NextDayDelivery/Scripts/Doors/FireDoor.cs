﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireDoor : MonoBehaviour
{
    Animator anim;
    //bool Opening;

    public bool Locked;
    public bool Opened = false;

    public GameObject key;
    // Start is called before the first frame update

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //if (other.gameObject == key)
    //{
    //    Debug.Log("Unlocked!!!!");
    //    Locked = false;
    //}
    public void Interact()
    {
        if (!Opened)
        {
            if (Locked == false)
            {
                anim.SetBool("Open?", true);
                Opened = true;
            }
            else
            {
                anim.SetTrigger("Locked");
                Debug.Log("locked!!!");
            }
        }

        else if (Opened)
        {
            anim.SetBool("Open?", false);
            Opened = false;
        }
    }

    //}

    void OnTriggerExit()
    {
        //anim.SetBool("Open?", false);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
