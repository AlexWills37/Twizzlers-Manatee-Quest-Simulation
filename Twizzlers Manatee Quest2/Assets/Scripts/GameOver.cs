using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    //public NeedsManager needs;
    public GameObject gameOverText;

    private void Start()
    {
        gameOverText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (needs.air <= 0.05 || needs.food <= 0.05 || needs.social <= 0.05)
        {
            EndGame();
        }
        */
    }

    private void EndGame()
    {
        gameOverText.SetActive(true);
    }
}
