using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// This script moves the attached object to a certain distance for a certain amount of time.
/// It is attached to GlideOVR in See a Manatee scene.
/// 
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>

public class Mover : MonoBehaviour
{
    public int distance = 5;

    // Update is called once per frame
    void Update()
    {

        //transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        for (int i = 0; i < 1; i++)
        {
            StartCoroutine("WaitAndDisplay");
        }
    }

    IEnumerator WaitAndDisplay()
    {
        transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;

        yield return new WaitForSeconds(5f);

        //UIObject.SetActive(false);
        distance = 0;
    }
}
