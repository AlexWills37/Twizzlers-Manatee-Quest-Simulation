//TWIZZLERS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//See documentation for buttons: https://developer.oculus.com/documentation/unity/unity-ovrinput/
//See documentation for haptic feedback: https://developer.oculus.com/documentation/unity/unity-haptics/

/**
 * This script checks which oculus controllers' button is pressed.
 * 
 * @author Sami Cemek
 * Updated: 07/15/21
 */
public class Mouse : MonoBehaviour
{
    private OVRGrabbable ovrGrabbable;

    void Start()
    {
        ovrGrabbable = GetComponent<OVRGrabbable>();
    }

    void Update()
    {
        OVRInput.Update(); // Call before checking the input

        //BUTTONS
        if (OVRInput.Get(OVRInput.Button.One))      //button A
        {
            //OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            HapticFeedback.singleton.TriggerVibration(40, 2, 255, OVRInput.Controller.RTouch);
            Debug.Log("Button A pressed");
            //returns true if the primary button (typically “A”) is currently pressed
        }
        if (OVRInput.Get(OVRInput.Button.Two))      //button B
        {
            Debug.Log("Button B pressed");
            //returns true if the secondary button (typically “B”) is currently pressed
        }
        if (OVRInput.Get(OVRInput.Button.Three))    //button X
        {
            Debug.Log("Button X pressed");
            //returns true if the tertiary button (typically “X”) is currently pressed
        }
        if (OVRInput.Get(OVRInput.Button.Four))     //button Y
        {
            Debug.Log("Button Y pressed");
            //returns true if the quaternary button (typically “Y”) is currently pressed
        }


        //THUMBSTICKS
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstick))
        {
            Debug.Log("Left thumbstick pressed");  //left thumbstick
            // returns true if the primary thumbstick is currently pressed (clicked as a button)
        }
        if (OVRInput.Get(OVRInput.Button.SecondaryThumbstick))
        {
            Debug.Log("Right thumbstick pressed");  //right thumbstick
            // returns true if the secondary thumbstick is currently pressed (clicked as a button)
        }

        //TRIGGERS
        if (OVRInput.Get(OVRInput.RawButton.LIndexTrigger))
        {
            Debug.Log("Left index finger trigger pressed");  //left index finger trigger
            // returns true if the left index finger trigger has been pressed more than halfway.
            //(Interpret the trigger as a button).
        }
        if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger))
        {
            Debug.Log("Right index finger trigger pressed");  //right index finger trigger
            // returns true if the left index finger trigger has been pressed more than halfway.
            //(Interpret the trigger as a button).
        }


        //YOU DON'T CHECK HAND TRIGGERS BUTTON YET.(GRABBING BUTTONS)



        /*
        //if (OVRInput.Get(OVRInput.PrimaryHandTrigger))
        if (OVRInput.Get(OVRInput.RawAxis1D.RHandTrigger))
        {
            Debug.Log("sup bih");
        }
        */


        //?
        if (OVRInput.GetDown(OVRInput.Button.One))
        {
            Debug.Log("a pressed this frame");
        }
        if (OVRInput.GetUp(OVRInput.RawButton.X))
        {
            Debug.Log("x button released");
        }
        /*
        if (OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick))
        {
            Debug.Log("IT'S NOT BOOL THAT'S WHY IT'S NOT WORKING");
            // returns a Vector2 of the primary (typically the Left) thumbstick’s current state.
            // (X/Y range of -1.0f to 1.0f)
        }
        */


        //FOR FUTURE REFERENCE
        /*
        if (OVRInput.Get(OVRInput.Button.PrimaryThumbstickUp))
        {
            Debug.Log("Left thumbstick moved upward");
            // returns true if the primary thumbstick has been moved upwards more than halfway.
            // (Up/Down/Left/Right - Interpret the thumbstick as a D-pad).
        }
        */


    }
}
