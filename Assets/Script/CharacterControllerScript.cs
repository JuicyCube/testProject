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


        // // check player if grounded
        // groundedPlayer = controller.isGrounded;

        // // Reset the vertical velocity if the player is on the ground
        // if (groundedPlayer)
        // {
        //     playerVelocity.y = 0f;
        // }
        // animator.SetBool("Jump", playerVelocity.y > 0f);

        // if (groundedPlayer && playerVelocity.y < 0)
        // {
        //     playerVelocity.y = 0f;
        // }

        // if (playerVelocity.y < 0)
        // {
        //     animator.SetBool("Jump", false);
        // }

        // if (playerVelocity.y > 0)
        // {
        //     animator.SetBool("Jump", true);
        // }



        // Get the player's input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Set the animator parameters
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);

        // Calculate the movement direction
        Vector3 movement = Vector3.zero;
        if (horizontal < 0)
        {
            movement = Vector3.left * moveSpeed;
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        else if (horizontal > 0)
        {
            movement = Vector3.right * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        else if (vertical < 0)
        {
            movement = Vector3.back * moveSpeed;
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else if (vertical > 0)
        {
            movement = Vector3.forward * moveSpeed;
            transform.rotation = Quaternion.identity;
        }

        if (movement.x != 0 || movement.z != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }


        controller.Move((movement + moveDirection) * Time.deltaTime);

        // Rotate the character towards the movement direction
        if (movement.magnitude > 0)
        {
            transform.rotation = Quaternion.LookRotation(movement);
        }

    }
}
