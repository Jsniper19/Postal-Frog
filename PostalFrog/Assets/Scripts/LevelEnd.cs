using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    [SerializeField] private GameObject DeathManager;
    [SerializeField] private GameObject Player;

    bool lv1 = true;
    // Update is called once per frame
    void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Player")
        {
            if (lv1)
            {
                StartCoroutine(Pause1());
            }
            else
            {
                StartCoroutine(Pause2());
            }
        }
    }

    IEnumerator Pause1()
    {
        Player.GetComponent<PlayerController>().PLAY = false;
        yield return new WaitForSeconds(3);
        DontDestroyOnLoad(DeathManager);
        SceneManager.LoadScene("CraneLevel");
    }
    IEnumerator Pause2()
    {
        Player.GetComponent<PlayerController>().PLAY = false;
        yield return new WaitForSeconds(3);
        Application.Quit();
    }
}
