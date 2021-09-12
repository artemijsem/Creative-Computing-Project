using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// World class.
/// Class works with UI elements such as Health Bar, Oxygen Bar and Score. 
/// </summary>
public class World : MonoBehaviour
{
    public bool isBreathable ;

    public float damage;

    /// <summary>
    /// Update function checks for the variables being changed.
    /// </summary>
    void Update()
    {
        DHTData data = GameObject.Find("DataHandler").GetComponent<DHTData>();

        ValueBar oxygenBar = GameObject.Find("OxygenBar").GetComponent<ValueBar>();

        ValueBar healthBar = GameObject.Find("HealthBar").GetComponent<ValueBar>();
        
        /* If player is breathing and enviroment is not suitable for breathing
         * then deplete Oxygen Bar first and if Oxygen Bar is depleted then
         * deplete Health Bar.
         */
        if (data.isBreathing && !isBreathable)
        {   
           if(oxygenBar.slider.value > 0) 
           {
                oxygenBar.DepleteValue(damage); 
           }
           else 
           { 
                healthBar.DepleteValue(damage); 
           }
            
        }
        /* If player is breathing and enviroment is suitable for breathing
         * then restore Oxygen Bar.
         */
        else if(data.isBreathing && isBreathable)
        {
            
            oxygenBar.RestoreValue(damage);
        }

        // If Health Bar is 0 or less then game over.
        if(healthBar.slider.value <= 0)
        {
            SceneManager.LoadScene("LoseScreen", LoadSceneMode.Single);
        }


    }

    
}
