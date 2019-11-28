using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterAmount : MonoBehaviour
{
    Material mat;
    public string toControllFillAmount = "Call UpdateWaterAmount(float %)";

    // Start is called before the first frame update
    void Start()
    {
        mat = GetComponent<MeshRenderer>().material;        
    }



    public void UpdateWaterAmount(float waterAmount) //The % of the water
    {
        float fillAmount = 1-(0.24f+(waterAmount / 200));
        mat.SetFloat("_FillAmount", fillAmount);
    }
}
