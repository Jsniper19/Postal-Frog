using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WindSlider : MonoBehaviour
{
    public Slider slider;
    public WindScriptTimer windScriptTimer;
    public Image fill;
    float offTime;
    float onTime;
    float totalTime = 0f;

    // Start is called before the first frame update
    void Start()
    {
        offTime = windScriptTimer.windDownTime;
        onTime = windScriptTimer.windUpTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (windScriptTimer.windActive == false)
        {
            fill.color = Color.white;
            totalTime += Time.deltaTime / offTime;
            slider.value = Mathf.Lerp(0, 1, totalTime);
        }
        else if (windScriptTimer.windActive == true)
        {
            totalTime -= Time.deltaTime / onTime;
            slider.value = Mathf.Lerp(0, 1, totalTime);
            fill.color = Color.red;
        }
    }
}
