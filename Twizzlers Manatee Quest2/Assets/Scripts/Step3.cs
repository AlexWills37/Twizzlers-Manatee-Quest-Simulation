using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
/// This script is checking if the "Boat" tagged object enters the trigger zone.
/// If yes triggers the animation, plays an audio, change the happs/sad meter emoji.
///
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>

public class Step3 : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;
    [SerializeField] private GameObject SadEmoji;
    [SerializeField] private GameObject HappyEmoji;
    [SerializeField] private GameObject Trigger4;
    [SerializeField] private AudioSource ManateePainVocal;

    void Start()
    {
        HappyEmoji.SetActive(true);
        SadEmoji.SetActive(false);
        Trigger4.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boat")
        {
            myAnimationController.SetBool("step3", true);
            HappyEmoji.SetActive(false);
            SadEmoji.SetActive(true);
            Trigger4.SetActive(true);
            ManateePainVocal.Play();
        }
    }

}
