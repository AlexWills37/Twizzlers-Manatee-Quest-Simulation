using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This script is changing the scene when the player collides with an apple.
 * It is attached to the apple object in the "Be a Manatee" Scene.
 * 
 * @author Sami Cemek
 * Updated: 5/20/21
 */

public class ChangeScene : MonoBehaviour
{
    void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player") //if an object tagged "Player" collides with it
        {
            Debug.Log("Highlighted Area Collided with the player");
            SceneManager.LoadScene(2); //change the scene to index 1 scene
        }
    }
}