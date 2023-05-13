using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FillBar : MonoBehaviour
{

    //public PlayerHealth playerHealth;
    public Image fillImage;
    public Slider slider;

    // Start is called before the first frame update
    void Awake()
    {
        slider = GetComponent<Slider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (slider.value <= slider.minValue)
        {
            fillImage.enabled = false;
        }
        if (slider.value > slider.minValue && !fillImage.enabled)
        {
            fillImage.enabled = true;
        }
        // float fillvalue = playerHealth.health / playerHealth.maxHealth;
        float fillvalue = PlayerHealth.Instance.health / PlayerHealth.Instance.maxHealth;
        slider.value = fillvalue;

        if (fillvalue <= slider.maxValue / 3)
        {
            fillImage.color = Color.yellow;
        }
        else if (fillvalue > slider.maxValue / 3)
        {
            fillImage.color = Color.red;
        }


    }
}










