using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Walking_AI : MonoBehaviour
{
    [SerializeField] string pointNames;
    [SerializeField] float detectionDist;
    [Range(0, 180)]
    [SerializeField] float detectionAngle;
    [SerializeField] Transform detectionPos;
    [SerializeField] float walkSpeed = 3.5f;
    [SerializeField] float chaseSpeed = 5f;
    [SerializeField] bool randomPoint;
    [SerializeField] bool startsIdle;

    [Header("Shooting Settings")]
    [SerializeField] private bool shoots;
    [SerializeField] private GameObject gunPoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private float shootSpread;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float shootDistance;

    private List<Transform> points = new List<Transform>();
    private Vector3 currentTarget;
    private int nameCounter;
    private bool lookingForPlayer;
    private Animator anim;

    private GameObject player;
    private Vector3 playerDir;
    private float playerDist;
    [HideInInspector] public bool idle;
    [HideInInspector] public bool patroling;
    [HideInInspector] public bool seesPlayer;
    [HideInInspector] public bool shootble;

    NavMeshAgent _navMeshAgent;

    Hidden hid;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _navMeshAgent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        string nextName = pointNames + 0;
        nameCounter = 0;
        while (GameObject.Find(nextName) != null)
        {
            points.Add(GameObject.Find(nextName).transform);
            nameCounter++;
            nextName = pointNames + nameCounter;
        }
        nameCounter = 0;

        if (GameObject.Find("Hidden") != null)
            hid = GameObject.Find("Hidden").GetComponent<Hidden>();
        if (!startsIdle && anim != null)
            anim.SetTrigger("Patrol");

        InvokeRepeating("Shoot", 1, timeBetweenShots);
    }

    private void Update()
    {
        FindPlayer();

        if (Vector3.Distance(transform.position, points[nameCounter].position) < 0.5f)
        {
            nameCounter++;
            if (nameCounter == points.Count)
                nameCounter = 0;

            if (randomPoint)
                nameCounter = Random.Range(0, points.Count); 
        }

        if (seesPlayer)
            GetComponent<NavMeshAgent>().speed = chaseSpeed;
        else
            GetComponent<NavMeshAgent>().speed = walkSpeed;
    }

    void FindPlayer()
    {
        playerDir = player.transform.position - transform.position;
        playerDist = Vector3.Distance(transform.position, player.transform.position);

        if (playerDist <= detectionDist && Vector3.Angle(transform.forward, playerDir) <= detectionAngle / 2 && (hid == null || !hid.hidden))
        {
            RaycastHit hit;
            if (Physics.Raycast(detectionPos.position, (player.transform.position + player.GetComponent<CapsuleCollider>().center) - detectionPos.position, out hit, detectionDist))
            {
                if (hit.collider.gameObject.tag == "Player")
                {
                    seesPlayer = true;
                    lookingForPlayer = true;
                }
                else
                {
                    seesPlayer = false;
                }
            }
            if (playerDist <= shootDistance && Vector3.Angle(transform.forward, playerDir) <= detectionAngle / 10 && shoots && seesPlayer)
            {
                _navMeshAgent.SetDestination(transform.position);
                shootble = true;
                if (anim != null)
                    anim.SetTrigger("Shoot");
            }
            else if(seesPlayer)
            {
                _navMeshAgent.SetDestination(player.transform.position);
                shootble = false;
                if (anim != null)
                    anim.SetTrigger("Chase");
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Patrol();   
        }
    }

    void Shoot()
    {
        if (shootble && !hid.hidden)
        {
            gunPoint.transform.rotation = Quaternion.LookRotation((player.transform.position + player.GetComponent<CapsuleCollider>().center) - gunPoint.transform.position);
            float x = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
            float y = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
            float z = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
            Instantiate(bullet, gunPoint.transform.position + gunPoint.transform.forward, gunPoint.transform.rotation * Quaternion.Euler(x, y, z));
            if (muzzleFlash != null)
                Instantiate(muzzleFlash, gunPoint.transform.position, transform.rotation);
        }   
    }

    void Patrol()
    {
        if (!lookingForPlayer)
        {
            seesPlayer = false;
            _navMeshAgent.SetDestination(points[nameCounter].position);
            if (anim != null)
                anim.SetTrigger("Patrol");
        }
        else
        {
            LookForPlayer();
        }

    }

    void LookForPlayer()
    {
        Invoke("GivesUp", 3);
        _navMeshAgent.SetDestination(transform.position);
        if (anim != null)
            anim.SetTrigger("Idle");

    }

    void GivesUp()
    {
        lookingForPlayer = false;
    }
}
