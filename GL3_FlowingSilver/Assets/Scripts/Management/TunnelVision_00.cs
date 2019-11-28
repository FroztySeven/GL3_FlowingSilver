using System.Collections;
using System.Collections.Generic;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine;

public class TunnelVision_00 : MonoBehaviour
{
    Vignette vingette = null;

    private void Start()
    {
        PostProcessVolume volume = GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out vingette);
    }

    // Update is called once per frame
    void Update()
    {
        vingette.intensity.value = 10 / HealthSystem.health;
    }
}
