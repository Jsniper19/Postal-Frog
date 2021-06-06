using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WindScript : MonoBehaviour
{
    public GameObject player;
    public float windForce = 0.04f;
    public WindScriptTimer windScriptTimer;
    public bool safeArea;

    void OnTriggerStay(Collider other)
    {
        if (windScriptTimer.windActive == true)
        {
            if (safeArea == false)
            {
                player.GetComponent<Rigidbody>().AddForce(0, 0, -windForce, ForceMode.VelocityChange);
            }
        }
    }
}
