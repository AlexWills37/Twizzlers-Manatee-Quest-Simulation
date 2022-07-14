using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// Invokes a unity event when the player leaves this collider.
/// 
/// @author Alex Wills
/// Updated 7/13/2022
/// </summary>
[RequireComponent(typeof(Collider))]
public class InverseLoadingZone : MonoBehaviour
{
    public UnityEvent zoneExited;


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            zoneExited.Invoke();
        }
    }
}
