using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Lv4ClonePlayer : MonoBehaviour
{
    public TextMeshProUGUI blueNumber;

    public GameObject Player;
    public GameObject CloneText;
    public GameObject playerOriginal;
    public GameObject playerContainer;
    public int numOfPlayers;   //initial number of players
    public int totalNumOfPlayers;  //number of players after clone


    public int numberToDestructor;
    GameObject white;

    bool cloned = false;
    bool whiteTaken;

    void Awake()
    {
        white = GameObject.FindGameObjectWithTag("White");

    }

    void Start()
    {
        
    }

    void OnTriggerEnter()
    {
        whiteTaken = white.GetComponent<WhiteCharacter>().turned;
        if (!cloned)
            CreatePlayers();
    }

    void CreatePlayers()
    {
        if(whiteTaken)
        {
            for(int i=0;i<2;i++)
            {
                GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ((i + 1) * 0.1f + -0.8f) * 3f, playerOriginal.transform.position.y + 3f, playerOriginal.transform.position.z + -2.7f), Player.transform.rotation);
                PlayerClone.transform.parent = playerContainer.transform;
                PlayerClone.name = "PlayerClone" + (i + 1);
                numberToDestructor = 4;
                blueNumber.text = '4'.ToString();
            }
        }
        else
        {
            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + (0.1f + -0.8f) * 3f, playerOriginal.transform.position.y + 3f, playerOriginal.transform.position.z + -2.7f), Player.transform.rotation);
            PlayerClone.transform.parent = playerContainer.transform;
            PlayerClone.name = "PlayerClone";
            numberToDestructor = 2;
            blueNumber.text = '2'.ToString();
        }
        cloned = true;
        Destroy(CloneText);






        ////---------------------------------------------
        //int i;
        //for (i = 0; i < 2 * playerNumber - numOfPlayers; i++)
        //{
        //    if (i < playerNumber)
        //    {
        //        if(Player.transform.rotation == Quaternion.Euler(0f,0,0))
        //        {
        //            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ((i+1) * 0.1f + 2.5f) * 3f, playerOriginal.transform.position.y +3f, playerOriginal.transform.position.z + 1.4f), Player.transform.rotation);
        //            PlayerClone.transform.parent = playerContainer.transform;
        //            PlayerClone.name = "PlayerClone" + (i + 1);
        //        }
        //        else if (Player.transform.rotation == Quaternion.Euler(0f, -90, 0))
        //        {
        //            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ( 6.5f) * 1f, playerOriginal.transform.position.y + 3f, playerOriginal.transform.position.z + (i + 1) * 0.2f  + 0.7f), Player.transform.rotation);
        //            PlayerClone.transform.parent = playerContainer.transform;
        //            PlayerClone.name = "PlayerClone" + (i + 1);
        //        }
        //        else if (Player.transform.rotation == Quaternion.Euler(0f, 180, 0))
        //        {
        //            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + ((i + 1) * 0.1f + 2.4f) * 3f, playerOriginal.transform.position.y + 3f, playerOriginal.transform.position.z +0.5f), Player.transform.rotation);
        //            PlayerClone.transform.parent = playerContainer.transform;
        //            PlayerClone.name = "PlayerClone" + (i + 1);
        //        }

        //    }
        //    //else if (i >= playerNumber && i < 2*playerNumber)
        //    //{
        //    //    GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + 7f, playerOriginal.transform.position.y - 1f, playerOriginal.transform.position.z + ((i - 3) * 0.3f + 1f) * -1.25f), playerOriginal.transform.rotation);
        //    //    PlayerClone.transform.parent = playerContainer.transform;
        //    //    PlayerClone.name = "PlayerClone" + (i + 1);
        //    //}
        //    //else
        //    //{
        //    //    GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + -3.6f, playerOriginal.transform.position.y - 1.6f, playerOriginal.transform.position.z + ((i - 6) * 0.3f + 1f) * -1.25f), playerOriginal.transform.rotation);
        //    //    PlayerClone.transform.parent = playerContainer.transform;
        //    //    PlayerClone.name = "PlayerClone" + (i + 1);
        //    //}
        //}
        //totalNumOfPlayers = numOfPlayers + i;
        //cloned = true;
        //Destroy(CloneText);
        ////playerContainer.transform.Rotate(0,-90,0);

    }

    void Update()
    {
        
    }
}

