    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//DOCUMENTATION:
//https://www.youtube.com/watch?v=9KJqZBoc8m4
//https://developer.oculus.com/documentation/native/pc/dg-input-touch-haptic/
//https://developer.oculus.com/documentation/unity/unity-haptics/

///<summary>
/// This script provides haptic feedback for the oculus touch controllers.
/// You need to call the TriggerVibration method from another script wherever
/// you want to trigger haptic feedback. You can change the iteration, frequency, 
/// strength, and which controller you want to buzz.
///
/// @author Sami Cemek
/// Updated: 07/22/21
/// 
/// </summary>


public class HapticFeedback : MonoBehaviour
{
    public static HapticFeedback singleton;

    // Start is called before the first frame update
    void Start()
    {
        if (singleton && singleton != this)
            Destroy(this);
        else
            singleton = this;
    }

    //Use this if you have an audio clip that is triggered with haptic feedback
    public void TriggerVibration(AudioClip vibrationAudio, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip(vibrationAudio);

        if(controller == OVRInput.Controller.LTouch)
        {
            //Trigger On Left Controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if(controller == OVRInput.Controller.RTouch)
        {
            //Trigger On Right Controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }

    //Use this if you want to have custom iteration, frequency, strength, and which controller you want to buzz
    public void TriggerVibration(int iteration, int frequency, int strength, OVRInput.Controller controller)
    {
        OVRHapticsClip clip = new OVRHapticsClip();

        for (int i = 0; i < iteration; i++)
        {
            clip.WriteSample(i % frequency == 0 ? (byte)strength : (byte)0);
        }

        if (controller == OVRInput.Controller.LTouch)
        {
            //Trigger On Left Controller
            OVRHaptics.LeftChannel.Preempt(clip);
        }
        else if (controller == OVRInput.Controller.RTouch)
        {
            //Trigger On Right Controller
            OVRHaptics.RightChannel.Preempt(clip);
        }
    }
}

//ADD THIS PART TO ANOTHER SCRIPT
//HapticFeedback.singleton.TriggerVibration(40, 2, 255, ovrGrabbable.grabbbedBy.GetController());