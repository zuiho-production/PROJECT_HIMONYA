using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedSlider : MonoBehaviour
{
    Slider speedSlider;

    private float reqValue = 0;

    void Start()
    {
        speedSlider = GetComponent<Slider>();
    }

    public void OnSliderChanged()
    {
        reqValue = speedSlider.value;
    }
    
    public float DemandedValue()
    {
        float value = (reqValue * 1852) / 3600;

        return value;
    }
}
