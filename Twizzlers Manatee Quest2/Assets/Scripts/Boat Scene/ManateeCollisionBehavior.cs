using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script attaches to the manatee's rigidbody object to detect the boat collision and react accordingly.
/// 
/// There might be a better way to do this, but the hierarchy is weird because we're trying to move the manatee specifically
/// with an animator and animation controller, and then use physics to simulate the boat hit.
/// Ideally, this would all be in one neat script, instead of being split between this script and 
/// ManateeBoatSceneBehavior.cs
/// 
/// @author Alex Wilss
/// </summary>
public class ManateeCollisionBehavior : MonoBehaviour
{
    [Tooltip("Script controlling the manatee's position and animation on the highest level")]
    [SerializeField] private ManateeBoatSceneBehavior animationScript;

    private Rigidbody rb;

    [Tooltip("Bubble particles to release on collision")]
    [SerializeField] private ParticleSystem injuryBubbles;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        // When the boat hits, call the boat hit method 
        if (collision.gameObject.CompareTag("Boat"))
        {
            //  rb.AddForce(collision.impulse, ForceMode.Impulse);
            animationScript.BoatCollision();
            injuryBubbles.Play();
            Debug.Log("Boat hit");
        }
    }
}
