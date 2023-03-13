using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Decrementor : MonoBehaviour
{
    [SerializeField] AiMode aiMode;
    [SerializeField] TMP_Text score;
    public CollectibleCounter collectibleCounter;
    public Animator animator;
    public CharacterController controller;

    //private bool isAnimating = false;

    void Start()
    {
        score.text = collectibleCounter.totalCollected.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle") && other.transform.name == aiMode.targets[0].name)
        {
            // check if isAutoCollectEnabled is false before allowing the object to be picked up
            if (!collectibleCounter.isAutoCollectEnabled)
            {
                collectibleCounter.DecrementCollectible();
                score.text = collectibleCounter.totalCollected.ToString();

                animator.SetBool("Pickup", true);

                //isAnimating = true; // set isAnimating flag to true
                Destroy(other.gameObject);
                // Set the "Pickup" animation parameter to false after the animation has finished playing

                if (aiMode.targets.Count != 1)
                {
                    aiMode.RemoveTarget();
                    aiMode.SetPlayerTarget();
                }
                StartCoroutine(WaitForAnimationFinish());

            }
        }
    }


    private IEnumerator WaitForAnimationFinish()
    {
        // Wait for one frame to ensure that the animation parameter has been updated
        yield return null;

        // Wait for the "Pickup" animation to finish playing
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Pickup"))
        {
            yield return null;
        }

        // Set the "Pickup" animation parameter to false
        animator.SetBool("Pickup", false);
    }

}

