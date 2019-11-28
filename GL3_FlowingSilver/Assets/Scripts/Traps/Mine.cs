using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mine : MonoBehaviour
{
    [SerializeField] GameObject mineExplosion;


    private void OnCollisionEnter(Collision col)
    {
        Instantiate(mineExplosion, transform.position, Quaternion.Euler(-90, 0, 0));
        if (col.gameObject.tag == "Player")
            HealthSystem.TakeHealth(100);
        Destroy(gameObject);
    }
}
