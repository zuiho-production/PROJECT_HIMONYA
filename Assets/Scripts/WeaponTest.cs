using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTest : MonoBehaviour
{
    public Text logs;

    public Text distanceText;
    public Text angleText;
    public Text GunAzimuthText;
    public Text GunElevationText;
    public Text GunBulletsText;

    private Vector3 MyShip = new Vector3(0, 0, 0);
    private Vector3 EnemyShip = new Vector3(0, 0, 0);

    private float distance = 0;
    private float angle = 0;

    private float GunAzimuth = 0;
    private float GunElevation = 0;
    private int GunBullets = 0;

    private bool GunFire = true;
    private float GunCount = 0;

    void Start()
    {
        logs.text = "ZUIHO PRODUCTION";
        distanceText.text = "DISTANCE: LOADING...";
        angleText.text = "ANGLE: LOADING...";
        GunAzimuthText.text = "GunAzimuth: Loading...";
        GunElevationText.text = "GunElevation: Loading...";
        GunBulletsText.text = "GunBullets: Loading...";

        GunBullets = 4;

    }

    private void Update()
    {
        distanceText.text = "DISTANCE: " + distance.ToString();
        angleText.text = "ANGLE: " + angle.ToString();
        GunAzimuthText.text = "GunAzimuth: " + GunAzimuth.ToString();
        GunElevationText.text = "GunElevation: " + GunElevation.ToString();
        GunBulletsText.text = "GunBullets: " + GunBullets.ToString();
    }

    void FixedUpdate()
    {
        GunControl();
    }

    private void GunControl()
    {
        if (GunFire)
        {
            if ((int)GunCount == 8)
            {
                logger("fire", 0);
                GunCount = 0;
                GunBullets--;
            }
            if (GunBullets <= 0)
            {
                logger("nobullets", 0);
                GunFire = false;
                GunBullets = 0;
                GunCount = 0;
            }
        }
        else
        {
            if ((int)GunCount == 90)
            {
                logger("ready", 0);
                GunFire = true;
                GunBullets = 66;
                GunCount = 0;
            }
        }

        GunCount += Time.deltaTime;
    }

    private void logger(string status, int weapon)
    {
        string memText;
        switch(weapon)
        {
            case 0:
                memText = "【大砲】 ";
                break;
            default:
                memText = "【エラー】 ";
                break;
        }

        switch (status)
        {
            case "fire":
                memText += "発射されました \n";
                break;
            case "nobullets":
                memText += "弾切れです \n";
                break;
            case "ready":
                memText += "発射可能です \n";
                break;
            default:
                memText = "【エラー】";
                break;
        }

        memText += logs.text;

        logs.text = memText;

        memText = null;
    }
}
