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
    //public float destroyTime = 1f;
    //int i = 0;

    float xdirection;
    float zdirection;

    bool isDestroyed;

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
        if(!isDestroyed)
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
                        SphereCollider sphereCollider = Enemies[i].GetComponent<SphereCollider>();
                        Destroy(sphereCollider);
                    xdirection = Random.Range(-180, 180);
                    zdirection = Random.Range(-90, 270);

                    Enemies[i].transform.Rotate(90, 0, 0);
                    yield return new WaitForSeconds(0.3f);
                    Rigidbody r = Enemies[i].GetComponent<Rigidbody>();
                    r.AddForce(new Vector3(xdirection,90,zdirection));
                    yield return new WaitForSeconds(0.7f);
                    Destroy(Enemies[i]);
                  
                }
            }
            else
            {
                for (int i = 0; i < totalNumOfPlayers; i++)
                {
                        SphereCollider sphereCollider = Enemies[i].GetComponent<SphereCollider>();
                        Destroy(sphereCollider);
                        xdirection = Random.Range(-180, 180);
                    zdirection = Random.Range(-90, 2700);

                    Enemies[i].transform.Rotate(90, 0, 0);
                    yield return new WaitForSeconds(0.3f);
                    Rigidbody r = Enemies[i].GetComponent<Rigidbody>();
                    r.AddForce(new Vector3(xdirection, 90, zdirection));
                    yield return new WaitForSeconds(0.7f);
                    Destroy(Enemies[i]);
                }
            }
                isDestroyed = true;
        }

        }

    }
        
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
