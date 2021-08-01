using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestructor : MonoBehaviour
{
    public GameObject PlayerContainer;
    public GameObject Player;
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


        

        StartCoroutine(DestructPlayers());

        IEnumerator DestructPlayers()
        {
        var PlayersToDestuct = new List<GameObject>();
        foreach (Transform child in Player.transform) PlayersToDestuct.Add(child.gameObject);
        foreach (Transform child in PlayerContainer.transform) PlayersToDestuct.Add(child.gameObject);
        
        if (!isDestroyed)
        {
        if (totalNumOfPlayers > totalNumOfEnemies)
        {
            for (int i = 1; i <= totalNumOfEnemies; i++)
            {
                yield return new WaitForSeconds(0.3f);
                Destroy(PlayersToDestuct[i]);
            }
            isDestroyed = true;
        }
        
        else 
        {
            for(int i=1;i<=totalNumOfPlayers;i++)
            {
                yield return new WaitForSeconds(0.3f);
                Destroy(PlayersToDestuct[i]);
            }
            isDestroyed = true;
        }
        }
        
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
