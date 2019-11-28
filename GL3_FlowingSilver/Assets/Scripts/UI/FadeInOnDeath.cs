using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class FadeInOnDeath : MonoBehaviour
{
    [SerializeField] float fadeSpeed = 1;
    [SerializeField] float fadeOffset = 1;

    private bool imageFade, textFade;
    private float counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        HideUI();
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthSystem.isDead)
        {
            GetComponent<Image>().color = new Color(0, 0, 0, 1);
            Invoke("FadeIn", fadeOffset);
        }

        if (imageFade)
        {
            counter = Mathf.MoveTowards(counter, 1, Time.deltaTime * fadeSpeed);
            GetComponent<Image>().color = new Color(counter, counter, counter, 1);

            if (counter == 1)
            {
                imageFade = false;
                textFade = true;
                counter = 0;
            }
        }

        if (textFade)
        {
            counter = Mathf.MoveTowards(counter, 1, Time.deltaTime * fadeSpeed);
            transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, counter);
        }
    }

    void FadeIn()
    {
        imageFade = true;
    }

    public void HideUI()
    {
        GetComponent<Image>().color = new Color(0, 0, 0, 0);
        transform.GetChild(0).GetComponent<Text>().color = new Color(1, 1, 1, 0);
    }
}
