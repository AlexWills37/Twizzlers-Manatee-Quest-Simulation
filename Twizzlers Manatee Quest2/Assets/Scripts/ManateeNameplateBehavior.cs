using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Causes the manatee nametags to always face the player while still following the manatee's position
/// 
/// @author Alex Wills
/// Updated 3/7/2023
/// </summary>
public class ManateeNameplateBehavior : MonoBehaviour
{

    private Transform player;

    [Tooltip("The game object the nametag will follow for positioning (like the manatee neck bone)")]
    [SerializeField] private Transform manateeFollowPoint;

    private Vector3 followOffset; // The distance to maintain between the nametag and the head of the manatee
    private Vector3 followRatio;

    // Start is called before the first frame update
    void Start()
    {
        // Assign the player value if it does not currently exist
        if(player == null)
        {
            player = GameObject.Find("NewPlayerController").transform;
            Debug.Log("Player for nameplate: " + player.gameObject.name);
        }



        if(manateeFollowPoint != null)
        {
            followOffset = this.transform.position - manateeFollowPoint.position;
            followOffset.x = 0;
            followOffset.z = 0;
        }
        else
        {
            Debug.LogError("No follow point attached to the nametag. Nametag will not move with animations.");
        }
    }

    // Update is called once per frame
    void Update()
    {

        // Configure y rotation to match player
        float yRotationGoal = calcAngleToPlayer();


        // Update rotation to face the player
        this.transform.rotation = Quaternion.Euler(0, yRotationGoal, 0);

        // Follow a point on the manatee to move with animations
        if(manateeFollowPoint != null)
        {
            //this.transform.position = manateeFollowPoint.position + followOffset;

        }
    }

    private float calcAngleToPlayer()
    {
        float deltaZ = player.position.z - this.transform.position.z;
        float deltaX = player.position.x - this.transform.position.x;

        // If you draw a line from the nametag to the player, 
        // this rotation is the angle of that line, starting at the nametag.
        // 0 degrees = positive Z, 90 degrees = positive X
        float yRotation = 0;

        // If the player is directly behind or in front of the nametag,
        // we can determine the angle as either 0 or 180
        if(deltaX == 0)
        {
            if(deltaZ > 0)
            {
                yRotation = 0;
            } else
            {
                yRotation = 180;
            }

            // Otherwise, we should calculate the angle
        } else
        {
            // Calculate angle
            float partialAngle = Mathf.Atan(deltaZ / deltaX);
            partialAngle = Mathf.Rad2Deg * partialAngle;

            if(deltaX > 0)
            {
                yRotation = 90 - partialAngle;
            } else
            {
                yRotation = 270 - partialAngle;
            }
        }

        return yRotation;
        
    }

}
