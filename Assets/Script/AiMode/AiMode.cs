using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AiMode : MonoBehaviour
{
    public List<Transform> targets;
    public AIDestinationSetter setter;
    // Start is called before the first frame update
    void Start()
    {
        SetPlayerTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetPlayerTarget()
    {
        setter.target = targets[0];
    }

    public void RemoveTarget()
    {
        targets.RemoveAt(0);
    }
}
