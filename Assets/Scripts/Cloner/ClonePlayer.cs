using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePlayer : MonoBehaviour
{
    public GameObject playerOriginal;
    public GameObject playerContainer;
    public int cloneIndex = 2;
    public int numOfPlayers = 1;

    bool cloned = false;

    void Start()
    {

    }

    void OnTriggerEnter()
    {
        if (!cloned)
            CreatePlayers(1 * cloneIndex - 1);
    }

    void CreatePlayers(int playerNumber)
    {
        for (int i = 0; i < playerNumber; i++)
        {
            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x - 1f, playerOriginal.transform.position.y -1.6f, playerOriginal.transform.position.z-1f), playerOriginal.transform.rotation);
            PlayerClone.transform.parent = playerContainer.transform;
            PlayerClone.name = "PlayerClone" + (i + 1);
            cloned = true;
        }
    }

    void Update()
    {
        if(cloned)
        playerContainer.transform.position = playerOriginal.transform.position + new Vector3(-1f, 0, 0);
    }
}

