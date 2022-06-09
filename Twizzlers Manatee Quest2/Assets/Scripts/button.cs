using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * This script is changing the scene when the button press happens. It is attached to the "PLAY"
 * button on the menu scene.
 * 
 * @author Sami Cemek
 * Updated: 08/20/21
 */

public class button : MonoBehaviour
{
    /*
    void Awake()
    {
        Debug.Log("Awake: " + SceneManager.GetActiveScene().name + " Starting Time: " + System.DateTime.Now);
    }
    */

    public void NextScene()
    {
        //Main.content = "2nd scene: " + SceneManager.GetActiveScene().name + " Starting Time: " + System.DateTime.Now;
        SceneManager.LoadScene(1);
    }
}
