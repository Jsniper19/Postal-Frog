using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScripTimer : MonoBehaviour
{
    public float windDownTime = 5.0f;
    public float windUpTime = 10.0f;
    public float windTime;
    public bool windActive = false;


    void Start()
    {
        windTime = windUpTime + windDownTime;
        InvokeRepeating("Wind", windDownTime, windTime);
    }

    void Wind()
    {
        StartCoroutine(WindUp());
    }

    IEnumerator WindUp()
    {
        windActive = true;
        Debug.Log("wind is active");
        yield return new WaitForSecondsRealtime(windUpTime);
        windActive = false;
        Debug.Log("wind is no longer active");
    }
}
