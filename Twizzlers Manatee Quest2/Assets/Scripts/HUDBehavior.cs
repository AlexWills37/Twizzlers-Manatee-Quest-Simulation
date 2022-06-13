using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Heads Up Display behavior.
/// The HUD should follow the player around at a fixed distance, following the player's horizontal rotation roughly.
/// Meant to mimic how windows in the Quest environment (like when you are setting up the guardian boundary) work.
/// The HUD only moves when the player rotates past a certain point.
/// This follows the player's gaze, instead of sticking to the player's gaze.
/// 
/// @author Alex Wills
/// Updated 6/11/2022
/// </summary>
public class HUDBehavior : MonoBehaviour
{
    private Transform player;

    private float currentAngle;

    [Tooltip("How many degrees ")]
    [SerializeField] private float angleWindow = 10f;

    private float timeToRecenter = 0.3f;

    private bool isRotating;

    private Vector3 startingAngles;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("LeftEyeAnchor").transform;

        startingAngles = this.transform.rotation.eulerAngles;
        currentAngle = this.transform.rotation.eulerAngles.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LateUpdate()
    {
        // Fix the position to the player
        this.transform.position = player.position;



        // Fix the y rotation to the player
        this.transform.rotation = Quaternion.Euler(startingAngles.x, player.rotation.eulerAngles.y, startingAngles.z);
    }


}
