using UnityEngine;

public class SafeArea : MonoBehaviour
{
    [SerializeField] private WindScript windScript;
    //tells whether the player is in a safe zone
    private void OnTriggerEnter(Collider other)
    {
        windScript.safeArea = true;
    }
    private void OnTriggerExit(Collider other)
    {
        windScript.safeArea = false;
    }
}