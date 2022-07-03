using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Calls an event when a trigger is entered.
/// Optionally progresses the tutorial.
/// 
/// @author Alex Wills
/// </summary> 
[RequireComponent(typeof(Collider))]
public class LoadingZone : MonoBehaviour
{
    public UnityEvent zoneEntered;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && TutorialBehavior.TaskNumber == 3)
        {
            zoneEntered.Invoke();
        }
    }
}
