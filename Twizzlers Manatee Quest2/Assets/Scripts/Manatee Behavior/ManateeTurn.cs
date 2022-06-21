using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManateeTurn : ManateeAction
{
    protected override IEnumerator ActionCoroutine()
    {
        float deltaDegrees = Random.Range(-15f, 15f);
        float totalRotation = 0f;
        float rotationStep = 0;
        Rigidbody rb = manatee.GetRigidbody();


        while(Mathf.Abs(totalRotation) < Mathf.Abs(deltaDegrees))
        {
            rotationStep = deltaDegrees * Time.deltaTime * 5;
            rb.MoveRotation(Quaternion.Euler(0, rotationStep, 0));
            totalRotation += rotationStep;

            yield return null;
        }



        EndAction();
    }
}
