using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CollectibleCounter collectibleCounter;

    private void Start()
    {
        collectibleCounter.Reset();
    }
}