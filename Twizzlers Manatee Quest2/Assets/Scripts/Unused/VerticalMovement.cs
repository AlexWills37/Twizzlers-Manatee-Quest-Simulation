using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script moves the OVR Camera Rig(Player) up and down when you press respectively Y and X buttons on the controller.
 * 
 * @author Sami Cemek
 * Updated: 07/16/21
 */

public class VerticalMovement : MonoBehaviour
{
    private float moveSpeed = 10f;
    private OVRGrabbable ovrGrabbable;

    public bool bounds;
    public Vector3 maxCameraPos;
    public Vector3 minCameraPos;

    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        OVRInput.Update(); // Call before checking the input
        if (OVRInput.Get(OVRInput.Button.Four))     //button Y
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);
            //HapticFeedback.singleton.TriggerVibration(40, 2, 255, ovrGrabbable.grabbedBy.GetController());
            Debug.Log("Button Y pressed, Going Up");
            //returns true if the quaternary button (typically “Y”) is currently pressed
        }
        if (OVRInput.Get(OVRInput.Button.Three))    //button X
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);
            Debug.Log("Button X pressed, Going Down");
            //returns true if the tertiary button (typically “X”) is currently pressed
        }
        
    }

    //This parts make sure the player doesn't go above the water surface and under terrain.

    void FixedUpdate()
    {
        if (bounds)
        {
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

        }
    }
}

    