using System.Collections;
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
    private GameObject audioProjection;
    [SerializeField]
    private GameObject projector;

    private Collider[] hits;

    private bool timerRunning = false;
    [SerializeField]
    private float timeStart;
    private float timeRemaining;
    private void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
        objPickUp = this.gameObject.GetComponent<ObjPickUp>();


    }

    private void Update()
    {
        velocity = rb.velocity;
        if (timerRunning)
        {
            if(timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timerRunning = false;
                Destroy(projector);
            }
        }    
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (objPickUp.wasThrown == true)
        {
            if (velocity.y < 0.5f && velocity.x < 0.5f && velocity.z < 0.5f)
            {
                objPickUp.wasThrown = false;
                GetEnemiesInRange();
            }
        }
    }

    private void SpawnProjectors()
    {
        this.transform.rotation = new Quaternion(this.transform.rotation.x, 0, this.transform.rotation.z, 0);
        
        if(projector == null)
        {
            Debug.Log("SpawnProjector");
            projector = Instantiate(audioProjection, this.transform.position , Quaternion.Euler(90f, 0f, 0f));
            projector.GetComponent<Projector>().orthographicSize = sphereRadius;
        }
        else
        {
            Debug.Log("!");
        }
        timeRemaining = timeStart;
        timerRunning = true;
        

    }
    private void GetEnemiesInRange()
    {
        SpawnProjectors();
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
                    enemy.state = EnemyAI.State.Sound;
                    origin = this.transform.position;
                    fOVDetection.playerLastKnownPos = origin;
                    fOVDetection.playerLastKnownPos.y += 1;
                }

            }
            i++;

        }
    }
}
