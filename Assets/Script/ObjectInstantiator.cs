using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class ObjectInstantiator : MonoBehaviour
{
    [SerializeField] AiMode aiMode;
    public GameObject prefab1;
    public GameObject prefab2;
    public LayerMask groundLayer;
    public float spawnRange = 5f;
    public float spawnHeightOffset = 10f;
    private GameObject prefab1Instance;
    private GameObject prefab2Instance;
    private int count = 10;

    private void Start()
    {
        for (int i = 0; i < count; i++)
        {
            if (i % 2 == 0)
            {
                prefab1Instance = InstantiateOnGround(prefab1);
                prefab1Instance.name = i.ToString();
                aiMode.targets.Add(prefab1Instance.transform);
            }
            else
            {
                prefab2Instance = InstantiateOnGround(prefab2);
                prefab2Instance.name = i.ToString();
                aiMode.targets.Add(prefab2Instance.transform);
            }
        }
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
