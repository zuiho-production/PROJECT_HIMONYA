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
    private Vector3 EnemyShip = new Vector3(0, 0, 1);

    private float distance = 0;
    private float angle = 0;

    private float GunAzimuth = 0;
    private float GunElevation = 0;
    private int GunBullets = 0;

    private bool Battle = true;
    private bool GunFire = true;

    private bool GunisReady = false;
    private bool GunisDirected = false;
    private float GunCount = 0;

    void Start()
    {
        logs.text = "ZUIHO PRODUCTION";
        distanceText.text = "DISTANCE: LOADING...";
        angleText.text = "ANGLE: LOADING...";
        GunAzimuthText.text = "GunAzimuth: Loading...";
        GunElevationText.text = "GunElevation: Loading...";
        GunBulletsText.text = "GunBullets: Loading...";

        GunBullets = 66;

    }

    private void Update()
    {
        distanceText.text = "DISTANCE: " + distance.ToString("f2");
        angleText.text = "ANGLE: " + angle.ToString("f2");
        GunAzimuthText.text = "GunAzimuth: " + GunAzimuth.ToString("f2");
        GunElevationText.text = "GunElevation: " + GunElevation.ToString("f2");
        GunBulletsText.text = "GunBullets: " + GunBullets.ToString();
    }

    void FixedUpdate()
    {
        Vector3 v1 = new Vector3((float)-0.01, 0, (float)0.05);
        EnemyShip += v1;

        distance = Vector3.Distance(MyShip, EnemyShip);
        angle = Mathf.Atan2((EnemyShip.z - MyShip.z), (EnemyShip.x - MyShip.x)) * Mathf.Rad2Deg;

        if (Battle)
        {
            if(GunFire)
            {
                GunControl();
            }
        }
    }

    private void GunControl()
    {
        float ReqAzimuth = angle;

        if (GunAzimuth < (ReqAzimuth - 1) || GunAzimuth > (ReqAzimuth + 1))
        {
            if (ReqAzimuth > 0)
            {
                GunAzimuth += Time.deltaTime * 30;
            } else if (ReqAzimuth < 0)
            {
                GunAzimuth -= Time.deltaTime * 30;
            }
            GunisDirected = false;
        } else if (GunAzimuth >= (ReqAzimuth - 1) && (GunAzimuth) <= (ReqAzimuth + 1))
        {
            GunAzimuth = ReqAzimuth;
            GunisDirected = true;
        }


        if (GunisReady)
        {
            if ((int)GunCount == 4)
            {
                logger("fire", 0);
                GunCount = 0;
                GunBullets--;
            }
            if (GunBullets <= 0)
            {
                logger("nobullets", 0);
                GunisReady = false;
                GunBullets = 0;
                GunCount = 0;
            }
        }
        else
        {
            if (GunBullets <= 0 && (int)GunCount  == 90)
            {
                GunBullets = 66;
            }

            if (GunBullets == 66 && GunisDirected)
            {
                logger("ready", 0);
                GunCount = 0;
                GunisReady = true;
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
