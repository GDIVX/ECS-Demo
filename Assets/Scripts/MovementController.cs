using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class MovementController : MonoBehaviour
{
    IMovementData movementData;
    private Rigidbody rb;
    private bool isGrounded;


    public static MovementController Create(GameObject gameObject, IMovementData movementData)
    {
        var movementController = gameObject.AddComponent<MovementController>();
        movementController.movementData = movementData;
        return movementController;
    }

    void Start()
    {
        //graceful get RigingBody. If it is null, create it
        rb = GetComponent<Rigidbody>() ?? gameObject.AddComponent<Rigidbody>();
    }

    void Update()
    {
        float moveX = 0f;

        // Check for horizontal movement
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }

        rb.velocity = new Vector2(moveX * movementData.GetMovementSpeed(), rb.velocity.y);

        // Check for jump
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, movementData.GetJumpForce()), ForceMode.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the player is on the ground
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player has left the ground
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
        }
    }
}
