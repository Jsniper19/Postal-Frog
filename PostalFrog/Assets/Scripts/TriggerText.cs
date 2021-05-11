using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerText : MonoBehaviour
{
    [SerializeField] Text Victory;
    public AudioClip SoundToPlay;
    AudioSource soundSource;
    // Start is called before the first frame update
    void Start()
    {
        soundSource = gameObject.GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Victory.text = "Post Delivered!";
        soundSource.PlayOneShot(SoundToPlay);
    }
}
