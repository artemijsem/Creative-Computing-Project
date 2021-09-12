using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Value bar class.
/// Class contains methods for working with UI sliders.
/// </summary>
public class ValueBar : MonoBehaviour
{
    public Slider slider;
    

    public void DepleteValue(float value)
    {
        slider.value -= value;
    }
    public void RestoreValue(float value)
    {
        slider.value += value;
    }


}
