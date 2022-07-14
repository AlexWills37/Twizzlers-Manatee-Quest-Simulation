using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Configures a button to restart the simulation and load the first scene
/// when the button is pressed.
/// 
/// @author Alex Wills
/// Updated 7/13/2022
/// </summary>
/// 
[RequireComponent(typeof(Button))]
public class RestartSimulationButton : MonoBehaviour
{
    private Button button;


    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ResetGame);
    }

    /// <summary>
    /// Loads the first scene.
    /// </summary>
    private void ResetGame()
    {
        SceneManager.LoadScene(0);
    }
}
