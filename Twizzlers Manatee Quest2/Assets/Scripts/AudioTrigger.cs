using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject buttonPlaying;
    public GameObject buttonPlay;
    private IEnumerator coroutine;

    void Start()
    {
        buttonPlaying.SetActive(false);
    }


    public void PlayAudio()
    {
        audioSource.Play();
        StartCoroutine("WaitAndDisplay");
    }

    IEnumerator WaitAndDisplay()
    {
        Debug.Log("coroutine started");
        buttonPlaying.SetActive(true);
        buttonPlay.SetActive(false);

        yield return new WaitForSeconds(10f);

        buttonPlaying.SetActive(false);
        buttonPlay.SetActive(true);
        Debug.Log("coroutine ended");

    }
}
