using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterVariables : MonoBehaviour
{
    public static WaterVariables pp;
    public static GameObject WaterInbucket;
    public static GameObject Player;
    public static GameObject Bucket;
    public static Rigidbody RB;


    public static float WaterAmount = 0;
    public static float barrelWater;
    public static bool WaterFilled = false;
    public static bool bcInHand = false;
    public static bool bcInRange = false;
    

    public void Awake()
    {

        Player = GameObject.Find("PlayerController");

        Bucket = GameObject.Find("Bucket");
        //RB = Bucket.GetComponent<Rigidbody>();
        /*
        if (bcInHand)
        {
            pickuptry();
        }*/
       
        DontDestroyOnLoad(this);
        if(GameObject.FindGameObjectsWithTag(gameObject.tag).Length > 1)
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        /*
        Debug.Log("bucket filled " + WaterFilled);
        Debug.Log("bucket In Hand " + bcInHand);
        Debug.Log("bucket In range " + bcInRange);*/

        if (WaterFilled)
        {
            WaterInbucket.SetActive(true);
            WaterAmount = 100;
        }
        else
        {
            WaterInbucket.SetActive(false);
            WaterAmount = 0;
        }

        /*
        if (HealthSystem.health <=0)
        {
            WaterAmount = 0;
            WaterFilled = false;

        }*/


       

    }

    public static void RemoveWater(float idx)
    {
        WaterAmount -= idx;

         if(WaterAmount <= 0)
        {
            WaterFilled = false;
        }
    }

    public static void AddWater(float idx)
    {
        WaterAmount += idx;
        if (WaterAmount > 100)
        {
            WaterAmount = 100;
        }

    }

    public static void emptyBucket()
    {
        WaterAmount = 0;
    }


  

    public static void pickuptry()
    {
        Debug.Log("Tried To parent");
        Bucket.transform.position = GameObject.Find("InHand").transform.position;
        Bucket.transform.parent = Player.transform;
        Bucket.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 2.3F, Player.transform.position.z);
        Destroy(RB);
    }

}
