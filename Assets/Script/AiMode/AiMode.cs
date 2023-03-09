using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AiMode : MonoBehaviour
{
    public List<Transform> targets;
    public AIDestinationSetter setter;
    public bool isAutoCollectEnabled = false;

    private void Start()
    {
        SetPlayerTarget();
    }

    private void Update()
    {
        if (isAutoCollectEnabled)
        {
            // Enable auto pathfinding
            setter.enabled = true;
        }
    }

    public void SetPlayerTarget()
    {
        if (isAutoCollectEnabled)
        {
            if (targets.Count > 0)
            {
                setter.enabled = true;
                setter.target = targets[0];
            }
            else
            {
                StopAutoPathfinding();
            }
        }
    }

    public void RemoveTarget()
    {
        targets.RemoveAt(0);
        SetPlayerTarget();
    }

    public void StopAutoPathfinding()
    {
        isAutoCollectEnabled = false;
        setter.enabled = false;
    }
}
