using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Enemy class.
/// Contains methods and attributes of Enemy object.
/// </summary>
public class Enemy : MonoBehaviour
{
    public Rigidbody Rb;

    public float AccelerationTime = 2f;

    public float MaxSpeed = 5f;

    public float Damage;

    private Vector3 movement;

    private float timeLeft;

    /// <summary>
    /// Get the Rigidbody component
    /// </summary>
    private void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Update function which makes Enemy move.
    /// </summary>
    private void Update()
    {
        // Check if time has passed since last move.
        timeLeft -= Time.deltaTime;
        if (timeLeft <= 0)
        {
            // Generating a new Vector3 for Enemy using random generator.
            movement = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
            timeLeft += AccelerationTime;
        }
    }

    /// Method in which force being applied on the enemy in order to acccleralte them.
    private void FixedUpdate()
    {
        // Multiplying Movement vector paramaters by speed to make Enemy object move faster.
        Rb.AddForce(movement * MaxSpeed);
    }

    /// <summary>
    /// Method for checking Player object collision with Enemy object.
    /// </summary>
    /// <param name="other">Collider component.</param>
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            // Geeting Health Bar component in order to change it.
            ValueBar healthBar = GameObject.Find("HealthBar").GetComponent<ValueBar>();
            // Applying damage to the player by depleting Health Bar value.
            healthBar.DepleteValue(Damage);
        }
    }
}
