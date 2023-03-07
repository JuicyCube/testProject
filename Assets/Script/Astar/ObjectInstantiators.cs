using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectInstantiators : MonoBehaviour
{
    public GameObject prefab1;
    private Transform[] prefab1Transform;

    private void Start()
    {
        // Instantiate prefab1 and get its Transform component
        GameObject prefab1Instance = Instantiate(prefab1);
        prefab1Transform = new Transform[] { prefab1Instance.transform };

        // Apply the transform component of the data in prefab1Transform index 0 to a game object
        GameObject targetObject = new GameObject();
        targetObject.transform.position = prefab1Transform[0].position;
        targetObject.transform.rotation = prefab1Transform[0].rotation;
    }
}
