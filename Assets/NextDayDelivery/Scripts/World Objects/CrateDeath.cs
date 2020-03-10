using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateDeath : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private LayerMask layerMask;
    private Vector3 colliderSize;
    private Quaternion orientation = new Quaternion(0, 0, 0, 0);

    void Start()
    {
        colliderSize = new Vector3(this.transform.localScale.x, this.transform.localScale.y + .5f, this.transform.localScale.z);
        rb = this.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < 0f)
        {
            FallingCrate(this.transform, colliderSize, orientation, layerMask);
        }

    }

    private bool FallingCrate(Transform checkingObject, Vector3 size, Quaternion orientation,LayerMask layerMask)
    {
        Collider[] overlaps = new Collider[1];
        int count = Physics.OverlapBoxNonAlloc(checkingObject.position, size, overlaps, orientation, layerMask);
        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                Destroy(overlaps[i].gameObject);
                Debug.Log("dead");
                return true;
            }
        }
        return false;
    }

}
