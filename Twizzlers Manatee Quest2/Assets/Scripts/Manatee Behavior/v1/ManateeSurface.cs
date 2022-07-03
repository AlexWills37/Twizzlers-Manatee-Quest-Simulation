using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Manatee swims to the surface, breathes some air, and returns back underwater.
/// For this action to work, there must be a physical collider (not trigger) above the surface with the "Air" tag.
/// This collider will stop the manatee from floating up forever, and it will indicate when to take the breath.
/// 
/// @author Alex Wills
/// Updated 6/17/2022
/// </summary>
public class ManateeSurface : ManateeAction
{
    private bool atSurface = false;
    protected override IEnumerator ActionCoroutine()
    {
        Rigidbody rb = manatee.GetRigidbody();
        // Swim to the surface
        manatee.transform.eulerAngles = new Vector3(-45f, manatee.transform.eulerAngles.y, manatee.transform.eulerAngles.z);
        while (!atSurface)
        {
            rb.velocity = new Vector3(0, 5, 0);
            yield return null;
        }

        // Stop at the surface and wait a few seconds
        rb.velocity = new Vector3(0, 0, 0);
        manatee.breathLevel = 100f;
        yield return new WaitForSeconds(5f);

        // Go back down for a bit
        manatee.transform.eulerAngles = new Vector3(0, manatee.transform.eulerAngles.y, manatee.transform.eulerAngles.z);

        float originalDrag = rb.drag;
        rb.drag = 0;
        rb.velocity = new Vector3(0, -5, 0);
        yield return new WaitForSeconds(1f);
        rb.drag = originalDrag;

        rb.velocity = new Vector3(0, 0, 0);

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

    

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Air"))
        {
            
            atSurface = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Air"))
        {
            
            atSurface = false;
        }
    }
}
