using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleCounter", menuName = "ScriptableObject/CollectibleCounter")]
public class CollectibleCounter : ScriptableObject
{
    public int totalCollected = 0;

    public void IncrementCollectible()
    {
        totalCollected += 1;
    }

    public void DecrementCollectible()
    {
        totalCollected--;
    }

    public void Reset()
    {
        //totalCollected = 0;
    }
}

