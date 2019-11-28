using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update

    public float damage=1;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.GetComponent<Health>().GetDamage(damage);
        }
           //    ------    ------     ------  Add sound and particles
        Destroy(this.gameObject);
    }
}
