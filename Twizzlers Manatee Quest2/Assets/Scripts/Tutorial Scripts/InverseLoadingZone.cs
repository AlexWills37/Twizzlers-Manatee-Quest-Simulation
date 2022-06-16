using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
