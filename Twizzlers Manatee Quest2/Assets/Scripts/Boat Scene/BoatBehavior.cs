using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the boat that will hit the manatee in the cutscene
/// 
/// @author Alex Wills
/// Updated 6/26/2022
/// </summary>
public class BoatBehavior : MonoBehaviour
{
    // The animator for this 
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
