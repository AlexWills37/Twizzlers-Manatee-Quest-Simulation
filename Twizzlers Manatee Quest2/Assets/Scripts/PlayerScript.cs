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
/// @author Alex Wills
/// Updated: 06/20/2022
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

    public bool breathDecreasing = true;

    //private float camXPos, camZPos;
    //public float camYPos;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = 10;
		healthBar.SetMaxHealth(maxHealth);
        healthBar.SetHealth(currentHealth);
        ateGrassNum = 0;

        currentBreath = maxBreath;
        breathBar.SetMaxHealth(maxBreath);

       // transform.position = new Vector3 (camXPos, camYPos, camZPos);
    }

    // Update is called once per frame
    void Update()
    {

        //currentHealth -= 2 * Time.deltaTime;

        if(healthBar != null && breathBar != null)
        {
            // Lower breath over time
            if (breathDecreasing && currentBreath > 0)
            {
                currentBreath -= 1 * Time.deltaTime;

                // When breath is low, decrease health
            } else if (currentBreath <= 0)
            {
                Mathf.Max(0, currentHealth -= 1 * Time.deltaTime);
            }

            // Health/points are modified externally with other scripts, so it is important
            // To ensure that health is not above the max
            if(currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }

            healthBar.SetHealth(currentHealth);
            breathBar.SetBreath(currentBreath);

        }
        

    }

    private void OnTriggerStay(Collider other)
    {
        // If we are colliding with air, increase our breath bar
        if (other.gameObject.CompareTag("Air"))
        {
            currentBreath = Mathf.Clamp(currentBreath + 12 * Time.deltaTime, 0, maxBreath);
            breathBar.SetBreath(currentBreath);
        }
    }
}
