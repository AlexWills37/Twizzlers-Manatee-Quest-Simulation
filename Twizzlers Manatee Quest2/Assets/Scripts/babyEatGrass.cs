using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is checking if "Baby Manatee" tagged object collides with seagrass. If yes, destroy the grass object.
 * 
 * @author Sami Cemek
 * Updated: 08/20/21
 */

public class babyEatGrass : MonoBehaviour
{
    [SerializeField] private GameObject grassObj;

    void Start()
    {
        grassObj.SetActive(false); //initially set active false so the player doesn't see the seagrass attached to the fin.
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Baby Manatee") //if the object collides with "Baby Manatee" tagged object
        {
            grassObj.SetActive(true);            //set active, make it visible
            Debug.Log("The Baby Manatee collided with a grass");
            Destroy(this.transform.gameObject); //destroy that object
        }
    }
}
