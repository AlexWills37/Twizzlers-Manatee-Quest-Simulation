using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * Defines the button behavior for interaction in the first welcome scene.
 * This button will be used to allow the user to progress through the beginning of the game smoothly.
 * 
 * @author Alex Wills
 * @date Feb 14, 2023
 */

/// <summary>
/// Continue button behavior
/// Defines the button behavior for interaction in the first welcome scene.
/// This button will be used to allow the user to progress through the beginning of the game smoothly.
/// 
/// @author Alex Wills
/// Updated 2/14/2023
/// </summary>

[RequireComponent(typeof(Button))]
public class IntroButtonBehavior : MonoBehaviour
{

    [Tooltip("After the user clicks the button, how many seconds to wait before making it clickable again.")]
    [SerializeField] private float buttonDelay = 3f;   

    private Button button_continue; // The button the player clicks to continue the introduction

    // Start is called before the first frame update
    void Start()
    {
        button_continue = this.GetComponent<Button>();
        button_continue.onClick.AddListener(OnButtonClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// 
    /// </summary>
    private void OnButtonClick()
    {
        // Temporarily disable the button
        button_continue.interactable = false;
        ReactivateButton(3f);
    }

    /// <summary>
    /// Coroutine to wait a specified amount of time before reactivating the button.
    /// </summary>
    /// <param name="delay"> time (in seconds) to wait before reactivating the button. </param>
    /// <returns></returns>
    private IEnumerator ReactivateButton(float delay)
    {
        yield return new WaitForSeconds(delay);
        button_continue.interactable = true;
    }
}
