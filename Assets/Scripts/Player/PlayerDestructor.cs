using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestructor : MonoBehaviour
{
    public GameObject PlayerContainer;
    bool isDestroyed = false;

    GameObject a;
    GameObject b;

    int totalNumOfPlayers;
    int totalNumOfEnemies;

    void Awake()
    {
        a = GameObject.FindGameObjectWithTag("Object 1");
        b = GameObject.FindGameObjectWithTag("Object 2");

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter()
    {
        totalNumOfPlayers = a.GetComponent<ClonePlayer>().totalNumOfPlayers;
        totalNumOfEnemies = b.GetComponent<EnemyCreator>().totalNumOfEnemies;

        if (totalNumOfPlayers > totalNumOfEnemies)
        {

        
            var PlayersToDestuct = new List<GameObject>();
        foreach (Transform child in PlayerContainer.transform) PlayersToDestuct.Add(child.gameObject);
        
       if(!isDestroyed)
        {
            Destroy(PlayersToDestuct[0]);
            Destroy(PlayersToDestuct[3]);
            isDestroyed = true;
        }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
