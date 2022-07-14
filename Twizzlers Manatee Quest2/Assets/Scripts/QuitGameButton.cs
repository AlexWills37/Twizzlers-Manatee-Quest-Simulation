using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Configures a button to quit the game when pressed.
/// 
/// @author Alex Wills
/// Updated 7/13/2022
/// </summary>
/// 

[RequireComponent(typeof(Button))]
public class QuitGameButton : MonoBehaviour
{
    private Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = this.GetComponent<Button>();
        button.onClick.AddListener(QuitGame);
    }

    /// <summary>
    /// Closes the application.
    /// </summary>
    private void QuitGame()
    {
        Application.Quit();
    }
}
