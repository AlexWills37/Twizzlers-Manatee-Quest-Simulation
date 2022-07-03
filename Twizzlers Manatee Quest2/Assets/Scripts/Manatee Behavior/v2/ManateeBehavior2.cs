using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Defines how the manatees should behave.
/// 
/// Requirements:
/// ManateeVisionTrigger and ManateePhysicalCollider scripts to control the
/// followingPlayer and inPlayersSpace booleans respectively.
/// 
/// This script should be attached to the parent with the rigidbody for this manatee.
/// 
//  Hierarchy (order does not matter):
/// 
/// > Manatee (attach this script here)
/// | > Mesh render
/// | > Large trigger collider to detect the player (attach ManateeVisionTrigger here)
/// | > Small collider (not trigger) to define the manatee's bounds (attach ManateePhysicalCollider here)
/// 
/// Ensure that you drag the object with this manatee script into the two collider scripts, and
/// ensure that you drag the player's personal space collider into the PhysicalCollider script.
/// 
/// @author Alex Wills
/// Updated 6/22/22
/// </summary>
public class ManateeBehavior2 : MonoBehaviour
{
    [Tooltip("How quickly the manatee should move around.")]
    [SerializeField] private float movementSpeed = 5f;

    [Tooltip("Particle system to emit particles when the manatee is booped by the player.")]
    [SerializeField] private ParticleSystem happyParticles;

    private Animator animator;

    private bool inPlayersSpace = false;

    private bool followingPlayer = false;

    private bool atSurface = false;

    private bool coroutineActive = false;
    private Coroutine coroutine;

    private Rigidbody manateeRb;

    private GameObject player;

    private ParticleSystem.EmissionModule happyParticleSettings;

    [Tooltip("How many seconds the manatee will take before going up to breathe air.")]
    [Range(5f, 300f)]
    [SerializeField] private float breathTime = 30f;

    private float interactionCooldownMax = 3f;
    private float currentCooldownTimer = 0;
    private bool cooldownActive = false;


    // How long the manatee has been underwater
    private float currentTimeWithoutBreath = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // Get specific components
        manateeRb = this.GetComponent<Rigidbody>();
        animator = this.GetComponentInChildren<Animator>();
        player = GameObject.Find("NewPlayerController");
        happyParticleSettings = happyParticles.emission;
        happyParticleSettings.rateOverTime = 0; // Stop the manatee from emitting particles
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeWithoutBreath += Time.deltaTime;

        if (!coroutineActive)
        {
            // Go up to breathe if enough time has passed. This takes priority over other actions.
            if(currentTimeWithoutBreath >= breathTime)
            {
                StartCoroutine(SurfaceAndBreathe());
            }

            // Move toward the player if they are in range, between this manatee's vision and the player's
            // personal space
            else if (followingPlayer && !inPlayersSpace)
            {
                // Move a bit below the player's camera (so that the manatee isn't directly staring at you)
                animator.SetBool("isSwimming", true);
                this.transform.LookAt((player.transform.position - new Vector3(0, -1, 0)), Vector3.up);
                this.transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime, Space.Self);
            } else
            {
                animator.SetBool("isSwimming", false);
            }


        }
    }

    public void InteractWithManatee()
    {
        animator.SetBool("isRolling", true);
        StartCoroutine(HappyParticleCoroutine());
        PlayerScript.currentHealth += 2;
    }

    private IEnumerator HappyParticleCoroutine()
    {
        happyParticleSettings.rateOverTime = 15;
        yield return new WaitForSeconds(1f);
        happyParticleSettings.rateOverTime = 0;
    }

    /// <summary>
    /// Moves the manatee to the surface, waits a little bit and goes back down.
    /// </summary>
    /// <returns> IEnumerator representing Coroutine to surface and breathe. </returns>
    private IEnumerator SurfaceAndBreathe()
    {
        coroutineActive = true;

        // Record the original Y so that we can float back down to this point
        float originalY = this.transform.position.y;

        // Swim upwards
        Debug.Log("Going up");
        while (!atSurface)
        {
            this.transform.Translate(Vector3.up * movementSpeed * Time.deltaTime, Space.World);
            yield return null;
        }

        // Wait to take a breath
        animator.SetBool("isBreathing", true);
        yield return new WaitForSeconds(5f);
        animator.SetBool("isBreathing", false);

        // Swim back down to the original point
        while (this.transform.position.y > originalY)
        {
            this.transform.Translate(Vector3.down * movementSpeed * Time.deltaTime, Space.World);
            yield return null;
        }

        // End coroutine and reset the manatee's breath timer
        currentTimeWithoutBreath = 0f;
        coroutineActive = false;
    }


    private void MoveTowardPlayer()
    {

    }

    /// <summary>
    /// Set this manatee's status for following the player.
    /// To be used by the collider that detects objects around the manatee.
    /// </summary>
    /// <param name="isFollowingPlayer"> whether or not the manatee is following the player. </param>
    public void SetPlayerFollow(bool isFollowingPlayer)
    {
        this.followingPlayer = isFollowingPlayer;
    }

    /// <summary>
    /// Set this manatee's status for being in the player's personal space.
    /// To be used by the collider that acts as the manatee's outline.
    /// </summary>
    /// <param name="isInPlayerSpace"> whether or not the manatee is in the player's personal space. </param>
    public void SetInPlayerSpace(bool isInPlayerSpace)
    {
        this.inPlayersSpace = isInPlayerSpace;
    }

    /// <summary>
    /// Sets whether this manatee is at the surface or not.
    /// This method should be called by the physical collider that the manatee uses.
    /// </summary>
    /// <param name="isAtSurface"> whether or not this manatee is at the surface. </param>
    public void SetAtSurface(bool isAtSurface)
    {
        this.atSurface = isAtSurface;
    }
}
