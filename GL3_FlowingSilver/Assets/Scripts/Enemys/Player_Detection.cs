using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Detection : MonoBehaviour
{
    [SerializeField] private float detectionDist;
    [Range(10, 180)]
    [SerializeField] private float detectionAngle;
    [SerializeField] private float rotSpeed;

    [HideInInspector] public bool hittingThePlayer = false;
    private GameObject player;
    private Vector3 playerEnemyAngle;
    private Quaternion desiredRot;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        FindPlayer();
    }

    void FindPlayer()
    {
        RaycastHit hit;
        playerEnemyAngle = new Vector3(player.transform.position.x, player.transform.position.y + 1.6f, player.transform.position.z) - transform.position;
        desiredRot = Quaternion.LookRotation(playerEnemyAngle);
        if (Physics.Raycast(transform.position, playerEnemyAngle, out hit, detectionDist) && Vector3.Angle(transform.forward, playerEnemyAngle) <= detectionAngle/2)
        {
            Debug.DrawRay(transform.position, playerEnemyAngle * hit.distance, Color.red);
            if (hit.collider.gameObject.layer == 8)
            {
                Vector3 newDir = Vector3.RotateTowards(transform.forward, playerEnemyAngle, rotSpeed * Time.deltaTime * 0.1f, 0);

                transform.rotation = Quaternion.LookRotation(newDir);
                if (Vector3.Angle(transform.forward, playerEnemyAngle) <= detectionAngle / 10)
                {
                    hittingThePlayer = true;
                }
            }
            else
            {
                hittingThePlayer = false;
            }
        }
        else if (Vector3.Distance(transform.position, player.transform.position) < 2)
        {
            Vector3 newDir = Vector3.RotateTowards(transform.forward, new Vector3(playerEnemyAngle.x, 0, playerEnemyAngle.z), rotSpeed * Time.deltaTime, 0);

            transform.rotation = Quaternion.LookRotation(newDir);
        }
        else
        {
            hittingThePlayer = false;
        }
    }
}
