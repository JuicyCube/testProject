using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public CollectibleCounter collectibleCounter;
    public TextMeshProUGUI collectibleText;

    private void Start()
    {
        UpdateCollectibleText();
        
    }


    private void UpdateCollectibleText()
    {
        collectibleText.SetText("Collectibles: " + collectibleCounter.totalCollected);
    }
}
