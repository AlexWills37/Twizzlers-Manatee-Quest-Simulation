using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script checks if grass objects collide with "Player" tagged objects.
 * 
 * @author Sami Cemek
 * Updated: 07/06/21
 */

public class DestroyGrass : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //if the object collides with player tagged object
        {
            Debug.Log("The player collided with a grass");
            Destroy(this.transform.gameObject); //destroy that object
        }
    }
}
