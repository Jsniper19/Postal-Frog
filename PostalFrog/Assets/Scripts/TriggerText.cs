using UnityEngine;
using UnityEngine.UI;

public class TriggerText : MonoBehaviour
{
    [SerializeField] Text Message;
    [SerializeField] string text = "Victory";
    public AudioClip SoundToPlay;
    AudioSource soundSource;

    void Start()
    {
        soundSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
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
