using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SaveManateeName : MonoBehaviour
{
    public GameObject canvas1, canvas2, canvas3;
    public GameObject skittlesButton, oreooButton, twinxButton;
    public Text changingText;
    //public string name;

    private void Awake()
    {
        DontDestroyOnLoad(canvas1);
        DontDestroyOnLoad(canvas2);
        DontDestroyOnLoad(canvas3);
        canvas1.SetActive(false);
        canvas2.SetActive(false);
        canvas3.SetActive(false);

    }

    public string setName(string _name)
    {
        name = _name;
        return name;
    }

    public void ChangeText(){
        changingText.text = "Oreo";
    }

        


    
    //Baby Manatee
    public void NameFirstManatee()
    {
        Debug.Log("Name picked: Skittles");
        canvas1.SetActive(true);
        
        Destroy(skittlesButton);
        Debug.Log("Skittles Button destroyed");
    }

    public void NameAdultManatee1()
    {
        Debug.Log("Name picked: Oreoo");
        canvas2.SetActive(true);

        Destroy(oreooButton);
        Debug.Log("Oreoo Button destroyed");
    }

    public void NameAdultManatee2()
    {
        Debug.Log("Name picked: Twinx");
        canvas3.SetActive(true);

        Destroy(twinxButton);
        Debug.Log("Twinx Button destroyed");
    }


}
