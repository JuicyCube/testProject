using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public CollectibleCounter collectibleCounter;
    public TextMeshProUGUI collectibleText;
    public TextMeshProUGUI levels;

    private void Start()
    {
        UpdateCollectibleText();
        levels.SetText("Level: " + collectibleCounter.level);
        
    }


    private void UpdateCollectibleText()
    {
        collectibleText.SetText("Collectibles: " + collectibleCounter.totalCollected);
        
    }
}
