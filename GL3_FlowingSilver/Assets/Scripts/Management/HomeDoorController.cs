using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HomeDoorController : MonoBehaviour
{
    public GameObject enterance;

    private Animator anim;
    private bool hasWater;
    private bool startedAnim;
    private FillWithWater fww;
    private HomeManage hm;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        fww = GameObject.FindGameObjectWithTag("Bucket").GetComponent<FillWithWater>();
        hm = GameObject.Find("Enterance").GetComponent<HomeManage>();
        anim.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        hasWater = fww.hasWater;
    
        if (hasWater)
        {
            anim.enabled = true;
            anim.SetBool("Open", true);
            anim.SetBool("Close", false);
            enterance.SetActive(true);
        }
        else if (hm.watertobe <= 0)
        {
            anim.SetBool("Close", true);
            anim.SetBool("Open", false);
            enterance.SetActive(false);
        }
    }

    public void RunAnimMaybe()
    {
        anim.SetBool("Open", false);
    }
}
