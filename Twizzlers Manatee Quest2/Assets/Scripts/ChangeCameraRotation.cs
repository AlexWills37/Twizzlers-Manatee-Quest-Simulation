using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Change the rotation so that the player's camera is looking in a specified direction.
/// 
/// Problem: Headset rotation carries over from one scene to the next, giving us little control over which direction the user is facing.
/// This script is meant to adjust the player's rotation at the start of a scene to a certain value.
/// 
/// This script should be used at the start of the boat scene, since there is currently no other way to direct the user's gaze in the right direction.
/// From what the OVRCameraScript looks like, I think the Start method automatically adjusts the camera rotation. This script waits a bit before adjusting the rotation.
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

    private GameObject actualCamera;

    // Start is called before the first frame update
    void Start()
    {
        actualCamera = GameObject.Find("LeftEyeAnchor");

        StartCoroutine(SetRotationAfterDelay(0.05f));
    }

  
    /// <summary>
    /// Rotates the camera to face the starting Y position after a set amount of delay.
    /// </summary>
    /// <param name="delay"> How long to wait to set the camera rotation, in seconds. </param>
    /// <returns> IEnumerator representing the coroutine. </returns>
    private IEnumerator SetRotationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        RotateToY();
    }

    /// <summary>
    /// Rotates the camera to the startingYRotation based on the margin of error.
    /// </summary>
    private void RotateToY()
    {
        // Slowly rotate until the camera's rotation is correct
        while (Mathf.Abs(actualCamera.transform.rotation.eulerAngles.y - startingYRotation) > marginOfError)
        {
            this.transform.RotateAround(rotationPivot.position, Vector3.up, marginOfError);
        }
    }

}
