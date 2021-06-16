using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SafeArea : MonoBehaviour
{
    public WindScript windScript;

    private void OnTriggerEnter(Collider other)
    {
        windScript.safeArea = true;
    }
    private void OnTriggerStay(Collider other)
    {
        windScript.safeArea = true;
    }
    private void OnTriggerExit(Collider other)
    {
        windScript.safeArea = false;
    }
}
