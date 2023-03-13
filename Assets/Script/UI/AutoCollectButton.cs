using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoCollectButton : MonoBehaviour
{
    public AiMode aiMode;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(ToggleAutoCollect);
    }

    private void ToggleAutoCollect()
    {
        aiMode.isAutoCollectEnabled = !aiMode.isAutoCollectEnabled;

        if (aiMode.isAutoCollectEnabled)
        {
            aiMode.SetPlayerTarget();
        }
        else
        {
            aiMode.StopAutoPathfinding();
            aiMode.targets = null;
        }
    }
}
