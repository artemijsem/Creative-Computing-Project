using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Camera Follow class.
/// This class contians methods for Camera object to follow Player object.
/// </summary>
public class CameraFollow : MonoBehaviour
{

    void Update()
    {
        // Find Player object.
        GameObject player = GameObject.Find("Player");

        // Create new Vector3 and assign Player's transform variables
        Vector3 cameraPos = new Vector3(player.transform.position.x, player.transform.position.y, 0);

        // Make Camera's transfrom X and Y variables to be Player's X and Y variables.
        this.gameObject.transform.position = cameraPos;
    }
}
