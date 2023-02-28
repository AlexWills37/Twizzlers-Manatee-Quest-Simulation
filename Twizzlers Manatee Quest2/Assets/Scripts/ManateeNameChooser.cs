using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Allows you to choose the manatee's names using buttons.
/// This script has a static list of chosen names, which can be accessed by the manatees to find their name.
/// An indicator will show you which name you are currently changing. Calling ChooseName() will set the currently selected name
/// and move on to the next name. Once you choose all names, the indicator will go back to the first name, allowing the player
/// to change their mind if they want.
/// 
/// 
/// Make sure that every text object in nameTexts (the list of text objects to list the currently selected manatee names)
/// has an indicator as its first child. This indicator should show that the current text is selected. Only 1 indicator will show
/// at once, marking the name that is currently up for selection.
/// </summary>
public class ManateeNameChooser : MonoBehaviour
{

    // The names selected by the player
    public static string[] chosenNames { get; private set; } 

    // Singleton/static instance to access this chooser
    public static ManateeNameChooser singleInstance { get; private set; }

    [Tooltip("The text objects to display the chosen names with. Each text object should also have an indicator object as a child.")]
    [SerializeField] private TextMeshProUGUI[] nameTexts;
    private GameObject[] nameTextSelectors;

    private int currentManatee; // The index of the currently selected manatee

    private IntroButtonLinker slideButtonControl;   // Prevents the user from continuing the scene until they choose manatee names

    // Start is called before the first frame update
    void Start()
    {
        // Set this as the single instance
        singleInstance = this;
        chosenNames = new string[nameTexts.Length];
        nameTextSelectors = new GameObject[nameTexts.Length];   

        // Iterate through the name texts to get their indicators and turn them all off
        GameObject selectorObject;
        TextMeshProUGUI nameText;
        for(int i = 0; i < nameTexts.Length; i++)
        {
            nameText = nameTexts[i];

            // The selector object will be the first child of the text object
            selectorObject = nameText.gameObject.transform.GetChild(0).gameObject;
            selectorObject.SetActive(false);
            nameTextSelectors[i] = selectorObject;
        }

        // Keep the first indicator on
        nameTextSelectors[0].SetActive(true);

        // Get the button linker
        slideButtonControl = this.GetComponent<IntroButtonLinker>();
    }

    /// <summary>
    /// Lock the slide continue button when this game object is enabled
    /// </summary>
    private void OnEnable()
    {
        // Ensure button linker exists
        if(slideButtonControl == null)
        {
            slideButtonControl = this.GetComponent<IntroButtonLinker>();
        }
        slideButtonControl.LockButton("Name your friends!");
    }

    /// <summary>
    /// Select a manatee name.
    /// </summary>
    /// <param name="selectedName"> the manatee name to add to the list </param>
    public void ChooseName(string selectedName)
    {
        // Add an entry for the selected name. -EF
        TelemetryManager.entries.Add(
            new TelemetryEntry("nameSelected", selectedName)
        );

        // Change the static list to choose the name
        chosenNames[currentManatee] = selectedName;

        // Update the text
        nameTexts[currentManatee].SetText("Manatee " + (currentManatee + 1) + ": " + selectedName);

        // Disable this manatee's indicator
        nameTextSelectors[currentManatee].SetActive(false);

        // Move to the next name
        currentManatee = (currentManatee + 1) % chosenNames.Length;

        // Enable the next manatee's indicator
        nameTextSelectors[currentManatee].SetActive(true);

        // Ensure the button is unlocked when the user has selected all names
        // (This occurs when we loop back to the first manatee, when the first manatee has been assigned a name already)
        if(currentManatee == 0 && chosenNames[0] != "" && slideButtonControl != null)
        {
            slideButtonControl.UnlockButton();
        }
    }
}
