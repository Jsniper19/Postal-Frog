using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScript : MonoBehaviour
{
    private float windDownTime = 5.0f;
    private float windUpTime = 10.0f;
    public float windTime;

    public float windForce = 0.04f;
    public bool windActive = false;
    public GameObject player;

    void Start()
    {
        windTime = windUpTime + windDownTime;
        InvokeRepeating("Wind", 1f, windTime);
    }

    IEnumerator WindUp()
    {
        windActive = true;
        Debug.Log("wind is active");
        yield return new WaitForSecondsRealtime(windDownTime);
        windActive = false;
        Debug.Log("wind is no longer active");
    }

    void Wind()
    {
        StartCoroutine("WindUp");
    }
    void OnTriggerStay(Collider other)
    {
        if (windActive == true)
        {
            player.GetComponent<Rigidbody>().AddForce(0, 0, -windForce, ForceMode.VelocityChange);
        }
    }
}
