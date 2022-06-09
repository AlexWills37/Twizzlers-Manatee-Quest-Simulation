using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is checking if the "Player" tagged object enters & exits the grass objects trigger zone. 
 * It triggers the chew particle system effect, bubbles, and an increase in the health bar.
 * 
 * @author Sami Cemek
 * Updated: 07/08/21
 */
public class GrassTrigger : MonoBehaviour
{
    [SerializeField] private GameObject grassObj;
    [SerializeField] private GameObject bubbleObj;
    [SerializeField] private GameObject chewParticleEffect;
    private bool justAte = false;
    [SerializeField] private int ateGrassNum;
    //[SerializeField] private Animator myAnimationController;

    // Start is called before the first frame update
    void Start()
    {
        //ateGrassNum = 0;
        grassObj.SetActive(true);
        bubbleObj.SetActive(false);
        chewParticleEffect.SetActive(false);
        //myAnimationController.SetBool("playBubble", false);
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")                  //if an object tagged "Player" enters the trigger zone
        {
            grassObj.SetActive(false);                          //remove the grass object from the scene
            //myAnimationController.SetBool("playBubble", true);  //start animation
            bubbleObj.SetActive(true);
            chewParticleEffect.SetActive(true);
            StartCoroutine("WaitAndDisplay");

            if (justAte == false)
            {
                PlayerScript.currentHealth += 5;
                PlayerScript.ateGrassNum += 1;
            }

            if (PlayerScript.ateGrassNum == 2)
            {
                //PlayerScript.currentHealth = 100;
                Debug.Log("Health will not decrese anymore");
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        if (player.gameObject.tag == "Player")       //if an object tagged "Player" exits the trigger zone
        {
            justAte = true;
        }
    }

    IEnumerator WaitAndDisplay()
    {
        Debug.Log("coroutine started");
        chewParticleEffect.SetActive(true);

        yield return new WaitForSeconds(8f);

        chewParticleEffect.SetActive(false);
        Debug.Log("coroutine ended");

    }
}
