using UnityEngine;

public class WindScriptEffects : MonoBehaviour
{
    public WindScriptTimer windScriptTimer;
    public ParticleSystem windEffect;
    public bool windOn;
    public GameObject windArea;
    public AudioClip windSound;
    private AudioSource windSource;

    //makes noise
    private void Awake()
    {
        windSource = windArea.GetComponent<AudioSource>();
    }

    private void Update()
    {
        //checks whether windActive variable is equal to the local objects windOn check then activates or deactivates relevant particle system
        if (windScriptTimer.windActive == windOn)
        {
            windEffect.Play();
            windSource.PlayOneShot(windSound);
        }
        else if (windScriptTimer.windActive != windOn)
        {
            windEffect.Stop();
            windEffect.Clear();
        }
    }
}
