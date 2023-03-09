using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AiMode : MonoBehaviour
{
    public GameObject AutoCollect;
    public List<Transform> targets;
    public AIDestinationSetter setter;
    public bool isAutoCollectEnabled = false;

    private bool isPathfindingEnabled = false;

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoCollectEnabled && isPathfindingEnabled)
        {
            // Enable auto pathfinding
            setter.enabled = true;
        }
        else
        {
            StopAutoPathfinding();
        }
    }


    public void SetPlayerTarget()
    {
        if (isAutoCollectEnabled)
        {
            setter.enabled = true;
            setter.target = targets[0];
            isPathfindingEnabled = true;
        }
    }

    public void RemoveTarget()
    {
        targets.RemoveAt(0);
    }

    public void StopAutoPathfinding()
    {
        setter.enabled = false;
        isPathfindingEnabled = false;
    }

    public void ToggleAutoCollect()
    {
        isAutoCollectEnabled = !isAutoCollectEnabled;
        if (!isAutoCollectEnabled)
        {
            StopAutoPathfinding();
        }
    }
}
