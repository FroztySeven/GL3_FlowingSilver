using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    float hp = 10;
    float actHp;

    [SerializeField] Image healthBar;



    // Start is called before the first frame update
    void Start()
    {
        actHp = hp;
    }

    public void GetDamage(float damage)
    {
        actHp -= damage;
        UpdateHealthBar();
        if (actHp <= 0)
        {
            Death();
        }
    }

    void Death()
    {
        Destroy(this.gameObject);       //Reload Level(?)
    }

    void UpdateHealthBar()
    {
        healthBar.fillAmount = actHp / hp;
    }
}
