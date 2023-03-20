using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    //[SerializeField] float jumpSpeed = 8f;
    [SerializeField] float gravity = 20f;
    // [SerializeField] float rotationSpeed = 1f; // rotation speed


    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    public float jumpSpeed = 8f;

    // New variable to store the player's current speed
    private float currentSpeed = 0f;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        CharacterMove();
    }

    public void CharacterMove()
    {
        if (controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                // Trigger the jump animation
                animator.SetTrigger("Jump");

                moveDirection.y = jumpSpeed;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        // Get the player's input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate the movement direction
        Vector3 movement = Vector3.zero;
        if (horizontal < 0 && vertical > 0)
        {
            // Move diagonally up and left
            movement = new Vector3(-moveSpeed, 0f, moveSpeed);
            transform.rotation = Quaternion.Euler(0, -135, 0);
        }
        else if (horizontal > 0 && vertical > 0)
        {
            // Move diagonally up and right
            movement = new Vector3(moveSpeed, 0f, moveSpeed);
            transform.rotation = Quaternion.Euler(0, 135, 0);
        }
        else if (horizontal > 0 && vertical < 0)
        {
            // Move diagonally down and right
            movement = new Vector3(moveSpeed, 0f, -moveSpeed);
            transform.rotation = Quaternion.Euler(0, 45, 0);
        }
        else if (horizontal < 0 && vertical < 0)
        {
            // Move diagonally down and left
            movement = new Vector3(-moveSpeed, 0f, -moveSpeed);
            transform.rotation = Quaternion.Euler(0, -45, 0);
        }
        else if (horizontal < 0)
        {
            // Move left
            movement = Vector3.left * moveSpeed;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (horizontal > 0)
        {
            // Move right
            movement = Vector3.right * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (vertical < 0)
        {
            // Move down
            movement = Vector3.back * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (vertical > 0)
        {
            // Move up
            movement = Vector3.forward * moveSpeed;
            transform.rotation = Quaternion.identity;
        }

        // if (movement.magnitude > 0)
        // {
        //     animator.SetBool("Move", true);
        //     Debug.Log("Movement: " + movement);
        //     Debug.Log("Animator: " + animator);


        // }
        // else
        // {
        //     animator.SetBool("Move", false);
        // }

        // Update the current speed based on the movement direction and move speed
        currentSpeed = movement.magnitude * moveSpeed;

        // Update the Move parameter of the animator based on the current speed
        animator.SetBool("Move", currentSpeed > 0);


        controller.Move((movement + moveDirection) * Time.deltaTime);

        // Rotate the character towards the movement direction
        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }
    }
}
