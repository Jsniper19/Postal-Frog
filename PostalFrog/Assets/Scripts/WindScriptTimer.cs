using System.Collections;
using UnityEngine;

public class WindScriptTimer : MonoBehaviour
{
    public float windDownTime = 5.0f;
    public float windUpTime = 10.0f;
    public float windTime;
    [SerializeField] private WindSlider windSlider;

    public bool windActive = false;

    //creates the wind loop
    void Start()
    {
        //totals the wind up and down time to a total time then fires off a function with breaks the length of the total time
        windTime = windUpTime + windDownTime;
        InvokeRepeating("Wind", windDownTime, windTime);
    }

    //small hack to fire off coroutine instead of function
    void Wind()
    {
        StartCoroutine(WindUp());
    }

    //activates then deactivates wind after a short period
    IEnumerator WindUp()
    {
        windActive = true;
        windSlider.totalTime = 1;
        yield return new WaitForSecondsRealtime(windUpTime);
        windActive = false;
        windSlider.totalTime = 0;
    }
}
