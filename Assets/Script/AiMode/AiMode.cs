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

    // Start is called before the first frame update
    void Start()
    {
        SetPlayerTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (isAutoCollectEnabled)
        {
            // Enable auto pathfinding
            setter.enabled = true;
        }
    }

    public void SetPlayerTarget()
    {
        if (isAutoCollectEnabled && targets != null && targets.Count > 0)
        {
            setter.enabled = true;
            setter.target = targets[0];
        }
    }

    public void RemoveTarget()
    {
        targets.RemoveAt(0);
    }

    public void StopAutoPathfinding()
    {
        setter.enabled = false;
    }

}
