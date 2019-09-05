using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipAccel : MonoBehaviour
{
    GameObject Ship;
    Rigidbody rigid;
    Vector3 force;

    public Slider speedSlider;
    SpeedSlider speedScript;

    public Dropdown dropdown;
    RotateDropdown rotateScript;

    private float rSpeed = 0;
    private float rRotate = 0;

    private float count = 0;

    private Vector3 Ship_Pos;

    bool accel = false;

    private float spd = 0;
    private float nowSpd = 0;

    void Start()
    {
        force = Vector3.zero;

        Ship = GameObject.Find("Ship");
        Ship_Pos = Ship.GetComponent<Transform>().position;
        rigid = GetComponent<Rigidbody>();

        speedSlider = speedSlider.GetComponent<Slider>();
        speedScript = speedSlider.GetComponent<SpeedSlider>();

        dropdown = dropdown.GetComponent<Dropdown>();
        rotateScript = dropdown.GetComponent<RotateDropdown>();
    }

    void FixedUpdate()
    {
        force = Vector3.zero;
        spd = 0;

        accereration();
        rotation();

        // 入力取る
        if (speedSlider.isActiveAndEnabled)
        {
            rSpeed = speedScript.DemandedValue();

            Debug.Log("rSpeed GET!!!");

            if (rSpeed == 0)
            {
                count = 0;
                rigid.velocity = new Vector3(0, 0, 0);
                accel = false;
            }
            else
            {
                accel = true;
            }
        }
        // 回転の入力取る
        if (dropdown.isActiveAndEnabled)
        {
            rRotate = rotateScript.DemandedValue();
            Debug.Log("ROTATE GET!!!");
        }

        if (accel)
        {
            if ((rSpeed - 1) > nowSpd)
            {
                count += Time.deltaTime;
            }
            else if ((rSpeed + 1) < nowSpd)
            {
                count -= Time.deltaTime;
            }
        }

        // Ship_Pos = Ship.transform.position;
        Debug.Log("setSpd: " + spd);
        Debug.Log("nowSpd: " + nowSpd);
        Debug.Log("count: " + count);
        Debug.Log("rSpeed = " + rSpeed);
    }

    void accereration()
    {
        nowSpd = rigid.velocity.z;

        if (count > 0)
        {
            spd = (Mathf.Sin((Mathf.PI * 3) / 2 + ((Mathf.PI / 40) * count)) + 1) * (18 / 2);
        }
        else
        {
            spd = 0;
        }

        force = (transform.forward * spd);
        rigid.AddForce(force);
    }

    void rotation()
    {
        /**
         * 
         * 
         * 
         * 
         * 
         * */
    }
}
