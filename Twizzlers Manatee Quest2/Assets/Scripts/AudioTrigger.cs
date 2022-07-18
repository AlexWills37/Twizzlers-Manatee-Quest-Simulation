using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Plays audio from a button press.
/// 
/// @author Sami Cemek
/// @author Alex Wills
/// Updated 7/13/2022
/// </summary>
public class AudioTrigger : MonoBehaviour
{
    [Tooltip("Audio to play on the button press.")]
    public AudioSource audioSource;
    
    [Tooltip("Button to display when the audio is playing.")]
    public GameObject buttonPlaying;

    [Tooltip("Button to display when the audio is not playing.")]
    public GameObject buttonPlay;

    private IEnumerator coroutine;

    void Start()
    {
        buttonPlaying.SetActive(false);

    }


    /// <summary>
    /// Plays the audio and changes the button to reflect this.
    /// Call this method when the buttonPlay button is pressed.
    /// </summary>
    public void PlayAudio()
    {
        StartCoroutine(PlaySound());
    }

    /// <summary>
    /// Coroutine to play the audio clip and change the buttons to show that the audio is playing.
    /// </summary>
    /// <returns></returns>
    IEnumerator PlaySound()
    {
        // Swap buttons to show that it is playing
        buttonPlaying.SetActive(true);
        buttonPlay.SetActive(false);

        // Wait until the audio source is no longer playing
        audioSource.Play();
        yield return new WaitForSeconds(10f);

        // Swap buttons to show that the audio can be played again
        buttonPlaying.SetActive(false);
        buttonPlay.SetActive(true);


    }
}
