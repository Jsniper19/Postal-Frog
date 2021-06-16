using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindScriptEffects : MonoBehaviour
{
    public GameObject player;
    public WindScriptTimer windScriptTimer;
    public ParticleSystem windEffect;
    public bool windOn;
    public GameObject windArea;
    public AudioClip windSound;
    private AudioSource windSource;

    private void Awake()
    {
        windSource = windArea.GetComponent<AudioSource>();
    }

    private void Update()
    {
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
