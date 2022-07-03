using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is used to display a pop-up to teach the player to boop manatees.
/// The text will display when the user is in range of a manatee, and it will last for 5 seconds.
/// 
/// @author Alex Wills
/// Updated 6/26/22
/// </summary>
public class TeachSocialManatee : MonoBehaviour
{
    [Tooltip("The popup to display when the manatee is in range of the player.")]
    [SerializeField] private GameObject popup;

    // Boolean to make sure we only display the popup once.
    private bool popupDisplayed = false;

    // Start is called before the first frame update
    void Start()
    {
        popup.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /// <summary>
    /// Display the popup for 5 seconds and prevent this script from displaying the popup again.
    /// </summary>
    /// <returns> This ongoing coroutine as an IEnumerator </returns>
    private IEnumerator DisplayPopup()
    {
        popupDisplayed = true;
        popup.SetActive(true);

        yield return new WaitForSeconds(5f);

        popup.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Once, if the player collides with a manatee, display the popup.
        if (!popupDisplayed && other.gameObject.CompareTag("Manatee"))
        {
            StartCoroutine(DisplayPopup());
        }
    }
}
