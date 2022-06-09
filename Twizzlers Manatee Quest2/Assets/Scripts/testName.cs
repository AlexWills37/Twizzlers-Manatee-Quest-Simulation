using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testName : MonoBehaviour
{
    public GameObject OreoNametag;
    public GameObject SkittlesNameTag;
    public GameObject TwinxNameTag;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void nameOreo()
    {
        DontDestroyOnLoad(OreoNametag);
    }

    void nameSkittles()
    {
        DontDestroyOnLoad(SkittlesNameTag);
    }

    void nameTwinx()
    {
        DontDestroyOnLoad(TwinxNameTag);
    }

}
