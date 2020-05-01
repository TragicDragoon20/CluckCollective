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
    [SerializeField]
    private ParticleSystem explosion;
    [SerializeField]
    private Light lightSource;

    void Start()
    {
        colliderSize = new Vector3(this.transform.localScale.x, this.transform.localScale.y + .5f, this.transform.localScale.z);
        rb = this.GetComponent<Rigidbody>();

    }

    private void FixedUpdate()
    {
        if (rb.velocity.y < -1f)
        {
            FallingCrate(new Vector3 (this.transform.position.x, this.transform.position.y - .5f, this.transform.position.z), colliderSize, orientation, layerMask);
        }

    }

    private void FallingCrate(Vector3 checkingObject, Vector3 size, Quaternion orientation,LayerMask layerMask)
    {
        Collider[] overlaps = new Collider[1];
        int count = Physics.OverlapBoxNonAlloc(checkingObject, size, overlaps, orientation, layerMask);
        for (int i = 0; i < count; i++)
        {
            if (overlaps[i] != null)
            {
                explosion.transform.position = overlaps[i].transform.position;
                Destroy(overlaps[i].gameObject);
                explosion.Play();
                if(lightSource != null)
                {
                    lightSource.enabled = false;
                }
                Debug.Log("dead");
            }
        }
    }

}
