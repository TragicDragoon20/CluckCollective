using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroppingObjects : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private bool canDrop;
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
