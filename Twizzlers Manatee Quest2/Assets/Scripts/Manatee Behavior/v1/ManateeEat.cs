using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manatee Eat Action. Manatee will swim towards the nearest seagrass and eat it for a bit.
/// Manatee must have nearestFood set to an object.
/// 
/// </summary>
public class ManateeEat : ManateeAction
{
    [Tooltip("How quickly the manatee should swim towards it's food")]
    [SerializeField] private float swimSpeed = 5f;

    [Tooltip("Transform at the manatee's mouth where it should eat the food")]
    [SerializeField] private Transform manateeMouth;

    /// <summary>
    /// Swim towards the food, eat it, and end the action
    /// </summary>
    /// <returns></returns>
    protected override IEnumerator ActionCoroutine()
    {
        Transform food = manatee.GetNearbyFood();
        Rigidbody rb = manatee.GetRigidbody();

        // Rotate to face the food

        manatee.transform.LookAt(food, Vector3.up);


        // Swim towards the food
        Vector3 deltaPosition = (food.position - manateeMouth.position);

        // We will stop if another manatee eats this food
        while(food != null && deltaPosition.magnitude > 0.5)
        {
            rb.velocity = deltaPosition.normalized * swimSpeed;

            // Update delta position to know when to stop, and to account for unintended forces
            deltaPosition = (food.position - manateeMouth.position);
            yield return null;
        }

        rb.velocity = Vector3.zero;

        // Eat the food for a bit
        yield return new WaitForSeconds(1);

        // Finish eating the food
        if (food != null)
        {
            Destroy(food.parent.gameObject);
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
