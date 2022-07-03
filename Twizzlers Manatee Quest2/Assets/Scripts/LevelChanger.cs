using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/**
 * This script used for fading animation. There is a countdown timer.
 * When it reaches 0 the fade-in animation plays and changing scene.
 * 
 * @author Sami Cemek
 * Updated: 5/20/21
 */
public class LevelChanger : MonoBehaviour
{
    private int levelToLoad;
    public Animator animator;
    public float startingTime = 15f;
    [SerializeField] float currentTime = 0f;
    [SerializeField] Text countdownText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1 * Time.deltaTime;   //countdown timer goes down by 1
        //countdownText.text = currentTime.ToString("0");

        if (currentTime <= 0)
        {
            currentTime = 0;
        }

        //Change color of countdown text to red when current time is less or equal to 10
        if (currentTime <= 10)
        {
            //countdownText.color = Color.red;
        }

        //Change scene and disable canvas when current time is less than or equal to 0
        if (currentTime <= 0)
        {

            //countdownText.text = ("Out of time!");
            FadeToLevel(4);
            DisableCanvas();
            OnFadeComplete();
        }
    }

    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("Fadeout"); //animator set to trigger so animation plays when it's trigered
    }

    //changes level to "levelToLoad"
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }

    //Disabiling the canvas on the scene
    public void DisableCanvas()
    {
        GameObject canvasPrefab = transform.Find("myCanvas").gameObject;
        canvasPrefab.SetActive(false);
    }
}
