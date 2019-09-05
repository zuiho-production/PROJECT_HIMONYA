using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateDropdown : MonoBehaviour
{
    Dropdown dropdown;
    float rRotate;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
    }

    public void OnValueChanged()
    {
        rRotate = dropdown.value * 60;
    }

    public float DemandedValue()
    {
        return rRotate;
    } 
}
