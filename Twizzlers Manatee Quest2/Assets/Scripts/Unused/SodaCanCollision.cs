using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
/// Checks if the “Sphere” named object collides with the soda can.If yes, destroy the soda can.
/// 
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>


public class SodaCanCollision : MonoBehaviour
{
    public AudioSource audioSource;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "SodaSphere") //if the object collides with "Sphere" named object
        {
            Debug.Log("The soda can collided with sphere");
            Destroy(this.transform.gameObject); //destroy that object
            audioSource.Play();
        }
    }
}
