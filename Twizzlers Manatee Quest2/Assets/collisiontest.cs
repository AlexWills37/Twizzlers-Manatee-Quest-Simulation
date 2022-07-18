using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisiontest : MonoBehaviour
{
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
        Debug.Log("Collision");
        // When the boat hits, call the boat hit method 
        if (collision.gameObject.CompareTag("Boat"))
        { 
            Debug.Log("Boat hit");
        }
    }
}
