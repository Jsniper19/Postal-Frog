using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerText : MonoBehaviour
{
    [SerializeField] Text Message;
    public AudioClip SoundToPlay;
    AudioSource soundSource;
    [SerializeField] string text = "Victory";
    // Start is called before the first frame update
    void Start()
    {
        soundSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Message.text = text;
        soundSource.PlayOneShot(SoundToPlay);
    }

    private void OnTriggerExit(Collider other)
    {
        Message.text = "";
    }
}
