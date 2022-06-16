using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines the tutorial kelp. When the player eats this kelp, it will progress the tutorial to the next step.
/// Attach this script to the cylinder with the collider.
/// 
/// Game object hierarchy should be:
/// > Kelp
///   > Kelp Model
///   > Cylinder (attach this script here!)
///   > Bubble particle system
///   > Spot light
/// 
/// @author Alex Wills
/// Updated 6/14/2022
/// </summary>
public class TutorialFoodBehavior : MonoBehaviour
{

    private GameObject bubbleParticles;
    private GameObject grassModel;
    private GameObject spotlight;

    // Start is called before the first frame update
    void Start()
    {
        Transform kelp = this.transform.parent;
        grassModel = kelp.GetChild(0).gameObject;
        bubbleParticles = kelp.GetChild(2).gameObject;
        spotlight = kelp.GetChild(3).gameObject;

        bubbleParticles.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // When the player collides, move on to tutorial step 2
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerScript.currentHealth += 10;
            TutorialBehavior.singleton.CompleteTaskAndProgress(2);

            // Turn the grass into bubbles and turn off the spotlight
            grassModel.SetActive(false);
            bubbleParticles.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }
}
