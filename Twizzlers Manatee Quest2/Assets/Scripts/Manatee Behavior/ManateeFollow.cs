using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Follow another manatee for a few seconds.
/// 
/// </summary>
public class ManateeFollow : ManateeAction
{


    [Tooltip("How fast the manatee should swim to follow another manatee")]
    [SerializeField] private float swimSpeed = 5f;

    [Tooltip("How much distance the manatee should maintain between the one it's following")]
    [SerializeField] private float socialDistance = 1f;
    protected override IEnumerator ActionCoroutine()
    {
        // The following manatee should be set in the ManateeBehavior
        if(manatee.GetFollowingManatee() != null)
        {

            Transform leader = manatee.GetFollowingManatee().transform;
            Rigidbody rb = manatee.GetRigidbody();
            Vector3 distanceDifference;

            // Follow for three seconds
            for(float time = 0; time < 3; time += Time.deltaTime)
            {
                distanceDifference = leader.position - this.transform.position;
                this.transform.LookAt(leader, Vector3.up);

                // Only move if the leader is farther than the social distance
                if(distanceDifference.magnitude > socialDistance)
                {
                    rb.velocity = distanceDifference.normalized * swimSpeed;

                // Otherwise, stop moving
                } else
                {
                    rb.velocity = Vector3.zero;
                }

                yield return null;
            }
        }

        EndAction();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
