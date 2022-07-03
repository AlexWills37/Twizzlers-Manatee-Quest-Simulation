using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
/// This script is checking if the "Player" tagged object enters the trigger zone.
/// If yes plays audio and sets the UI canvas active. This script is used for 
/// mini task 1 in the menu/training scene.
///
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>

public class TrashTrigger : MonoBehaviour
{
    public GameObject UIObject;
    public AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //UIObject.SetActive(false);
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            UIObject.SetActive(true);
            audioSource.Play();
        }
    }

    void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            UIObject.SetActive(false);
        }
    }
}
