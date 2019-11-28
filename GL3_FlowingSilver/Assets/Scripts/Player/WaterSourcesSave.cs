using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSourcesSave : MonoBehaviour
{

    public List <string> wC;
    public List<float> wCFloat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void addToList(GameObject go)
    {
        if(wC.Count == 0)
        {
            wC.Add(go.name);
            wCFloat.Add(go.GetComponent<WaterSources>().RiverWater);
        }
        for (int i = 0; i < wC.Count; i++)
        {

            if (go.name == wC[i])
            {
                wCFloat[i] = go.GetComponent<WaterSources>().RiverWater;
            }
            else if(i == wC.Count -1)
            {

                wC.Add(go.name);
                wCFloat.Add(go.GetComponent<WaterSources>().RiverWater);
            }
        }

    }
}
