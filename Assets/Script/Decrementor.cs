using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Decrementor : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    public CollectibleCounter collectibleCounter;
    public Animator animator;
    public CharacterController controller;

    private bool isAnimating = false;

    void Start()
    {
        score.text = collectibleCounter.totalCollected.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            collectibleCounter.DecrementCollectible();
            score.text = collectibleCounter.totalCollected.ToString();

            animator.SetTrigger("Pickup");

            isAnimating = true; // set isAnimating flag to true
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if (isAnimating)
        {
            if (controller.velocity.magnitude > 0f) // check if player is moving
            {
                animator.Play("Idle"); // cancel pickup animation
                isAnimating = false;
                animator.SetBool("IsMoving", true); // set IsMoving parameter to true
            }
            else if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f) // check if pickup animation is finished
            {
                isAnimating = false;
            }
        }
        else
        {
            float speed = controller.velocity.magnitude;
            animator.SetFloat("Speed", speed); // set Speed parameter based on CharacterController velocity

            if (controller.velocity.magnitude > 0f)
            {
                animator.SetBool("IsMoving", true);
            }
            else
            {
                animator.SetBool("IsMoving", false);
            }
        }
    }
}
