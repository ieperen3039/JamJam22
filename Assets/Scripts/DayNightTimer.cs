using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayNightTimer : MonoBehaviour
{
    public Slider sliderDayNight;
    public float time = 48;    

    // Start is called before the first frame update
    void Start()
    {
        sliderDayNight.maxValue = 240;
        sliderDayNight.value = time;
    }

    // Update is called once per frame
    void Update()
    {
        sliderDayNight.value++;
        
        if (sliderDayNight.value > 239)
        {
            sliderDayNight.value = 0;
        }
    }
}
