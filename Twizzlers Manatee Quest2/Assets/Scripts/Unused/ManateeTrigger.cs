using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * This script is checking if the "Player" tagged object enters & exits 
 * the manatee objects trigger zone.
 * 
 * @author Sami Cemek
 * Updated: 07/08/21
 */
public class ManateeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject grassObj;
    [SerializeField] private GameObject UIObject;

    // Start is called before the first frame update
    void Start()
    {
        //grassObj.SetActive(false);
        UIObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.tag == "Player")       //if an object tagged "Player" enters the trigger zone
        {
            grassObj.SetActive(true);                //enable grass
            UIObject.SetActive(true);                //pop up an UI text canvas
        }
    }

    private void OnTriggerExit (Collider player)
    {
        if (player.gameObject.tag == "Player")       //if an object tagged "Player" exits the trigger zone
        {
            UIObject.SetActive(false);                //pop up an UI text canvas
        }
    }
}
