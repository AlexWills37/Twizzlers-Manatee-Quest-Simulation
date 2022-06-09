using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
/// This script is checking if the "Player" tagged object enters the trigger zone.
/// If yes triggers the animation and enables the Mover.cs script.
///
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>


public class Step1 : MonoBehaviour
{
    public Animator myAnimationController;
    public GameObject VRCameraRig;

    void Start()
    {
         Animator myAnimationController;
         GameObject VRCameraRig = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")
        {
            myAnimationController.SetBool("step1", true);
            VRCameraRig.GetComponent<Mover>().enabled = true;
        }
    }

}
