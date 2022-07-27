using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Text object (TMPro) to display a chosen manatee name.
/// Attach this to the text object to store the manatee's name.
/// Use the inspector to select which manatee this is.
/// </summary>
public class ManateeNameLabel : MonoBehaviour
{
    [Tooltip("Which number manatee this is (0 for manatee 1, 1 for manatee 2, etc.). Used for naming the manatee.")]
    [SerializeField] private int manateeIndex;

    [Tooltip("Check this box if the manatee should have \"Jr.\" at the end of its name.")]
    [SerializeField] private bool junior;

    private TextMeshProUGUI nameLabel;

    // Start is called before the first frame update
    void Start()
    {
        nameLabel = this.GetComponent<TextMeshProUGUI>();
        string name;

        // Make sure that the name exists
        if(ManateeNameChooser.chosenNames == null)
        {
            Debug.Log("Scenes occurred out of order, and no manatee names were chosen.");

        } else if(manateeIndex < ManateeNameChooser.chosenNames.Length)
        {
            name = ManateeNameChooser.chosenNames[manateeIndex];

            // If no name was chosen, default to Sprinkles
            if(name == "")
            {
                name = "Sprinkles";
            }

            // Add jr. if this manatee is a jr.
            if (junior)
            {
                name += " Jr.";
            }

            nameLabel.SetText(name);
        }

    }
}
