using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ClonePlayer : MonoBehaviour
{
    public GameObject CloneText;
    public GameObject playerOriginal;
    public GameObject playerContainer;
    public int numOfPlayers;   //initial number of players
    public int totalNumOfPlayers;  //number of players after clone

    GameObject initialSpawner;

    bool cloned = false;

    void Awake()
    {
        initialSpawner = GameObject.FindGameObjectWithTag("Initial Spawner");

    }

    void Start()
    {
        numOfPlayers = initialSpawner.GetComponent<PlayerInitialSpawner>().initialNumberOfPlayers;
        totalNumOfPlayers = numOfPlayers;
    }

    void OnTriggerEnter()
    {
        if (!cloned)
            CreatePlayers(numOfPlayers);
    }

    void CreatePlayers(int playerNumber)
    {
        int i;
        for (i = 0; i < 2 * playerNumber - numOfPlayers; i++)
        {
            if (i < playerNumber)
            {
                GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ((i+1) * 0.1f + 2.25f) * 3f, playerOriginal.transform.position.y +3f, playerOriginal.transform.position.z + 1.5f), playerOriginal.transform.rotation);
                PlayerClone.transform.parent = playerContainer.transform;
                PlayerClone.name = "PlayerClone" + (i + 1);
            }
            else if (i >= playerNumber && i < 2*playerNumber)
            {
                GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + 7f, playerOriginal.transform.position.y - 1f, playerOriginal.transform.position.z + ((i - 3) * 0.3f + 1f) * -1.25f), playerOriginal.transform.rotation);
                PlayerClone.transform.parent = playerContainer.transform;
                PlayerClone.name = "PlayerClone" + (i + 1);
            }
            else
            {
                GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + -3.6f, playerOriginal.transform.position.y - 1.6f, playerOriginal.transform.position.z + ((i - 6) * 0.3f + 1f) * -1.25f), playerOriginal.transform.rotation);
                PlayerClone.transform.parent = playerContainer.transform;
                PlayerClone.name = "PlayerClone" + (i + 1);
            }
        }
        totalNumOfPlayers = numOfPlayers + i;
        cloned = true;
        Destroy(CloneText);
        playerContainer.transform.Rotate(0,-90,0);

    }

    void Update()
    {
        //if (cloned)
        //    playerContainer.transform.position = playerOriginal.transform.position;
    }
}

