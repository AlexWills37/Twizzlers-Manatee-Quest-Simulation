using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Displays the tutorial text (configured in-script) alongside the editable inspector information.
/// Makes it easier to keep track of which index in the arrays corresponds to which step in the tutorial.
/// 
/// @author Alex Wills
/// Updated 6/15/2022
/// </summary>
[CustomEditor(typeof(TutorialBehavior))]
public class TutorialInspector : Editor
{

    public override void OnInspectorGUI()
    {
        string[] tasks = ((TutorialBehavior)target).GetTasks();
        string taskString = "";
        foreach(string task in tasks)
        {
            taskString += task + "\n";
        }

        DrawDefaultInspector();
    }
}
