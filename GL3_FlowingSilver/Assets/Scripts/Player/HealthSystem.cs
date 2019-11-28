using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public static float health = 100;
    public static float healHealth = 0;
    public static bool isDead = false; 

    public static void TakeHealth(float idx)
    {
        health -= idx;
        healHealth += idx;
        if (health <= 0)
        {
            isDead = true;
            
        }
        else
        {
            isDead = false;
        }
    }

    public static void ResetHealth()
    {
        health = 100;
        isDead = false;
    }

    public static void GiveHealth(float idx)
    {
        health += idx;
        if (health > 100)
        {
            health = 100;
        }
    }
    public static void Kill()
    {
        isDead = true;
    }
}
