using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Step6 : MonoBehaviour
{
    public GameObject UIObject;

    // Start is called before the first frame update
    void Start()
    {
        UIObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider player)
    {
        if (player.gameObject.name == "AdultManatee2")
        {
            UIObject.SetActive(true);
            Debug.Log("hellohellohellohellohello");
        }
    }
}
