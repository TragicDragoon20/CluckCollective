using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    protected GameObject player;
    [SerializeField]
    protected ParticleSystem particleFire;
    [SerializeField]
    protected ParticleSystem particleSmoke;

    [Header("Player Lost")]
    [SerializeField]
    protected float continueToFollowTime;
    [SerializeField]
    protected float lostSearchTime;
    [SerializeField]
    protected Vector3 rotationSpeed;

    [Header ("Patrol")]
    public NavMeshAgent agent;
    [Tooltip ("when the ground is at y = 0 put the patrol point on y = 1. This makes sure that the AI can see the patrol point and detect it.")][SerializeField]
    protected GameObject[] patrolPoints;
    [SerializeField]
    protected int currentPatrolPoint;
    protected Rigidbody rb;

    [Header("Shooting")]
    [SerializeField]
    private LayerMask layerMask;
    [SerializeField]
    private float damage;
    [SerializeField]
    private float fireRate;
    private float nextTimeToFire = 0f;
    private Health health;

    protected Animation firingAnimation;
    protected bool canFireAnim = true;

    private FOVDetection fOVDetection;

    [SerializeField]
    public State state;
    public enum State
    {
        Patrol,
        ChaseTarget,
        TargetLost,
        Sound,
        LostRotation,
        ShootTarget,
    }

    private void Awake()
    {

        agent = this.GetComponent<NavMeshAgent>();
        fOVDetection = this.GetComponent<FOVDetection>();
        rb = this.gameObject.GetComponent<Rigidbody>();
        health = player.GetComponent<Health>();
        particleFire = this.gameObject.transform.GetChild(2).gameObject.GetComponent<ParticleSystem>();
        particleSmoke = this.gameObject.transform.GetChild(1).gameObject.GetComponent<ParticleSystem>();
        firingAnimation = this.gameObject.transform.GetChild(0).gameObject.GetComponent<Animation>();
        firingAnimation.Play("Close");
    }

    private void Start()
    {
        rotationSpeed = new Vector3(0f, 100f, 0f);
        state = State.Patrol;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Patrol:
                canFireAnim = false;
                Patrol();
                PlayerInSight();
                break;
            case State.ChaseTarget:
                canFireAnim = false;
                FollowPlayer();
                break;
            case State.TargetLost:
                canFireAnim = false;
                PlayerLost();
                break;
            case State.Sound:
                canFireAnim = false;
                GoToSound();
                break;
            case State.LostRotation:
                canFireAnim = false;
                LostRotation();
                break;
            case State.ShootTarget:
                canFireAnim = false;
                ShootTarget();
                break;
        }
        if(state == State.Patrol)
        {
            if (canFireAnim)
            {
                //firingAnimation.Play("Close");
            }
        }
        else if (state != State.Patrol)
        {
            if (canFireAnim)
            {
                //firingAnimation.Play("Open");
            }
        }
    }

    private void PlayerInSight()
    {
        if (fOVDetection.isInFov)
        {
            canFireAnim = true;
            state = State.ChaseTarget;
        }
    }

    protected virtual void Patrol()
    {

    }

    private void FollowPlayer()
    {
        if (fOVDetection.isInFov)
        {
            continueToFollowTime = 8f;
            lostSearchTime = 5f;
            agent.SetDestination(player.transform.position);

            if (fOVDetection.canShoot)
            {
                state = State.ShootTarget;
            }
        }
        else if (!fOVDetection.isInFov)
        {

            if (continueToFollowTime <= 0)
            {
                state = State.TargetLost;
            }
            else
            {
                agent.SetDestination(player.transform.position);
                continueToFollowTime -= Time.deltaTime;
            }
        }
    }

    private void PlayerLost()
    {
        if (Vector3.Distance(this.transform.position, fOVDetection.playerLastKnownPos) < 5f)
        {
            agent.SetDestination(this.transform.position);
            canFireAnim = true;
            state = State.LostRotation;
        }
        else
        {
            agent.SetDestination(fOVDetection.playerLastKnownPos);
        }
    }
    private void LostRotation()
    {
        if (lostSearchTime <= 0)
        {
            canFireAnim = true;
            state = State.Patrol;
        }
        else
        {
            Quaternion deltaRotation = Quaternion.Euler(rotationSpeed * Time.deltaTime);
            rb.MoveRotation(rb.rotation * deltaRotation);
            lostSearchTime -= Time.deltaTime;
        }
    }

    private void GoToSound()
    {
        if (fOVDetection.isInFov)
        {
            state = State.ChaseTarget;
        }
        else
        {
            if (Vector3.Distance(this.transform.position, fOVDetection.playerLastKnownPos) > 3f)
            {
                agent.SetDestination(fOVDetection.playerLastKnownPos);
            }
            else
            {
                lostSearchTime = 5f;
                state = State.TargetLost;
            }
        }
    }



    private void ShootTarget()
    {
        if (!fOVDetection.canShoot)
        {
            state = State.ChaseTarget;
        }
        else
        {
            if(player != null)
            {
                agent.SetDestination(player.transform.position);
            }
            if (Time.time >= nextTimeToFire)
            {
                RaycastHit hit;

                if (Physics.Raycast(this.transform.position, this.transform.forward, out hit, layerMask))
                {
                    health.currentHealth -= damage;
                    particleSmoke.Play();
                    particleFire.Play();
                }
                nextTimeToFire = Time.time + 1f / fireRate;
            }
        }
    }
}
