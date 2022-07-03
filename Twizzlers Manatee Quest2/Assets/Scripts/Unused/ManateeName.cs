using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManateeName : MonoBehaviour
{
    public string adultManatee1;
    public string adultManatee2;
    public string babyManatee;

    public void NameManatee()
    {
        SceneManager.LoadScene(1);
    }
    //Getting the values for current position and rotation
    void Awake()
    {
        //gets the saved position from player prefs and fills my variable with info
        adultManatee1 = PlayerPrefs.GetString("name1");
        adultManatee2 = PlayerPrefs.GetString("name2");
        babyManatee = PlayerPrefs.GetString("name3");
    }

    void Start()
    {

    }

    void Update()
    {
        //PlayerPrefs.SetString("name1", );
    }
}
