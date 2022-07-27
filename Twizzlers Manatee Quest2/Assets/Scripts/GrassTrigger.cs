using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is checking if the "Player" tagged object enters & exits the grass objects trigger zone. 
 * It triggers the chew particle system effect, bubbles, and an increase in the health bar.
 * 
 * @author Sami Cemek
 * @author Alex Wills
 * Updated: 07/13/2022
 */
public class GrassTrigger : MonoBehaviour
{
    [Tooltip("The grass model to remove when the grass is eaten.")]
    [SerializeField] private GameObject grassObj;

    [Tooltip("Bubble particles to activate when the grass is eaten.")]
    [SerializeField] private GameObject bubbleObj;

    private bool justAte = false;
    //[SerializeField] private Animator myAnimationController;

    [Tooltip("How many health points eating this will recover")]
    [SerializeField] private float healthValue = 5;

    // Start is called before the first frame update
    void Start()
    {
        grassObj.SetActive(true);
        bubbleObj.SetActive(false);
    }

    public void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")                  //if an object tagged "Player" enters the trigger zone
        {
            grassObj.SetActive(false);                          //remove the grass object from the scene
            bubbleObj.SetActive(true);

            // When eaten, increase player health and give haptic feedback.
            if (justAte == false)
            {
                TelemetryManager.entries.Add(
                    new TelemetryEntry("grassEaten", Vec3.from(grassObj.transform.position))
                );
                PlayerScript.currentHealth += healthValue;
                PlayerScript.ateGrassNum += 1;
                HapticFeedback.singleton.TriggerVibrationTime(0.2f);
            }
        }
    }

    private void OnTriggerExit(Collider player)
    {
        // Make sure that the player cannot eat the same seagrass multiple times
        if (player.gameObject.tag == "Player")       //if an object tagged "Player" exits the trigger zone
        {
            justAte = true;
        }
    }

}
