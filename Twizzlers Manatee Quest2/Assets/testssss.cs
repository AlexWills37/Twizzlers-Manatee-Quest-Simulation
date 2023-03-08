using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testssss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This forward direction is " + this.transform.forward);
        Debug.Log("The current rotation is " + this.transform.rotation.eulerAngles.y);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
