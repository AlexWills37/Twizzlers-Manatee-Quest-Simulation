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
    private ManateeNameChooser manateeNames;


    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(ResetGame);
        manateeNames = ManateeNameChooser.singleInstance;
    }

    /// <summary>
    /// Loads the first scene.
    /// </summary>
    private void ResetGame()
    {
        int timeInScene = (int)Time.timeSinceLevelLoad;
        TelemetryManager.entries.Add(
            new TelemetryEntry("restart", "",timeInScene)
        );
        SceneManager.LoadScene(0);

        //if(manateeNames != null)
        //{
        //    manateeNames.ResetNames();
        //}
    }


}
