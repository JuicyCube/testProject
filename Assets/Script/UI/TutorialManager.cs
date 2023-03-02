using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    public GameObject[] popUps;
    private int popUpIndex;
    public float waitTime = 90.5f;
    public CharacterControllerScript player;

    // Start is called before the first frame update
    void Start()
    {
        player.jumpSpeed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < popUps.Length; i++)
        {
            if (i == popUpIndex)
            {
                popUps[i].SetActive(true);
            }
            else
            {
                popUps[i].SetActive(false);
            }
        }
        if (popUpIndex == 0)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 2)
        {
            if (Input.GetKeyDown(KeyCode.D))
            {
                popUpIndex++;
            }
        }
        else if (popUpIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                popUpIndex++;
            }
        }

        else if (popUpIndex == 4)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                player.jumpSpeed = 8;
                popUpIndex++;
            }
        }
        else if (popUpIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
            {
                if (waitTime <= 90f)
                {
                    player.jumpSpeed = 8;
                    popUpIndex++;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
            }
        }
        else if (popUpIndex == 6)
        {
            if (waitTime <= 75f)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 7)
        {
            if (waitTime <= 55f)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 8)
        {
            if (waitTime <= 32)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 9)
        {
            if (waitTime <= 11)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        else if (popUpIndex == 10)
        {
            if (waitTime <= 0)
            {
                popUpIndex++;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
