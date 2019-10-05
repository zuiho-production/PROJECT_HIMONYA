using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Parameter/ShipData")]
public class ShipData : ScriptableObject
{
    public string ShipClass;
    public string ShipType;

    public int GunType; // none: 0, 76mm: 1, 127mm: 2, 5inch: 3 
    public int RIM7_qua;
    public int ESSM_qua;
    public int SM2_qua;
    public int SSM_qua;
    public int CIWS_qua;
    public int SeaRAM_qua;

    public int accel_value;
    public float rotate_value;
    public int max_hp;
    public int defence_value;
    public int max_search;
}
