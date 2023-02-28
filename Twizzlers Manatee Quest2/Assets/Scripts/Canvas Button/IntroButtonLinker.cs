using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Allows for game objects to interact with the slide show button that controls
/// the informational intro scene.
/// 
/// @author Alex Wills
/// @date February 27, 2023
/// </summary>
public class IntroButtonLinker : MonoBehaviour
{

    private static IntroButtonBehavior slideButton;

    // Start is called before the first frame update
    void Start()
    {
        // Find a single instance of the continue button
        if(slideButton == null)
        {
            slideButton = GameObject.Find("Slide Continue Button").GetComponent<IntroButtonBehavior>();
        }
    }

    /// <summary>
    /// Locks the button and prevents the user from clicking it
    /// until it is unlocked.
    /// </summary>
    /// <param name="buttonText"> the text to display on the locked button (for example: how to unlock the button) </param>
    public void LockButton(string buttonText)
    {
        slideButton.DisableButton(buttonText);
    }

    /// <summary>
    /// Re-enable the button, allowing the user to click it once again.
    /// </summary>
    public void UnlockButton()
    {
        slideButton.EnableButton();
    }
}
