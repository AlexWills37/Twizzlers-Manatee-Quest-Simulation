using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

/// <summary>
/// Custom inspector window for the ManateeActionList to make it more clear how it must be set up to work.
/// 
/// @author Alex Wills
/// Updated 6/16/2022
/// </summary>
[CustomEditor(typeof(ManateeActionList))]
public class ManateeActionListInspector : Editor
{

    public override void OnInspectorGUI()
    {
        // Show each of the enum values
        EditorGUILayout.HelpBox("The actions in the \"Actions\" list must follow the order of these listed actions.", MessageType.Info);

        string[] actionNames = Enum.GetNames(typeof(ManateeActionList.Action));
        for(int i = 0; i < actionNames.Length; i++)
        {
            EditorGUILayout.LabelField("Element " + i + ": " + actionNames[i]);
        }

        DrawDefaultInspector();
    }
}
