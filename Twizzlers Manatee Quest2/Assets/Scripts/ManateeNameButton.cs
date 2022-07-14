using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// This script connects the manatee name buttons with the ManateeNameChooser script.
/// It does this by adding event listeners to the buttons to send this button's text to the ManateeNameChooser
/// when clicked on.
/// 
/// @author Alex Wills
/// Updated 7/12/2022
/// </summary>
public class ManateeNameButton : MonoBehaviour
{

    private Button nameButton;
    private string manateeName;

    private ManateeNameChooser selector;

    // Start is called before the first frame update
    void Start()
    {
        // Get the name of the button and the button itself
        nameButton = this.GetComponent<Button>();
        manateeName = this.GetComponentInChildren<TextMeshProUGUI>().text;

        // When the button is clicked, call the ClickButton method to communicate with ManateeNameChooser
        nameButton.onClick.AddListener(ClickButton);
        selector = ManateeNameChooser.singleInstance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Call the ManateeNameChooser's public choose name method, giving this button's name as a parameter
    /// </summary>
    public void ClickButton()
    {
        selector.ChooseName(manateeName);
    }
}
