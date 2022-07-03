using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class to layout an action that a manatee can do with AI.
/// Extensions of this class should implement the ActionCoroutine() method, making sure to use a yield return statement
/// as necessary to implement the coroutine. The implementation should also call EndAction() at the end of ActionCoroutine().
/// If EndAction() is not called at the end of the coroutine, the manatee may not be configured properly to perform another action.
/// 
/// @author Alex Wills
/// Updated 6/16/2022
/// </summary>

[RequireComponent(typeof(ManateeBehavior))]
public abstract class ManateeAction : MonoBehaviour
{

    protected Coroutine currentAction;
    protected ManateeBehavior manatee;

    protected bool interrupted;

    private void Start()
    {
        manatee = this.GetComponent<ManateeBehavior>();
        interrupted = false;
    }

    /// <summary>
    /// Start the manatee's action and prevents the manatee from doing another action.
    /// </summary>
    public void StartAction()
    {
        if(this.manatee == null)
        {
            manatee = this.GetComponent<ManateeBehavior>();
        }

        // Configure the action and manatee
        interrupted = false;
        manatee.SetIsActing(true);
        currentAction = StartCoroutine(ActionCoroutine());
    }

    /// <summary>
    /// Stop the current action and allow the manatee to respond to the interrupt.
    /// </summary>
    public void InterruptAction()
    {
        // Stop the current action
        StopCoroutine(currentAction);
        interrupted = true;
        EndAction();
    }

    /// <summary>
    /// Action for manatee to take.
    /// At the end of this method, every implementation MUST call this.EndAction(), otherwise the manatee will not 
    /// be configured to perform another action.
    /// </summary>
    /// <returns></returns>
    protected abstract IEnumerator ActionCoroutine();

    /// <summary>
    /// Congiure this action and the manatee to make another decision.
    /// </summary>
    protected void EndAction()
    {
        // Allow the manatee to take another action, and respond to an interrupt if one occurred.

        manatee.SetIsActing(false);
        if (interrupted)
        {
            manatee.RespondToInterrupt();
        }

    }

}
