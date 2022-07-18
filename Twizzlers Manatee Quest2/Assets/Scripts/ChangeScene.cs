using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This script is changing the scene when the player collides with an apple.
 * It is attached to the apple object in the "Be a Manatee" Scene.
 * 
 * @author Sami Cemek
 * @author Alex Wills
 * Updated: 6/20/22
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

    /// <summary>
    /// Load a scene using this script. Can be called from Unity Events, for example.
    /// </summary>
    /// <param name="sceneIndex"> the scene to transition to. </param>
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    /// <summary>
    /// Load the next scene in order of the build settings.
    /// If the game is at the last scene, it should wrap back around to the first scene.
    /// </summary>
    public void LoadNextScene()
    {
        SceneManager.LoadScene((SceneManager.GetActiveScene().buildIndex + 1) % SceneManager.sceneCountInBuildSettings);
    }
}