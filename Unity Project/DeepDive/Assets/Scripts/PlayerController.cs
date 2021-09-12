using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Player Controller class.
/// This class contains methods for moving Player object.
/// </summary>
public class PlayerController : MonoBehaviour
{
    public float PlayerSpeed;

    public Animator Anim;

    private Vector3 movement;

    void Update()
    {
        
        CharacterController controller = GetComponent<CharacterController>();

        // Getting Transform component from Player object.
        Transform trans = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        // Creating new Vector3 depending on arrow keys output.
        movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);

        // Applyting new Vector3 to Transform component.
        movement = transform.TransformDirection(movement);

        // Multiplying Vector3 by Player Speed variable and passed time since last frame.
        movement *= PlayerSpeed * Time.deltaTime;

        controller.Move(movement);

        // Setting animation parameter depening on arrow keys output.
        Anim.SetFloat("isMoving", Input.GetAxis("Horizontal"));

        // If Player object is moving right then set Y rotaion to 90f.
        if (Input.GetAxis("Horizontal") > 0) {
            trans.rotation = Quaternion.Euler(0f, 90f, 0f);
        }

        // If player object is moving left then set Y rotation to -90f.
        else if (Input.GetAxis("Horizontal") < 0)
        {
            trans.rotation = Quaternion.Euler(0f, -90f, 0f);
        }

    }
}
