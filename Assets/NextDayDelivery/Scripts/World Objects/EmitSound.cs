﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitSound : MonoBehaviour
{
    private Rigidbody rb;
    [Range (0, 50)]
    [SerializeField]
    private float sphereRadius;
    public LayerMask layerMask;

    public Vector3 origin;
    private Vector3 velocity;

    private EnemyAI enemy;
    private FOVDetection fOVDetection;
    private ObjPickUp objPickUp;

    [SerializeField]
    private float timer = 0;
    private ParticleSystem ripple;

    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        objPickUp = this.gameObject.GetComponent<ObjPickUp>();
        ripple = gameObject.GetComponentInChildren<ParticleSystem>();

    }
    private void FixedUpdate()
    {
        velocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (objPickUp.wasThrown)
        {
            if (velocity.z < 1 )
            {
                ripple.Play();
                origin = this.transform.position;
                this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, 0);
                


                Collider[] hits = Physics.OverlapSphere(origin, sphereRadius, layerMask, QueryTriggerInteraction.UseGlobal);
                int i = 0;
                while (i < hits.Length)
                {
                    if (hits[i].gameObject.GetComponent<EnemyAI>() != null)
                    {

                        enemy = hits[i].gameObject.GetComponent<EnemyAI>();
                        fOVDetection = hits[i].gameObject.GetComponent<FOVDetection>();
                        if (enemy.state != EnemyAI.State.ChaseTarget)
                        {
                            fOVDetection.playerLastKnownPos = origin;
                            fOVDetection.playerLastKnownPos.y += 1;
                            enemy.state = EnemyAI.State.Sound;
                            objPickUp.wasThrown = false;
                        }
                        
                    }
                    i++;
                }
            }
            
            
        }
        
    }
}
