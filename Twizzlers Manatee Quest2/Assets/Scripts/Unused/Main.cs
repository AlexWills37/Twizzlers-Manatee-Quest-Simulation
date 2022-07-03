
//TWIZZLERS

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour {

    //public static string content
    //public string content;
    //public string content1;
    //public bool PressedA = false;

    void CreateText() {

        //Path of the file
        string path = Application.dataPath + "/Log.txt";
        //string content;

        //Create file if it doesn't exist
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "Login log \n\n");
        }

        /*
        if (PressedA == true)
        {
            content1 = "A pressed";
            File.AppendAllText(path, content1);
        }
        */

        //Content of the file 
        string content = "Login date: " + System.DateTime.Now + "\n";
        //SaveText.content = "Awake: " + SceneManager.GetActiveScene().name + " Starting Time: " + System.DateTime.Now + "\n";

        //Add some to text to it
        File.AppendAllText(path, content);
    }

    // Start is called before the first frame update
    void Start()
    {
        CreateText();
    }

    /*
    void Update()
    {
        //for(int i = 0; i < 5; i++)
        while (true)
        {
            OVRInput.Update(); // Call before checking the input
            if (OVRInput.Get(OVRInput.Button.One))      //button A
            {
                Debug.Log("Button A pressed");
                PressedA = true;

                //returns true if the primary button (typically “A”) is currently pressed
            }
        }
        
    }
    */

}
