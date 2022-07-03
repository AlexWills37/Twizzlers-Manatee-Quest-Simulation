using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyManatee : MonoBehaviour
{
    [SerializeField] private GameObject grassObj;
    //[SerializeField] private GameObject bubbleObj;
    //[SerializeField] private GameObject chewParticleEffect;

    // Start is called before the first frame update
    void Start()
    {
        grassObj.SetActive(true);
        //bubbleObj.SetActive(false);
        //chewParticleEffect.SetActive(false);
        //myAnimationController.SetBool("playBubble", false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Baby Manatee")             //if an object tagged "Player" enters the trigger zone
        {
            grassObj.SetActive(false);                          //remove the grass object from the scene
            //myAnimationController.SetBool("playBubble", true);  //start animation
            //bubbleObj.SetActive(true);
            //chewParticleEffect.SetActive(true);
            //StartCoroutine("WaitAndDisplay");
        }
    }
}
