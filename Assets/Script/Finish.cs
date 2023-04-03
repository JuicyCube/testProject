using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
     [SerializeField] TMP_Text levels;
    public CollectibleCounter collectibleCounter;
    public int requiredCollectibles = 3;
    public int collectiblesMultiplier = 1;

    private Collider finishCollider;
    
    void start()
    {
        levels.text = collectibleCounter.level.ToString();
    }

    private void Awake()
    {
        // Get a reference to the collider component on the finish game object
        finishCollider = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player" && collectibleCounter.totalCollected >= requiredCollectibles * collectiblesMultiplier)
        {
            // Load the scene again with its name or path
            SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
            collectibleCounter.Levels();
            levels.text = collectibleCounter.level.ToString();
        }
        else if(other.gameObject.name == "Player" && collectibleCounter.totalCollected % 3 == 0)
        {
            // Enable the collider component on the finish game object to make it interactable
            finishCollider.enabled = true;
        }
    }
}
