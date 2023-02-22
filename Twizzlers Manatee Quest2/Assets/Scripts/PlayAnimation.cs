using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// General script to allow an animation to start with a public method.
/// For this script to work, the attached game object should have an Animator component
///     that has a bool parameter called "playAnim"
/// 
/// @author Alex Wills
/// Updated 6/26/22
/// </summary>

[RequireComponent(typeof(Animator))]
public class PlayAnimation : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.animator = this.GetComponent<Animator>();    
    }


    /// <summary>
    /// Begins the animation attached to this game object.
    /// The animator must have a boolean parameter "playAnim" that starts the animation.
    /// </summary>
    public void StartAnimation()
    {
        animator.SetBool("playAnim", true);
    }

    /// <summary>
    /// Plays an animation in this animator based on the State Name.
    /// </summary>
    /// <param name="stateName"> the name of the state to play. </param>
    public void StartAnimation(string stateName)
    {
        animator.Play(stateName);
    }
}
