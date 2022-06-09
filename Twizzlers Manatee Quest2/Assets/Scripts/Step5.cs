using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
/// This script is checking if the "Manatee" tagged object enters the trigger zone.
/// If yes triggers the animation.
///
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>

public class Step5 : MonoBehaviour
{
    [SerializeField] private Animator myAnimationController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Manatee")
        {
            myAnimationController.SetBool("step5", true);
        }
    }

}
