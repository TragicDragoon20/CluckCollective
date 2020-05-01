using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPush : MonoBehaviour
{
    [SerializeField]
    private float pushSpeed = 4;

    AudioSource crate;
    [SerializeField]
    private AudioClip pushCrate;

    public bool playing = false;

    private void Awake()
    {
        crate = this.GetComponent<AudioSource>();
        //crate.clip = pushCrate;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Rigidbody body = hit.collider.attachedRigidbody;

        //no rigidbody
        if (body == null || body.isKinematic)
            return;

        //We don't want to push objects below us.
        if (hit.moveDirection.y < -0.3f)
            return;

        Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);

        if (Input.GetMouseButton(0) && (!playing))
        {
            playing = true;
            crate.Play();
        }
        if(Input.GetKeyUp(KeyCode.Mouse0) && (playing))
        {
            crate.Stop();
            playing = false;
        }

        body.velocity = pushDir * pushSpeed;
    }
}
