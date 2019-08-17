using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SailButton : MonoBehaviour
{
    [SerializeField]
    public GameObject Canvas;
    public GameObject Sail;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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

}
