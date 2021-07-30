using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInitialSpawner : MonoBehaviour
{
    public GameObject playerOriginal;
    public GameObject playerContainer;
    public int initialNumberOfPlayers=3;

    private GameObject playerParent;

    private void Awake()
    {
        playerParent = FindObjectOfType<Player>().gameObject;
    }


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < initialNumberOfPlayers; i++)
        {
            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerParent.transform.position.x + ((i + 1) * 0.15f - 0.25f) * 1.7f, playerParent.transform.position.y + -0.19f, playerParent.transform.position.z + 0f), playerParent.transform.rotation, playerParent.transform);

            PlayerClone.name = "PlayerClone" + (i + 1);
        }

    }

    // Update is called once per frame
    void Update()
    {
        //playerContainer.transform.position = playerOriginal.transform.position;
    }
}
