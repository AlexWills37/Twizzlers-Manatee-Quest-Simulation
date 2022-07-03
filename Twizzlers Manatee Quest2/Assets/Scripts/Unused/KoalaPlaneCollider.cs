using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KoalaPlaneCollider : MonoBehaviour
{
    public GameObject UIObject;
    private IEnumerator coroutine;

    void Start()
    {
        UIObject.SetActive(false);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine("WaitAndDisplay");
        }
    }

    IEnumerator WaitAndDisplay()
    {
        Debug.Log("coroutine started");
        UIObject.SetActive(true);

        yield return new WaitForSeconds(5f);

        UIObject.SetActive(false);
        Debug.Log("coroutine ended");

    }


}
