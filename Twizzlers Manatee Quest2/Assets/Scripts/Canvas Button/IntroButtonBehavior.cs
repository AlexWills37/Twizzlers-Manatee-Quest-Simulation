using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
/// When the user presses the continue button:
///     1. The button will be disabled
///     2. A coroutine to reactivate the button after a certain amount of time will start
///     3. The slide will transition, disabling the current slide and enabling the next slide game object
///     3a. If this is the last slide, disable the button game object to stop the player from continuing
///     
/// You may want to control whether the user can press the button externally (like waiting until they choose
/// manatee names before continuing).
/// To do this, use the IntroButtonLinker script to call the DisableButton(string message) method to stop
/// the reactivation timer and display a custom message on the button.
/// Then use the EnableButton() method to renable the button and the reactivation timer for the next button press.
/// 
/// 
/// @author Alex Wills
/// Updated 2/14/2023
/// </summary>

[RequireComponent(typeof(Button))]
public class IntroButtonBehavior : MonoBehaviour
{

    [Tooltip("List of canvas groups in the order to display to the user.")]
    [SerializeField] private GameObject[] slides;

    [Tooltip("After the user clicks the button, how many seconds to wait before making it clickable again.")]
    [SerializeField] private float buttonDelay = 3f;



    private Button buttonContinue; // The button the player clicks to continue the introduction
    private TextMeshProUGUI buttonTextObject; // The text on the button
    private int currentSlide = 0;


    private IEnumerator reactivationTimer;  // This is the coroutine that can be stopped if the button's status should be controlled externally

    private string buttonActiveText;   // The text to display when the button is active (retrieved from the button's initial text)

    // Start is called before the first frame update
    void Start()
    {
        // Link this script to the button press event
        buttonContinue = this.GetComponent<Button>();
        buttonContinue.onClick.AddListener(OnButtonClick);
        buttonTextObject = buttonContinue.transform.GetChild(0).GetComponent<TextMeshProUGUI>();
        buttonActiveText = buttonTextObject.text;

        // Ensure slides are initialized properly
        if (slides.Length == 0)
        {
            Debug.LogError("No slides listed in the Intro Button list!");
        } else
        {
            // Initialize slides by deactivating all except for the first
            if (slides[0] != null)
            {
                slides[0].SetActive(true);
            } else
            {
                Debug.LogError("Slide 0 is not configured in the Intro Button List!");
            }

            for (int i = 1; i < slides.Length; i++)
            {
                if (slides[i] != null)
                {
                    slides[i].SetActive(false);
                } else
                {
                    Debug.LogError("Slide " + i + " is not configured in the Intro Button List!");
                }
            }

        }

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnButtonClick();
        }
    }

    /// <summary>
    /// Take control of the button's activation by manually disabling it.
    /// This will stop the reactivation timer from automatically progressing the button.
    /// </summary>
    /// <param name="deactiveMessage"> The message to display on the button </param>
    public void DisableButton(string deactiveMessage = "")
    {
        // Prevent reactivation timer from re-enabling button
        StopCoroutine(reactivationTimer);

        // Disable button
        buttonContinue.interactable = false;
        buttonTextObject.SetText(deactiveMessage);
    }

    /// <summary>
    /// Re-enable the button manually and allow for the reactivation timer
    /// to control the next button press.
    /// </summary>
    public void EnableButton()
    {
        // Re-enable button and bring back its active text
        buttonContinue.interactable = true;
        buttonTextObject.SetText(buttonActiveText);
    }


    /// <summary>
    /// This function is called when the user presses the button attached to this game object.
    /// When the user presses the button, transition to the next slide.
    /// </summary>
    private void OnButtonClick()
    {
        // Temporarily disable the button
        buttonContinue.interactable = false;
        buttonTextObject.SetText("");

        // Begin reactivation timer and transition to the next slide
        // Ensrue only 1 coroutine occurs at once
        if(reactivationTimer != null)
        {
            StopCoroutine(reactivationTimer);
        }
        reactivationTimer = ReactivateButton(buttonDelay);
        StartCoroutine(reactivationTimer);
        NextSlide();
    }

    /// <summary>
    /// Coroutine to wait a specified amount of time before reactivating the button.
    /// </summary>
    /// <param name="delay"> time (in seconds) to wait before reactivating the button. </param>
    /// <returns></returns>
    private IEnumerator ReactivateButton(float delay)
    {

        yield return new WaitForSeconds(delay);


        // Bring text back and make button interactable again
        buttonContinue.interactable = true;
        buttonTextObject.SetText(buttonActiveText);
    }


    /// <summary>
    /// Transition the slides by deactivating the current slide and activating the next.
    /// If the last slide is reached, the function OnLastSlide will be called.
    /// If this is called when the user is already on the last slide, it will restart at the beginning.
    /// </summary>
    private void NextSlide()
    {
        // Transition slides if possible
        if(slides[currentSlide] != null)
        {
            slides[currentSlide].SetActive(false);
        }

        // Progress to the next slide, looping to the beginning if we surpass the last slide
        currentSlide = (currentSlide + 1) % slides.Length;
        
        if(slides[currentSlide] != null)
        {
            slides[currentSlide].SetActive(true);
        }

        // Check if we are at the last slide
        if (currentSlide == slides.Length - 1)
        {
            OnLastSlide();
        }
    }

    /// <summary>
    /// This function is called when the user progresses to the last slide.
    /// For the intro button, the user should not restart the slide show. 
    /// Therefore this button will be deactivated when the user makes it to the last slide.
    /// </summary>
    private void OnLastSlide()
    {
        this.gameObject.SetActive(false);
    }
}
