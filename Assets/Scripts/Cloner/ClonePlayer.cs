using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ClonePlayer : MonoBehaviour
{
    public TextMeshProUGUI blueNumber;

    public GameObject Player;
    public GameObject CloneText;
    public GameObject playerOriginal;
    public GameObject playerContainer;
    public int numOfPlayers;   //initial number of players
    public int totalNumOfPlayers;  //number of players after clone

    GameObject initialSpawner;

    public bool cloned = false;

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
                if(Player.transform.rotation == Quaternion.Euler(0,0,0))
                {
                    GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ((i+1) * 0.1f + 2.5f) * 3f, playerOriginal.transform.position.y +3f, playerOriginal.transform.position.z + 1.4f), Player.transform.rotation);
                    PlayerClone.transform.parent = playerContainer.transform;
                    PlayerClone.name = "PlayerClone" + (i + 1);
                }
                else if (Player.transform.rotation == Quaternion.Euler(0f, -90, 0))
                {
                    GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ( 6.5f) * 1f, playerOriginal.transform.position.y + 3f, playerOriginal.transform.position.z + (i + 1) * 0.2f  + 0.7f), Player.transform.rotation);
                    PlayerClone.transform.parent = playerContainer.transform;
                    PlayerClone.name = "PlayerClone" + (i + 1);
                }
                else if (Player.transform.rotation == Quaternion.Euler(0f, 180, 0))
                {
                    GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ((i + 1) * 0.1f + 2.4f) * 3f, playerOriginal.transform.position.y + 3f, playerOriginal.transform.position.z +0.5f), Player.transform.rotation);
                    PlayerClone.transform.parent = playerContainer.transform;
                    PlayerClone.name = "PlayerClone" + (i + 1);
                }

            }
            //else if (i >= playerNumber && i < 2*playerNumber)
            //{
            //    GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + 7f, playerOriginal.transform.position.y - 1f, playerOriginal.transform.position.z + ((i - 3) * 0.3f + 1f) * -1.25f), playerOriginal.transform.rotation);
            //    PlayerClone.transform.parent = playerContainer.transform;
            //    PlayerClone.name = "PlayerClone" + (i + 1);
            //}
            //else
            //{
            //    GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + -3.6f, playerOriginal.transform.position.y - 1.6f, playerOriginal.transform.position.z + ((i - 6) * 0.3f + 1f) * -1.25f), playerOriginal.transform.rotation);
            //    PlayerClone.transform.parent = playerContainer.transform;
            //    PlayerClone.name = "PlayerClone" + (i + 1);
            //}
        }
        totalNumOfPlayers = numOfPlayers + i;
        cloned = true;
        Destroy(CloneText);

        int num = 2 * playerNumber;
        blueNumber.text = num.ToString();
        //playerContainer.transform.Rotate(0,-90,0);

    }

    void Update()
    {
        //if (cloned)
        //    playerContainer.transform.position = playerOriginal.transform.position;
    }
}

