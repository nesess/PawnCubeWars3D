using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructor : MonoBehaviour
{
    public GameObject EnemyContainer;

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

        if (totalNumOfPlayers>totalNumOfEnemies)
        {
            var Enemies = new List<GameObject>();
            foreach (Transform child in EnemyContainer.transform) Enemies.Add(child.gameObject);
            Enemies.ForEach(child => Destroy(child));
        }
    }
        
    
        
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
