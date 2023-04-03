using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CollectibleCounter", menuName = "ScriptableObject/CollectibleCounter")]
public class CollectibleCounter : ScriptableObject
{
    public int level = 1;
    public int totalCollected = 0;
    public bool isAutoCollectEnabled = true;

    public void IncrementCollectible()
    {
        totalCollected += 1;
    }

    public void DecrementCollectible()
    {
        totalCollected--;
    }
    public void Levels()
    {
        level += 1;
    }
    public void Reset()
    {
        //totalCollected = 0;
    }
}

