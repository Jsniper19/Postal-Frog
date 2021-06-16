using UnityEngine;

public class WindScript : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float windForce = 0.04f;
    [SerializeField] private WindScriptTimer windScriptTimer;
    public bool safeArea;

    //checks whether player is in the set area, then if wind is active, then if the player is in the safe zone
    void OnTriggerStay(Collider other)
    {
        if (windScriptTimer.windActive)
        {
            if (!safeArea)
            {
                //launches player to the side
                player.GetComponent<Rigidbody>().AddForce(0, 0, -windForce, ForceMode.VelocityChange);
            }
        }
    }
}