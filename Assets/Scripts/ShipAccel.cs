using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipAccel : MonoBehaviour
{
    GameObject Ship;
    Rigidbody rigid;
    Vector3 force;

    // UI変数
    public Slider speedSlider;
    SpeedSlider speedScript;

    public Dropdown dropdown;
    RotateDropdown rotateScript;

    // 各要求値
    private float rSpeed = 0;   // スピード要求値
    private float rRotate = 0;  // 回転要求値

    private float countA = 0;    // ｱｸｾﾗﾚｰｼｮﾝ用カウント
    private float countR = 0;    // ﾛｰﾃｰｼｮﾝ用カウント

    // 加速用変数
    bool accel = false;         // 加速可否のスイッチ
    private float spd = 0;      // 設定したスピード
    private float nowSpd = 0;   // 実際のスピード

    // 回転用変数
    bool rotate = false;
    private float rRotateMem = 0;
    private Quaternion ShipNowRotation;
    private Quaternion ShipReqRotation;
    private float lerpValue = 0; // 線形補間 

    void Start()
    {
        force = Vector3.zero;

        Ship = GameObject.Find("Ship");
        rigid = GetComponent<Rigidbody>();

        speedSlider = speedSlider.GetComponent<Slider>();
        speedScript = speedSlider.GetComponent<SpeedSlider>();

        dropdown = dropdown.GetComponent<Dropdown>();
        rotateScript = dropdown.GetComponent<RotateDropdown>();

        ShipNowRotation = Ship.transform.rotation;
        ShipReqRotation = Quaternion.Euler(0, 0, 0);
    }

    void FixedUpdate()
    {
        force = Vector3.zero;
        spd = 0;

        accereration();

        if (rRotate != 0)
            rotation();

        // 入力取る
        if (speedSlider.isActiveAndEnabled)
        {
            rSpeed = speedScript.DemandedValue();

            Debug.Log("rSpeed GET!!!");

            if (rSpeed == 0)
            {
                countA = 0;
                rigid.velocity = new Vector3(0, 0, 0);
                accel = false;
            }
            else
            {
                accel = true;
            }
        }

/**
        // 回転の入力取る
        if (dropdown.isActiveAndEnabled)
        {
            rRotate = rotateScript.DemandedValue();

            Debug.Log("ROTATE GET!!! " + "rotate:" + rRotate);
        }
        else
        {
            rRotate = 0;
        }
**/

        // Ship_Pos = Ship.transform.position;
        Debug.Log("setSpd: " + spd);
        Debug.Log("nowSpd: " + nowSpd);
        Debug.Log("count: " + countA);
        Debug.Log("rSpeed = " + rSpeed);
    }

    void accereration()
    {
        nowSpd = rigid.velocity.magnitude;

        if (countA > 0)
        {
            spd = (Mathf.Sin((Mathf.PI * 3) / 2 + ((Mathf.PI / 40) * countA)) + 1) * (18 / 2);
        }
        else
        {
            spd = 0;
        }

        force = (transform.forward * spd);
        rigid.AddForce(force);

        if (accel)
        {
            if ((rSpeed - 1) > nowSpd)
            {
                countA += Time.deltaTime;
            }
            else if ((rSpeed + 1) < nowSpd)
            {
                countA -= Time.deltaTime;
            }
        }
    }

    public void changeRotation(float value)
    {
        rRotate = value + Ship.transform.localEulerAngles.y;
        Debug.Log("ShipNowRotation: " + Ship.transform.localEulerAngles.y);
        Debug.Log("rotation[reauired]: " + rRotate);
    }

    void rotation()
    {
        ShipNowRotation = Ship.transform.rotation;
        ShipReqRotation = Quaternion.Euler(0, rRotate, 0);       

        if (ShipNowRotation.y != ShipReqRotation.y) 
        {
            Ship.transform.rotation = Quaternion.Lerp(ShipNowRotation, ShipReqRotation, lerpValue);

            if (countR > 0)
            {
                lerpValue = (Mathf.Sin((Mathf.PI * 3) / 2 + ((Mathf.PI / 16) * countR)) + 1) / 2;
            }
            else
            {
                lerpValue = 0;
            }

            if (lerpValue < 1)
            {
                countR += Time.deltaTime;
            }
            else if (lerpValue == 1)
            {
                rotateScript.ResetValue();
                changeRotation(0);
            }
            else
            {
                lerpValue = 1;
            }

        }
        else
        {
            countR = 0;
            lerpValue = 0;
        }
    }
}
