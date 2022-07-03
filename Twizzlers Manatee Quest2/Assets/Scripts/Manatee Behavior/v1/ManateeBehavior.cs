using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The brain of the Manatee AI. This class stores and accepts information for manatees to make decisions based off of.
/// On a high level, the manatee makes a decision based on input factors (it chooses a ManateeAction), then it starts the action.
/// Once the action is finished, it will make another decision.
/// ManateeActions can also be interrupted if necessary, such as when the player bops the manatee.
/// 
/// @author Alex Wills
/// Updated 6/16/2022
/// </summary>
/// 
[RequireComponent(typeof(ManateeActionList))]
public class ManateeBehavior : MonoBehaviour
{

    protected bool isActing;


    private ManateeActionList possibleActions;

    private ManateeActionList.Action currentAction;

    [Tooltip("Rigidbody to move the manatee with.")]
    [SerializeField] private Rigidbody manateeBody;

    // Variables to determine what action the manatee will take
    public float breathLevel;
    private Transform nearbyFood;
    private float foodDistance;
    private Transform nearbyManatee;
    private float manateeDistance;
    [SerializeField] private ManateeBehavior manateeToFollow;


    // Start is called before the first frame update
    void Start()
    {
        possibleActions = this.GetComponent<ManateeActionList>();
        breathLevel = 100;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isActing)
        {
            isActing = true;
            ChooseAction();
        }
    }




    private void ChooseAction()
    {
        // Choose a default action
        if (Random.Range(0f, 1f) < 0.5f)
        {
            currentAction = ManateeActionList.Action.Rest;
        }
        else if (Random.Range(0f, 1f) < 0.5f)
        {
            currentAction = ManateeActionList.Action.Swim;
        } else
        {
            currentAction = ManateeActionList.Action.Turn;
        }

        manateeToFollow = null;

        // Surface if running low on air
        if (breathLevel < 20f)
        {
            currentAction = ManateeActionList.Action.Surface;

        // Then prioritize eating food
        } else if(nearbyFood != null)
        {
            currentAction = ManateeActionList.Action.Eat;

        // Then see if any manatees are nearby
        }/* else if (nearbyManatee != null)
        {
            
            ManateeBehavior friendManatee = nearbyManatee.gameObject.GetComponentInParent<ManateeBehavior>();

            // If there is a nearby manatee, try following it.
            // Make sure the friend manatee is not following this one
            if(friendManatee.manateeToFollow != this)
            {
                manateeToFollow = nearbyManatee.GetComponent<ManateeBehavior>();
                currentAction = ManateeActionList.Action.Follow;

            // If the manatee is following us, do default action
            } 

        // If there are no food or manatees nearby, either rest or swim around
        }*/


        //Debug.Log("Following: " + manateeToFollow);
        this.breathLevel -= 5;
        Debug.Log("Breath: " + breathLevel);
        // Do the action

        Debug.Log("Action: " + currentAction);
        possibleActions.StartAction(currentAction);
    }
    /// <summary>
    /// Set the state of isActing. When set to true, the manatee will not attempt to make a decision
    /// or do another action. When set to false, the manatee will attempt to make a decision, then carry out the action.
    /// </summary>
    /// <param name="isNowActing"> the new state of isActing </param>
    public void SetIsActing(bool isNowActing)
    {
        this.isActing = isNowActing;
    }

    public void RespondToInterrupt()
    {

    }

    // Methods to collect information
    // -------------------------------------

    /// <summary>
    /// Every frame, update the nearbyManatee and nearbyFood values 
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Manatee"))
        {

            // If this is the closest manatee, update the distance
            if(nearbyManatee != null && other.gameObject == nearbyManatee.gameObject)
            {
                manateeDistance = (nearbyManatee.transform.position - this.transform.position).magnitude;
            
            // If this is a new manatee, see if it is closer
            } else if(nearbyManatee == null || (other.transform.position - this.transform.position).magnitude < manateeDistance)
            {
                nearbyManatee = other.transform;
                manateeDistance = (other.transform.position - this.transform.position).magnitude;
            }   // If neither condiditon is met, then the colliding manatee is farther than the current nearbyManatee

        } else if (other.gameObject.CompareTag("Food"))
        {
            nearbyFood = other.gameObject.transform;
            foodDistance = (other.transform.position - this.transform.position).magnitude;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == nearbyFood)
        {
            nearbyFood = null;
            foodDistance = 100;
        } else if (other.gameObject == nearbyManatee)
        {
            nearbyManatee = null;
            manateeDistance = 100;
        }
    }


    // Getters for actions to retrieve information
    // -------------------------------------------
    public Rigidbody GetRigidbody()
    {
        return this.manateeBody;
    }

    public Transform GetNearbyFood()
    {
        return this.nearbyFood;
    }

    public ManateeBehavior GetFollowingManatee()
    {
        return this.manateeToFollow;
    }
}
