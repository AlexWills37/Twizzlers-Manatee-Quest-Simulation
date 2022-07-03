using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script limits the player's movement during the cutscene.
/// 
/// @author Alex Wills
/// Updated 6/26/22
/// </summary>
[RequireComponent(typeof(NewPlayerController))]
[RequireComponent(typeof(NewVerticalMovement))]
public class PlayerCutsceneMovement : MonoBehaviour
{
    [Tooltip("Camera rig that controls the player's direction.")]
    [SerializeField] private GameObject cameraRig;

    private Behaviour playerHorizontalMovement;
    private Behaviour playerVerticalMovement;

    // Start is called before the first frame update
    void Start()
    {
        // At the start, disable the scripts
        playerHorizontalMovement = this.GetComponent<NewPlayerController>();
        playerVerticalMovement = this.GetComponent<NewVerticalMovement>();

        playerHorizontalMovement.enabled = false;
        playerVerticalMovement.enabled = false;

        // Ensure the player is facing the manatee
        cameraRig.transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableHorizontalMovement()
    {
        playerHorizontalMovement.enabled = true;
    }

    public void EnableVerticalMovement()
    {
        playerVerticalMovement.enabled = true;
    }
}
