using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lv4EnemyDestructor : MonoBehaviour
{
    public TextMeshProUGUI redNumber;

    public GameObject EnemyContainer;

    GameObject a;
    GameObject b;

    public int totalNumOfPlayers;
    public int totalNumOfEnemies;


    float xdirection;
    float zdirection;

    bool isDestroyed;
    public bool GameOver;

    void Awake()
    {
        //a = GameObject.FindGameObjectWithTag("Object 1");
        //b = GameObject.FindGameObjectWithTag("Object 2");

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter()
    {
        if(!isDestroyed)
        {          
        //totalNumOfPlayers = a.GetComponent<ClonePlayer>().totalNumOfPlayers;
        //totalNumOfEnemies = b.GetComponent<Lv4EnemyCreator>().totalNumOfEnemies;


        StartCoroutine(DestroyEnemies());
       
        IEnumerator DestroyEnemies()
        {
            
            var Enemies = new List<GameObject>();
            foreach (Transform child in EnemyContainer.transform) Enemies.Add(child.gameObject);
            for(int i=0;i<2;i++)
                {
                    SphereCollider sphereCollider = Enemies[i].GetComponent<SphereCollider>();
                    Destroy(sphereCollider);
                    xdirection = Random.Range(-180, 180);
                    zdirection = Random.Range(-90, 270);

                    Enemies[i].transform.Rotate(90, 0, 0);
                    yield return new WaitForSeconds(0.3f);
                    Rigidbody r = Enemies[i].GetComponent<Rigidbody>();
                    r.AddForce(new Vector3(xdirection, 90, zdirection));
                    yield return new WaitForSeconds(0.7f);
                    Destroy(Enemies[i]);
                    int num = 5 - (i + 1);
                    redNumber.text = num.ToString();
                    isDestroyed = true;
                }


            //if (totalNumOfPlayers > totalNumOfEnemies)
            //{
            //    for (int i = 0; i < totalNumOfEnemies; i++)
            //    {
            //        SphereCollider sphereCollider = Enemies[i].GetComponent<SphereCollider>();
            //        Destroy(sphereCollider);
            //        xdirection = Random.Range(-180, 180);
            //        zdirection = Random.Range(-90, 270);

            //        Enemies[i].transform.Rotate(90, 0, 0);
            //        yield return new WaitForSeconds(0.3f);
            //        Rigidbody r = Enemies[i].GetComponent<Rigidbody>();
            //        r.AddForce(new Vector3(xdirection,90,zdirection));
            //        yield return new WaitForSeconds(0.7f);
            //        Destroy(Enemies[i]);
            //        isDestroyed = true;
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < totalNumOfPlayers; i++)
            //    {
            //        SphereCollider sphereCollider = Enemies[i].GetComponent<SphereCollider>();
            //        Destroy(sphereCollider);
            //        xdirection = Random.Range(-180, 180);
            //        zdirection = Random.Range(-90, 2700);

            //        Enemies[i].transform.Rotate(90, 0, 0);
            //        yield return new WaitForSeconds(0.3f);
            //        Rigidbody r = Enemies[i].GetComponent<Rigidbody>();
            //        r.AddForce(new Vector3(xdirection, 90, zdirection));
            //        yield return new WaitForSeconds(0.7f);
            //        Destroy(Enemies[i]);
            //        isDestroyed = true;
            //    }
            //}

            if (isDestroyed)
            {
                GameOver = true;
            }
             


            } 
        }
        

                   

        }    
    // Update is called once per frame
    void Update()
    {
        
    }
}
        
    

