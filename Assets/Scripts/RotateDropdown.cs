using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RotateDropdown : MonoBehaviour
{
    Dropdown dropdown;
    public GameObject Ship;
    ShipAccel shipAccel;

    float rRotate;
    bool rotate = false;

    void Start()
    {
        dropdown = GetComponent<Dropdown>();
        shipAccel = Ship.GetComponent<ShipAccel>();
    }

    public void OnValueChanged()
    {
        rRotate = dropdown.value * 60;

        shipAccel.changeRotation(rRotate);

    }

    public void ResetValue()
    {
        dropdown.value = 0;
    } 
}
