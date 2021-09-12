using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Uduino;
using System.Globalization;

/// <summary>
/// DHTData class.
/// Class contains methods for getting info from the Arduino board and parsing it to float variables readable for Unity.
/// </summary>
public class DHTData : MonoBehaviour
{
    [Range(0f, 10f)]
    public float marginVal = 0f;

    public float humidity = 0f;

    public float temperature = 0f;

    public float heatIndex = 0f;

    public float lastHeatIndex = 45f;

    public bool isBreathing;
 
    private void Start()
    {
        // Calls method every time when data from Arduino is recieved.
        UduinoManager.Instance.OnDataReceived += DataReceived;
    }

    /// <summary>
    /// Method which parses variables from Uduino plugin into floats.
    /// </summary>
    /// <param name="data">Data recieved from Arduino.</param>
    /// <param name="board">Arduino board.</param>
    void DataReceived(string data, UduinoDevice board)
    {
        // We split recied data string into several variables by whitespace.
        string[] DHTvar = data.Split(' ');

        // Converting strings into floats.

        humidity = float.Parse(DHTvar[0], CultureInfo.InvariantCulture.NumberFormat);

        temperature = float.Parse(DHTvar[1], CultureInfo.InvariantCulture.NumberFormat);

        heatIndex = float.Parse(DHTvar[2], CultureInfo.InvariantCulture.NumberFormat);

        // Checking if user is breathing by calculating the diffrence between heat indexes.
        isBreathing = (lastHeatIndex + marginVal <= heatIndex || lastHeatIndex - marginVal >= heatIndex);

        lastHeatIndex = heatIndex;
    }



}
