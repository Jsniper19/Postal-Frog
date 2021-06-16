using UnityEngine;
using UnityEngine.UI;

public class WindSlider : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private WindScriptTimer windScriptTimer;
    [SerializeField] private Image fill;
    [SerializeField] string text = "Wind Active";
    [SerializeField] Text WindWarningText;
    public float totalTime = 0f;

    void Update()
    {
        //sets slider colour to white and makes slider rise to max value while high wind is inactive to show how long you have left
        if (!windScriptTimer.windActive)
        {
            fill.color = Color.white;
            totalTime += Time.deltaTime / windScriptTimer.windDownTime;
            slider.value = Mathf.Lerp(0, 1, totalTime);
            WindWarningText.text = "";
        }
        //sets slider colour to red and makes slider fall to min value while wind is active
        else if (windScriptTimer.windActive)
        {
            totalTime -= Time.deltaTime / windScriptTimer.windUpTime;
            slider.value = Mathf.Lerp(0, 1, totalTime);
            fill.color = Color.red;
            WindWarningText.text = text;

        }
    }
}