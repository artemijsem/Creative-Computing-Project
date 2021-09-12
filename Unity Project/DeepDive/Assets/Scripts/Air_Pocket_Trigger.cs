using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Air Pocket class.
/// This class contains methods for Air Pocket Object.
/// </summary>
public class Air_Pocket_Trigger : MonoBehaviour
{
    public GameObject World;
    /// <summary>
    /// Method for cheking Player object collision with Air Pocket object.
    /// </summary>
    /// <param name="other">Collider component.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // If collided with Player object then change isBreathable variable to true and allow player to restore Oxygen Bar.
            World.GetComponent<World>().isBreathable = true;
        }
    }
    
    /// <summary>
    /// Mathod for checking Player object leaving the collision with Air Pocket object.
    /// </summary>
    /// <param name="other">Collider component.</param>
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // If Player object is no longer colliding with Air Pocket object then change isBreathable variable to false and not allow player to restore Oxygen Bar.
            World.GetComponent<World>().isBreathable = false ;
        }
    }

}
