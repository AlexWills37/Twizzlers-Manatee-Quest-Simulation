using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>
/// 
/// This script is using variables and methods of Healtbar.cs script.
/// It sets the health and breath to the max in the beginning. Health 
/// and breath decrease over time.
///
/// @author Sami Cemek
/// Updated: 08/20/21
/// 
/// </summary>


public class PlayerScript : MonoBehaviour
{
	public float maxHealth = 100;
    public static float currentHealth;
    public static int ateGrassNum;

    public float maxBreath = 180;
    public static float currentBreath;

    public HealthBar healthBar;
    public HealthBar breathBar;

    //private float camXPos, camZPos;
    //public float camYPos;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
        ateGrassNum = 0;

        currentBreath = maxBreath;
        breathBar.SetMaxHealth(maxBreath);

       // transform.position = new Vector3 (camXPos, camYPos, camZPos);
    }

    // Update is called once per frame
    void Update()
    {
        if (ateGrassNum <= 6)
        {
            currentHealth -= 2 * Time.deltaTime;
            currentBreath -= 1 * Time.deltaTime;

            healthBar.SetHealth(currentHealth);
            breathBar.SetBreath(currentBreath);
        }
        else
        {
            healthBar.SetMaxHealth(maxHealth);
            breathBar.SetMaxHealth(maxBreath);
        }

        //if (camYPos > )

    }
}
