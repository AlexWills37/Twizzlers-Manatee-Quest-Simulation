using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Swim forward for three seconds
/// </summary>
public class ManateeSwim : ManateeAction
{
    [Tooltip("How quickly the manatee should swim")]
    [SerializeField] private float swimSpeed = 5f;
    protected override IEnumerator ActionCoroutine()
    {
        // Disable drag and set velocity to move forward
        Rigidbody rb = manatee.GetRigidbody();
        float originalDrag = rb.drag;
        rb.drag = 0;
        rb.velocity = manatee.transform.forward * swimSpeed;

        // After three seconds, return drag to the original value to slow the manatee down
        yield return new WaitForSeconds(3);

        rb.drag = originalDrag;
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
