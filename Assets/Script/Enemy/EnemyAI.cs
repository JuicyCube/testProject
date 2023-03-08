using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 4f;
    public Animator animator;

    private Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        // Rotate towards the player
        // transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);

        // Move towards the player
        transform.position += transform.forward * movementSpeed * Time.deltaTime;

        // Set animation speed based on movement speed
        animator.SetFloat("Speed", movementSpeed);
    }
}

