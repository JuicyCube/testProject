using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public float movementSpeed = 1f;
    public float rotationSpeed = 4f;
    public Animator animator;
    public float attackRange = 2f;
    public float attackDelay = 1f;

    private Transform player;
    private bool canAttack = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Rotate towards the player
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.position - transform.position), rotationSpeed * Time.deltaTime);

        // Move towards the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > attackRange)
        {
            transform.position += transform.forward * movementSpeed * Time.deltaTime;
        }
        else
        {
            if (canAttack)
            {
                StartCoroutine(Attack());
            }
        }

        // Set animation speed based on movement speed
        animator.SetFloat("Speed", movementSpeed);
    }

    IEnumerator Attack()
    {
        canAttack = false;

        // Play attack animation
        animator.SetTrigger("Attack");

        // Wait for attack delay
        yield return new WaitForSeconds(attackDelay);

        canAttack = true;
    }
}


