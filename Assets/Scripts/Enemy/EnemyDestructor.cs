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
    public float destroyTime = 1f;
    int i = 0;

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
        StartCoroutine(DestroyEnemies());
       



        IEnumerator DestroyEnemies()
        {
            var Enemies = new List<GameObject>();
            foreach (Transform child in EnemyContainer.transform) Enemies.Add(child.gameObject);

            if (totalNumOfPlayers > totalNumOfEnemies)
            {
                for (int i = 0; i < totalNumOfEnemies; i++)
                {
                    yield return new WaitForSeconds(0.3f);
                    Destroy(Enemies[i]);
                }
            }
            else
            {
                for (int i = 0; i < totalNumOfPlayers; i++)
                {
                    yield return new WaitForSeconds(0.3f);
                    Destroy(Enemies[i]);
                }
            }
        }
    }
        
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
