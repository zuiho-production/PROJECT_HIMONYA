using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMove : MonoBehaviour
{
    float x = 0;
    float count = 0;

    void Start()
    {
        
    }
    
    void FixedUpdate()
    {
        transform.Translate(x, 0, (float)0.1);

        if ((int)count  == 8)
        {
            x = Random.Range((float)-0.5, (float)0.5);
            Debug.Log("TGT.X: " + x);

            count = 0;
        }

        count += Time.deltaTime;
    }
}
