using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponTestButton : MonoBehaviour
{
    public Text Logs;

    public void OnButtonCicked(int value)
    {
        Logs.GetComponent<WeaponTest>().ChangeStatus(value);
    }
}
