using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script for the surface collider to advance the tutorial when the player breathes air
/// 
/// @author Alex Wills
/// </summary>
public class TutorialSurfaceZone : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Only advance if the player collides with the surface, and if this is the step of the tutorial they are on.
        if(TutorialBehavior.TaskNumber == 2 && other.gameObject.CompareTag("Player"))
        {
            TutorialBehavior.singleton.CompleteTaskAndProgress(3);
        }
    }
}
