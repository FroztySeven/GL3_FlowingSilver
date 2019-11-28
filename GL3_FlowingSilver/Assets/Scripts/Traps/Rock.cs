using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField] float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(DestroyRock());

    }

    IEnumerator DestroyRock()
    {
        yield return new WaitForSeconds(4);
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.tag == "Player")
        {
            HealthSystem.TakeHealth(damage);
        }

    }
}
