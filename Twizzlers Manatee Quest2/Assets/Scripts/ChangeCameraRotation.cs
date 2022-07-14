using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Change the rotation so that the player's camera is looking in a specified direction.
/// 
/// Problem: Headset rotation carries over from one scene to the next, giving us little control over which direction the user is facing.
/// This script is meant to adjust the player's rotation at the start of a scene to a certain value.
/// Currently this script is not working.
/// 
/// This script should be used at the start of the boat scene, since there is currently no other way to direct the user's gaze in the right direction.
/// 
/// @author Alex Wills
/// Updated 7/13/2022
/// </summary>
public class ChangeCameraRotation : MonoBehaviour
{
    [Tooltip("The center eye anchor, or another point to rotate the player about.")]
    [SerializeField] private Transform rotationPivot;

    [Tooltip("The y rotation to have the player face at the beginning.")]
    [SerializeField] private float startingYRotation;

    // This is how close to the startingYRotation to set the player's rotation.
    // Smaller numbers will be more accurate, but they will take longer to get to.
    private float marginOfError = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject actualCamera = GameObject.Find("LeftEyeAnchor");

        // Slowly rotate until the camera's rotation is correct
        while(Mathf.Abs(actualCamera.transform.rotation.eulerAngles.y - startingYRotation) > marginOfError){
            this.transform.RotateAround(rotationPivot.position, Vector3.up, marginOfError);
        }
    }

}
