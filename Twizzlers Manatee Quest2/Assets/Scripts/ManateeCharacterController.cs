using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Alternative to the CharacterController component in Unity that uses.
/// This is necessary because the OVRPlayerController script relies on the CharacterController component, but
/// that component does not use rigidbodies and follows gravity, and for underwater swimming gravity must be turned off.
/// 
/// This script is just the components of CharacterController used by OVRPlayerController, but without gravity. (not a full alternative to CharacterController).
/// This script would ideally inherit the CharacterController script, but the Move method cannot be overriden, so it is instead a modified copy.
/// 
/// @author Alex Wills
/// Updated: 6/12/2022
/// </summary>
/// 

//[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class ManateeCharacterController : MonoBehaviour
{

    //private new Rigidbody rigidbody;
    private new CapsuleCollider collider;

    private Vector3 noY = new Vector3(1, 0, 1);


    //
    // Summary:
    //     Was the CharacterController touching the ground during the last move?
    public bool isGrounded { 
        get { 
            return isGroundedLocal;
        }
    }

    private bool isGroundedLocal = true;

    //
    // Summary:
    //     The radius of the character's capsule.
    public float radius { get { return collider.radius; } }
    //
    // Summary:
    //     The height of the character's capsule.
    public float height { get { return collider.height; } }

    //
    // Summary:
    //     The center of the character's capsule relative to the transform's position.
    public Vector3 center { get { return collider.center; } }
 
    //
    // Summary:
    //     The character controllers step offset in meters.
    public float stepOffset { get; set; }



    private void Start()
    {
        //rigidbody = this.GetComponent<Rigidbody>();
        collider = this.GetComponent<CapsuleCollider>();
    }

    //
    // Summary:
    //     Supplies the movement of a GameObject with an attached CharacterController component.
    //
    // Parameters:
    //   motion:
    public CollisionFlags Move(Vector3 motion)
    {
        this.transform.Translate(motion);

        return CollisionFlags.None;
    }
    //
    // Summary:
    //     Moves the character with speed.
    //
    // Parameters:
    //   speed:
    public bool SimpleMove(Vector3 speed)
    {
        Move(speed);
        return true;
    }

    private void Update()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundedLocal = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGroundedLocal = false;
        }
    }
}
