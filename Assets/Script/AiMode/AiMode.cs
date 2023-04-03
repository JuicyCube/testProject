using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using TMPro;

public class AiMode : MonoBehaviour
{
    [SerializeField] TMP_Text buttonText;
    [SerializeField] Button aiModeButton;
    [SerializeField] bool isAutoCollectEnabled = false;
    public AIDestinationSetter setter;
    public List<Transform> targets;


    // Start is called before the first frame update
    void Start()
    {
        aiModeButton.onClick.AddListener(ToggleAiMode);
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

    private void ToggleAiMode(){
        isAutoCollectEnabled = !isAutoCollectEnabled;
        if(isAutoCollectEnabled){
            buttonText.text = "Stop";
            transform.gameObject.AddComponent<AIPath>();
            transform.gameObject.AddComponent<Seeker>();
            setter = transform.gameObject.AddComponent<AIDestinationSetter>();

            transform.gameObject.AddComponent<AIPath>().maxSpeed = 3;
            setter.target = targets[0];
        }else{
            buttonText.text = "Auto";
            Destroy(transform.GetComponent<AIPath>());
            Destroy(transform.GetComponent<Seeker>());
            Destroy(transform.GetComponent<AIDestinationSetter>());
        }
    }

}
