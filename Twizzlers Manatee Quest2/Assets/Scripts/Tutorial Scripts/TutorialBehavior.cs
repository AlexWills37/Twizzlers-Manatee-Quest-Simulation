using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

/// <summary>
/// Manages the underwater tutorial scene.
/// Inspired by tutorials in Ring Fit Adventure for the Nintendo Switch, where a visual is displayed demonstrating what to do,
/// and a checkbox tells you in words what to do to advance the tutorial. Feedback (checkbox and haptics) is given to 
/// tell the user that they completed the task.
/// 
/// Hierarchy must be:
/// > Tutorial canvas (attach this script here)
/// | > Panel
/// | | > TMPro text component to display task
/// | | > Background (any component)
/// | | | > Checkmark (image component
/// | | ... (any children past this point are okay) ...
/// | ... (any children past this point are okay) ...
/// 
/// @author Alex Wills
/// Updated: 6/13/2022
/// </summary>
public class TutorialBehavior : MonoBehaviour
{
    // 
    public static TutorialBehavior singleton
    {
        get;
        private set;
    }

    // Text that tells the user what to do
    private TextMeshProUGUI taskText;

    // Checkbox for feedback
    private GameObject checkmark;

    // How long (in seconds) between the completion of one task, and the activation of the next task
    private float progressDelay = 1f;

    private string[] tasks = { "Move the thumbstick to swim around.", 
                                "Swim to the seagrass to eat it and gain points.",
                                "Press the Y button to swim to the surface.",
                                "Press the X button to swim back underwater."};

    [Tooltip("List of objects to activate for different tasks. Index = task number.")]
    [SerializeField] private GameObject[] tutorialObjects;

    [Tooltip("List of images to display for different tasks. Index = task number.")]
    [SerializeField] private GameObject[] tutorialImages;

    // Counter to keep track of which part of the tutorial you are on
    public static int TaskNumber
    {
        get;
        private set;
    }

    private Image taskBackground;

    [Tooltip("Canvas to display when the tutorial is complete")]
    [SerializeField] private GameObject endTutorialScreen;



    // Start is called before the first frame update
    void Start()
    {
        // Make this script accessible as a static object
        if(singleton != this)
        {
            singleton = this;
        }

        // Find components in children
        Transform panel = this.transform.GetChild(0);
        taskText = panel.GetChild(0).GetComponent<TextMeshProUGUI>();
        checkmark = panel.GetChild(1).GetChild(0).gameObject;
        taskBackground = panel.GetComponent<Image>();

        // For the first task, clear the checkmark.
        checkmark.SetActive(false);
        TaskNumber = 0;

        // Disable all tutorial visuals except for the first
        foreach(GameObject pic in tutorialImages)
        {
            pic.SetActive(false);
        }
        tutorialImages[0].SetActive(true);

        endTutorialScreen.SetActive(false);

    }



    /// <summary>
    /// Call this method to mark the checkbox and declare this task completed.
    /// </summary>
    /// <param name="nextTaskNumber"> the task to activate next. </param>
    public void CompleteTaskAndProgress(int nextTaskNumber)
    {
        // Hide the current visual aid
        if(TaskNumber < tutorialImages.Length && tutorialImages[TaskNumber] != null)
        {
            tutorialImages[TaskNumber].SetActive(false);
        }

        // Give user feedback and transition to next task
        checkmark.SetActive(true);
        taskText.color = Color.green;
        HapticFeedback.singleton.TriggerVibrationTime(0.2f);
        TaskNumber = nextTaskNumber;

        // End the tutorial if there are no more steps to take
        if(TaskNumber == tasks.Length)
        {
            StartCoroutine(EndTutorial());
        } else
        {
            StartCoroutine(TransitionTask());
        }
    }


    public void SetTask(string task)
    {
        taskText.SetText(task);
    }



    /// <summary>
    /// Coroutine to wait and animate the currently active task in the tutorial.
    /// </summary>
    /// <returns> IEnumerator representing the coroutine </returns>
    private IEnumerator TransitionTask()
    {
        // Wait before disabling the checkmark and progressing to the next task
        yield return new WaitForSeconds(progressDelay);

        // Change color to white again
        for (float color = 0; color < 1; color += 0.1f)
        {
            taskText.color = new Color(color, 1, color);
            yield return null;
        }

        checkmark.SetActive(false);

        SetupTask();

    }

    /// <summary>
    /// Activate the necessary objects and set the text for the current TaskNumber
    /// </summary>
    private void SetupTask()
    {
        // Set the next task up
        if (TaskNumber < tasks.Length)
        {
            taskText.SetText(tasks[TaskNumber]);
            // Activate object if it exists
            if (TaskNumber < tutorialObjects.Length && tutorialObjects[TaskNumber] != null)
            {
                tutorialObjects[TaskNumber].SetActive(true);
            }

            // Display visual aid if it exists
            if (TaskNumber < tutorialImages.Length && tutorialImages[TaskNumber] != null)
            {
                tutorialImages[TaskNumber].SetActive(true);
            }
        }
    }

    /// <summary>
    /// Returns the list of tasks. Used in TutorialInspector.cs to display the tasks
    /// in the editor inspector.
    /// </summary>
    /// <returns></returns>
    public string[] GetTasks()
    {
        return tasks;
    }

    public IEnumerator EndTutorial()
    {
        endTutorialScreen.SetActive(true);
        // Wait before disabling the checkmark and progressing to the next task
        yield return new WaitForSeconds(3f);

        this.gameObject.SetActive(false);
    }
}
