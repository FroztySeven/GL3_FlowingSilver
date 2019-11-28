using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Multi_Enemy : MonoBehaviour
{
    [Header("Speed Settings")]
    [SerializeField] private float rotSpeed;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float chaseSpeed;

    [Header("Detection Settings")]
    [Range(10, 180)]
    [SerializeField] private float detectionAngle;
    [SerializeField] private float detectionDistance;

    [Header("Shooting Settings")]
    [SerializeField] private GameObject gun;
    [SerializeField] private GameObject bullet;
    [SerializeField] private ParticleSystem muzzleFlash;
    [SerializeField] private bool machineGun;
    [SerializeField] private float shootSpread;
    [SerializeField] private float timeBetweenShots;
    [SerializeField] private float shootDistance;

    [Header("Move Settings")]
    [SerializeField] private string pointNames;

    private enum states { stationary, followsPlayer, shootsPlayer}
    [Header("Choose State")]
    [SerializeField] private states States;

    private GameObject player;
    private Vector3 playerDir;
    private Quaternion rotToPlayer;
    private Quaternion rotToNextPoint;
    private bool canSeePlayer;
    private bool seesPlayer;
    private float shootCounter;

    private string nextName;
    private int nameCounter = 0;
    private int pointCounter = 0;
    private List<Transform> movePoints = new List<Transform>();

    [HideInInspector] public bool freeze = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        InvokeRepeating("FindPoints", 0, 1);
    }

    void FindPoints()
    {
        nextName = pointNames + 0;

        while (GameObject.Find(nextName) != null)
        {
            movePoints.Add(GameObject.Find(nextName).transform);
            nameCounter++;
            nextName = pointNames + nameCounter;
        }
        nameCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {   
        FindPlayer();
        DetectingPlayer();
        if (!freeze)
        {
            switch (States)
            {
                case states.stationary:
                    ShootAtPlayer();
                    break;
                case states.followsPlayer:
                    MoveNormally();
                    ChasePlayer();
                    break;
                case states.shootsPlayer:
                    MoveNormally();
                    if (Vector3.Distance(transform.position, player.transform.position) < shootDistance)
                        ShootAtPlayer();
                    else
                        ChasePlayer();
                    break;
                default:
                    break;
            }
        }     
    }

    void FindPlayer()
    {
        RaycastHit hit;
        if (Physics.Raycast(gun.transform.position, (player.transform.position + player.GetComponent<CapsuleCollider>().center) - gun.transform.position, out hit, detectionDistance))
        {
            Debug.DrawLine(gun.transform.position, ((player.transform.position + player.GetComponent<CapsuleCollider>().center) - gun.transform.position) * hit.distance);
            if (hit.collider.gameObject.layer == 8)
                canSeePlayer = true;
            else
                canSeePlayer = false;
        }

        playerDir = player.transform.position - transform.position;
        if (Vector3.Angle(transform.forward, playerDir) <= detectionAngle / 2 && canSeePlayer)
            seesPlayer = true;
        else
            seesPlayer = false;
    }

    void DetectingPlayer()
    {
        if (seesPlayer)
        {
            rotToPlayer = Quaternion.LookRotation(playerDir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotToPlayer, Time.deltaTime * rotSpeed * 10);
            //gun.transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(new Vector3(player.transform.position.x, player.transform.position.y + player.GetComponent<CapsuleCollider>().height / 2, player.transform.position.z) - gun.transform.position), Time.deltaTime * rotSpeed * 10);
            gun.transform.rotation = Quaternion.LookRotation(new Vector3(player.transform.position.x, player.transform.position.y + player.GetComponent<CapsuleCollider>().height * 0.5f, player.transform.position.z) - gun.transform.position);
        }
    }

    void MoveNormally()
    {
        if (!seesPlayer)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.Self);
            rotToNextPoint = Quaternion.LookRotation(movePoints[pointCounter].position - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotToNextPoint, Time.deltaTime * rotSpeed * 10);

            if (Vector3.Distance(transform.position, movePoints[pointCounter].position) < 1f)
            {
                if (pointCounter == movePoints.Count - 1)
                {
                    pointCounter = 0;
                }
                else
                {
                    pointCounter++;
                }
            }
        }
    }

    void ChasePlayer()
    {
        if (seesPlayer)
            GetComponent<Rigidbody>().velocity = transform.forward * chaseSpeed;
            //transform.Translate(Vector3.forward * Time.deltaTime * chaseSpeed, Space.Self);
    }

    void ShootAtPlayer()
    {
        if (Vector3.Angle(transform.forward, playerDir) <= detectionAngle / 10 && shootCounter == 0 && seesPlayer)
        {
            if (machineGun)
            {
                int idx = Random.Range(3, 8);
                int counter = 0;
                for (int i = 0; i < idx; i++)
                {
                    Invoke("ShootPlayer", counter * 0.1f);
                    counter++;
                }
            }
            else
            {
                ShootPlayer();
            }
            shootCounter = timeBetweenShots;
        }
        else
        {
            shootCounter = Mathf.MoveTowards(shootCounter, 0, Time.deltaTime);
        }

    }

    void ShootPlayer()
    {
        float x = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        float y = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        float z = Random.Range((shootSpread / 2) * -1, shootSpread / 2);
        Instantiate(bullet, gun.transform.position, gun.transform.rotation * Quaternion.Euler(x, y, z));
        if (muzzleFlash != null)
            Instantiate(muzzleFlash, gun.transform.position, transform.rotation);
    }

    void UnFreeze()
    {
        freeze = false;
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            freeze = true;
            Invoke("UnFreeze", 3f);
        }
    }
}
