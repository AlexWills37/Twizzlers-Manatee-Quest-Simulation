using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///
/// Checks if “Player” tagged object collides with the life jacket.
/// If yes, destroy the life jacket.
/// 
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>

public class LifeJacketCollision : MonoBehaviour
{
    public GameObject UIObject;
    public AudioSource audioSource;
    public GameObject arrowObject1, arrowObject2, arrowObject3;
    private IEnumerator coroutine;

    void Start()
    {
        UIObject.SetActive(false);
        arrowObject1.SetActive(false);
        arrowObject2.SetActive(false);
        arrowObject3.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player") //if the object collides with player tagged object
        {
            StartCoroutine("WaitAndDisplay");

            Debug.Log("The player collided with a lifejacket");
            Destroy(this.transform.gameObject); //destroy that object

            
            audioSource.Play();
            arrowObject1.SetActive(true);
            arrowObject2.SetActive(true);
            arrowObject3.SetActive(true);
        }
    }

    IEnumerator WaitAndDisplay()
    {
        Debug.Log("coroutine started");
        UIObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        UIObject.SetActive(false);
        //Destroy(UIObject);
        Debug.Log("coroutine ended");

    }
}
