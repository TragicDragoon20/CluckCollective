using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObjects : MonoBehaviour
{
    public bool canDrop;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        rb.isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (canDrop)
        {
            rb.isKinematic = false;
        }
    }
}
