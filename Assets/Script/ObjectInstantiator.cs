using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ObjectInstantiator : MonoBehaviour
{
    public GameObject prefab1;
    public GameObject prefab2;
    public LayerMask groundLayer;
    public float spawnRange = 5f;
    public float spawnHeightOffset = 10f;
    private GameObject prefab1Instance;
    private GameObject prefab2Instance;
    private int count = 10;
    [SerializeField] Transform[] prefab1Transforms;
    private AIDestinationSetter destinationSetter;

    private void Start()
    {
        prefab1Transforms = new Transform[count];

        for (int i = 0; i < count; i++)
        {
            if (i % 2 == 0)
            {
                prefab1Instance = InstantiateOnGround(prefab1);
                prefab1Transforms[i] = prefab1Instance.transform;
            }
            else
            {
                prefab2Instance = InstantiateOnGround(prefab2);
            }
        }

        // Get the AIDestinationSetter component attached to the game object that this script is attached to
        destinationSetter = GetComponent<AIDestinationSetter>();

        // Set the target transform of the AIDestinationSetter component to the first element in the prefab1Transforms array
        destinationSetter.target = prefab1Transforms[0];
    }

    private GameObject InstantiateOnGround(GameObject prefab)
    {
        GameObject instance = null;
        Vector3 position = new Vector3(Random.Range(-spawnRange, spawnRange), 0f, Random.Range(-spawnRange, spawnRange));
        RaycastHit hit;
        if (Physics.Raycast(position + Vector3.up * spawnHeightOffset, Vector3.down, out hit, Mathf.Infinity, groundLayer))
        {
            instance = Instantiate(prefab, hit.point, Quaternion.identity);
        }
        return instance;
    }
}
