using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Score class.
/// Class contains method for operating with Score system.
/// </summary>
public class Score : MonoBehaviour
{
    Text scoreTxt;

    public int scoreInt;

    float timer;
    /// <summary>
    /// Method for adding 1 point to Score every second.
    /// </summary>
    void Update()
    {
        timer += Time.deltaTime;

        if(timer > 1f)
        {
            scoreInt += 1;
            timer = 0;
        }
        scoreTxt = GetComponent<Text>();

        scoreTxt.text = string.Format("Score:{0}", scoreInt);      
    }
}
