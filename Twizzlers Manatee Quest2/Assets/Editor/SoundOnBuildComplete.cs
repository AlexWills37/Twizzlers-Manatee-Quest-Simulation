using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class SoundOnBuildComplete : Editor
{
    private static bool isBuilding = false;

    [MenuItem("Custom Editor/It works!")]
    private static void DoNothing() {

        EditorApplication.Beep();
        


    }


    void OnSceneGUI()
    {
        // Toggle the boolean when you start the build
        if (BuildPipeline.isBuildingPlayer && !isBuilding)
        {
            isBuilding = true;
            EditorApplication.Beep();
            
        // When the build is finished, play a sound
        } else if (!BuildPipeline.isBuildingPlayer && isBuilding)
        {
            isBuilding = false;
            EditorApplication.Beep();
        }
    }


}
