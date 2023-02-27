using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public CollectibleCounter collectibleCounter;
    public int requiredCollectibles = 3;
    public int collectiblesMultiplier = 1;

    private Collider finishCollider;

    private void Awake()
    {
        // Get a reference to the collider component on the finish game object
        finishCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && collectibleCounter.totalCollected >= requiredCollectibles * collectiblesMultiplier)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else if(other.gameObject.name == "Player" && collectibleCounter.totalCollected % 3 == 0)
        {
            // Enable the collider component on the finish game object to make it interactable
            finishCollider.enabled = true;
        }
    }
}