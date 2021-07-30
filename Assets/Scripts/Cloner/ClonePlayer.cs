using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClonePlayer : MonoBehaviour
{
    public GameObject CloneText;
    public GameObject playerOriginal;
    public GameObject playerContainer;
    public int numOfPlayers = 3;

    bool cloned = false;

    void Start()
    {

    }

    void OnTriggerEnter()
    {
        if (!cloned)
            CreatePlayers(numOfPlayers);
    }

    void CreatePlayers(int playerNumber)
    {
        for (int i = 0; i < 2 * playerNumber - numOfPlayers; i++)
        {
            if (i < 3)
            {
                GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ((i+1) * 0.09f + 1.85f) * 3f, playerOriginal.transform.position.y - 0.1f, playerOriginal.transform.position.z + 7.2f), playerOriginal.transform.rotation);
                PlayerClone.transform.parent = playerContainer.transform;
                PlayerClone.name = "PlayerClone" + (i + 1);
            }
            else if (i >= 3 && i < 6)
            {
                GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + -3.3f, playerOriginal.transform.position.y - 1.6f, playerOriginal.transform.position.z + ((i - 3) * 0.3f + 1f) * -1.25f), playerOriginal.transform.rotation);
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

