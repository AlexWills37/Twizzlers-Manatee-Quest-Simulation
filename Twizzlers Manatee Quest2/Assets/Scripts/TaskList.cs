using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

/// <summary>
/// Manages the task list for the manatee social life scene.
/// 
/// @author Alex Wills
/// Updated 7/16/2022
/// </summary>
public class TaskList : MonoBehaviour
{
    // -------- Inspector-friendly fields to configure the tasks --------

    [Header("Seagrass Task")]   // Fields relating to the seagrass task
    [Tooltip("Checkmark to display when this task is completed.")]
    [SerializeField] private GameObject seagrassEatenCheckmark;

    [Tooltip("Text object to display current progress (\"5/10\")")]
    [SerializeField] private TextMeshProUGUI seagrassProgressLabel;

    [Tooltip("Text to display before the task progress")]
    [SerializeField] private string seagrassPreText;

    [Tooltip("How much seagrass the user needs to eat to complete this task")]
    [SerializeField] private int numSeagrass;
   

    [Header("Socialization Task")]  // Fields relating to the socialization task
    [Tooltip("Checkmark to dispaly when this task is completed.")]
    [SerializeField] private GameObject socializedCheckmark;

    [Tooltip("Text object used to display the task")]
    [SerializeField] private TextMeshProUGUI socializedProgressLabel;

    // Called when all tasks have been completed
    public UnityEvent onAllTasksCommplete;


    // How much seagrass the player has currently eaten (copies the value from PlayerScript.ateGrassNum)
    private int seagrassEaten;

    // Whether the player has interacted with a manatee (used to make sure the task is only completed once
    private bool interactedWithManatee;

    // Start is called before the first frame update
    void Start()
    {
        seagrassEaten = 0;
        interactedWithManatee = false;

        // Disable checkmarks at the beginning
        socializedCheckmark.SetActive(false);
        seagrassEatenCheckmark.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the seagrass task if the number of eaten seagrass has changed
        if(PlayerScript.ateGrassNum != seagrassEaten)
        {
            seagrassEaten = PlayerScript.ateGrassNum;
            UpdateSeagrassTask();
        }

        // Update the socialization task if the player has interacted with a manatee
        if(!interactedWithManatee && PlayerScript.interactedWithManatee)
        {
            interactedWithManatee = true;
            StartCoroutine(CompleteTask(socializedCheckmark, socializedProgressLabel));
        }

        // If both tasks have been completed, give the user the option to continue
        if(interactedWithManatee && seagrassEaten >= numSeagrass)
        {
            onAllTasksCommplete.Invoke();
        }
    }

    /// <summary>
    /// Update the seagrass task to reflect how much seagrass is currently eaten and whether the task is complete.
    /// </summary>
    private void UpdateSeagrassTask()
    {
        // Set label to something like "Eat seagrass (3/10)"
        seagrassProgressLabel.SetText(seagrassPreText + " (" + seagrassEaten + "/" + numSeagrass + ")");

        // Complete the task when the player has eaten enough seagrass (and if the task isn't already completed)
        if(seagrassEaten >= numSeagrass && !seagrassEatenCheckmark.activeSelf)
        {
            StartCoroutine(CompleteTask(seagrassEatenCheckmark, seagrassProgressLabel));
        }
    }

    /// <summary>
    /// Complete a task with a short animation to visually show the task is finished.
    /// </summary>
    /// <param name="taskCheckmark"> The checkmark object to set active </param>
    /// <param name="taskText"> The text label for the task to animate </param>
    /// <returns></returns>
    private IEnumerator CompleteTask(GameObject taskCheckmark, TextMeshProUGUI taskText)
    {
        // Set the text to green and activate the checkmark
        taskCheckmark.SetActive(true);
        taskText.color = Color.green;

        // Fade to transparent white now that the task is complete
        for (float color = 0; color < 1; color += 0.1f)
        {
            taskText.color = new Color(color, 1, color, (1f - color));
            yield return new WaitForSeconds(0.05f);
        }
    }
}
