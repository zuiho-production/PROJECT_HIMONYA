using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailButton : MonoBehaviour
{
    [SerializeField]
    public GameObject Canvas;
    public GameObject Sail;

    public GameObject Ship;
    public GameObject Target;


    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            XButtonCricked();
        }
    }
    
    public void onSailButtonCricked()
    {
        Canvas.SetActive(false);
        Sail.SetActive(true);
    }
    public void XButtonCricked()
    {
        Canvas.SetActive(true);
        Sail.SetActive(false);
    }

    public void ChaseButtonCricked()
    {
        ShipAccel shipAccel = Ship.GetComponent<ShipAccel>();
        shipAccel.SetChaseRotation(Target);
    }
}