using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class testTest : MonoBehaviour
{
    public Text adultText1;
    public Text adultText2;
    public Text babyText;

    public GameObject skittlesButton, oreooButton, twinxButton;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


   
    public void SetNameOreoo()
    {
        adultText1.text = "Oreoo";
        Destroy(oreooButton);
        Debug.Log("Oreoo Button destroyed");
    }


    public void SetNameSkittles()
    {
        adultText1.text = "Skittles";
        Destroy(skittlesButton);
        Debug.Log("Skittles Button destroyed");
    }


    public void SetNameTwinx()
    {


       adultText1.text = "Twinx";
        Destroy(twinxButton);
        Debug.Log("Twinx Button destroyed");
    }
    

    /*
    public void setAdult1Name()
    {
        if (skittlesButton != null)
        {
            adultText1.text = "Skittles";
            Destroy(skittlesButton);
        }

        if (oreooButton != null)
        {
            adultText1.text = "Oreoo";
            Destroy(oreooButton);
        }

        if (twinxButton != null)
        {
            adultText1.text = "Twinx";
            Destroy(twinxButton);
        }

        


    }
    */


}
