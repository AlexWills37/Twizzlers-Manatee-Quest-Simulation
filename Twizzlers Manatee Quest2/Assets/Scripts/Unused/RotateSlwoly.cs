using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSlwoly : MonoBehaviour
{
    [SerializeField] private Transform center;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spin());
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private IEnumerator Spin()
    {
        while (true)
        {
            this.transform.RotateAround(center.position, Vector3.up, 20f);
            yield return new WaitForSeconds(5f);
        }
    }
}
