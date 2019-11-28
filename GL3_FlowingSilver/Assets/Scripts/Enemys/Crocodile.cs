using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Crocodile : MonoBehaviour
{
    public float walkSpeed = 1.5f;
    public float chaseSpeed = 2f;
    public float rotSpeed = 1f;
    public float detectionDist = 10f;
    public float attackDist = 5f;
    public float detectionAngle = 100f;
    public Transform crocPoint;


    private GameObject player;
    private Vector3 playerDir;
    private float playerDist;
    private bool idle, walking, chasing, attacking;
    private NavMeshAgent _navMeshA;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        _navMeshA = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        playerDir = player.transform.position - transform.position;
        playerDist = Vector3.Distance(transform.position, player.transform.position);

        if (playerDist <= attackDist && Vector3.Angle(transform.forward, playerDir) <= detectionAngle / 2)
        {
            SetBools();
            attacking = true;
            anim.SetBool("Attack", true);
            _navMeshA.SetDestination(player.transform.position);
            _navMeshA.speed = chaseSpeed * 1.5f;
        }
        else if (playerDist <= detectionDist && Vector3.Angle(transform.forward, playerDir) <= detectionAngle / 2)
        {
            SetBools();
            chasing = true;
            anim.SetBool("Chase", true);
            _navMeshA.SetDestination(player.transform.position);
            _navMeshA.speed = chaseSpeed;
        }
        else if (Vector3.Distance(transform.position, crocPoint.position) < 1f)
        {
            SetBools();
            idle = true;
            anim.SetBool("Idle", true);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, crocPoint.rotation, Time.deltaTime * rotSpeed);
        }
        else
        {
            SetBools();
            walking = true;
            anim.SetBool("Walk", true);
            _navMeshA.SetDestination(crocPoint.position);
            _navMeshA.speed = walkSpeed;
        }
    }

    void SetBools()
    {
        idle = false;
        walking = false;
        chasing = false;
        attacking = false;

        anim.SetBool("Idle", false);
        anim.SetBool("Walk", false);
        anim.SetBool("Chase", false);
        anim.SetBool("Attack", false);
    }
}
