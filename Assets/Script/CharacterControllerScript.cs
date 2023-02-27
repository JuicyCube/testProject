using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpSpeed = 8f;
    [SerializeField] float gravity = 20f;
    // [SerializeField] float rotationSpeed = 1f; // rotation speed


    private CharacterController controller;
    private Vector3 moveDirection = Vector3.zero;
    private Animator animator;

    

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        
    }

    void Update()
    {
       CharacterMove();
    }

    private void CharacterMove()
    {
         // Get the player's input
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        //Calculate the movement direction
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        movement = transform.TransformDirection(movement);

        

        // Apply speed to the movement direction
        movement *= moveSpeed;

        if(movement.x != 0 || movement.z != 0)
        {
            animator.SetBool("Move", true);
        }
        else
        {
            animator.SetBool("Move", false);
        }


        // if(Vector3.Angle(Vector3.forward, movement) > 1f || Vector3.Angle(Vector3.forward, movement) == 0)
        // {
        //     Vector3 direct = Vector3.RotateTowards(transform.forward, movement, moveSpeed, 5f);
        //     transform.rotation = Quaternion.LookRotation(direct);
        // }

        // Apply gravity to the movement
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

        // Move the controller
        controller.Move(movement * Time.deltaTime + moveDirection * Time.deltaTime);
    }
}
