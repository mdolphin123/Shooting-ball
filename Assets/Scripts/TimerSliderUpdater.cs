using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSliderUpdater : MonoBehaviour
{
    private Slider slider;
    private float currentValue;
    // Start is called before the first frame update
    void Start()
    {
        slider = GetComponent<Slider>();
        currentValue = 300.0f;
        slider.maxValue = currentValue;
        slider.value = currentValue;
    }

    // Update is called once per frame
    void Update()
    {
        currentValue -= Time.deltaTime;
        slider.value = currentValue;
    }
}
