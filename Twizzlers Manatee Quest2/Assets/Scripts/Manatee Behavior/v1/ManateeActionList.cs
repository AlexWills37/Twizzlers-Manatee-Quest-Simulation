using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// List of actions that the manatee can do.
/// Action list must follow the same order as the Action enum.
/// 
/// @author Alex Wills
/// Updated 6/16/2022
/// </summary>
public class ManateeActionList : MonoBehaviour
{

    public enum Action
    {
        Rest,
        Eat,
        Surface,
        Follow,
        Swim,
        Turn
    }

    [Tooltip("List of ManateeActions. Must follow the same order as the Action enum.")]
    [SerializeField] private ManateeAction[] actions;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartAction(Action toDo)
    {
        actions[(int)toDo].StartAction();
    }
}
