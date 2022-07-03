using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the manatee that will get hit by a boat in the boat scene.
/// 
/// @author Alex Wills
/// Updated 6/26/2022
/// </summary>
[RequireComponent(typeof(ManateeBehavior2))]
public class ManateeBoatSceneBehavior : MonoBehaviour
{
    private ManateeBehavior2 manateeAI;

    [Tooltip("Animator that makes the boat speed through the manatee's position.")]
    [SerializeField] private Animator boatAnimator;

    [Tooltip("Player script to control movement.")]
    [SerializeField] private PlayerCutsceneMovement playerMovement;

    [Tooltip("Popup to display with information on boat strikes.")]
    [SerializeField] private GameObject boatStrikeInfo;

    [Tooltip("Scarred manatee texture after the boat hit.")]
    [SerializeField] private Texture2D scarManateeTexture;

    [Tooltip("Manatee texture before the boat hit, without scars.")]
    [SerializeField] private Texture2D normalManateeTexture;

    [Tooltip("Material being used by the manatee mesh.")]
    [SerializeField] private Material manateeMaterial;

    // Start is called before the first frame update
    void Start()
    {
        manateeAI = this.GetComponent<ManateeBehavior2>();

        manateeAI.enabled = false;


        boatStrikeInfo.SetActive(false);

        manateeMaterial.SetTexture("_MainTex", normalManateeTexture);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Activate the boat's animation to run over the manatee.
    /// </summary>
    private void RunBoatOverManatee()
    {
        boatAnimator.Play("BoatHittingManatee");

        // Make the manatee stress vocalizations
        this.GetComponent<AudioSource>().Play();
    }

    private void EnablePlayerMovement()
    {
        playerMovement.EnableHorizontalMovement();
        playerMovement.EnableVerticalMovement();
        boatStrikeInfo.SetActive(true);
        manateeAI.enabled = true;
    }

    private void ScarManatee()
    {
        manateeMaterial.SetTexture("_MainTex", scarManateeTexture);
        

        
    }
}
