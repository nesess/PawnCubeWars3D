using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lv4SecondEnemyDestructor : MonoBehaviour
{
    public TextMeshProUGUI redNumber;

    public GameObject EnemyContainer;

    GameObject cloner;
    GameObject white;
    int numberFromCloner;
    bool whiteTaken;

    public bool win = false;

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
        white = GameObject.FindGameObjectWithTag("White");
        cloner = GameObject.FindGameObjectWithTag("Object 1");

    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    void OnTriggerEnter()
    {
        numberFromCloner = cloner.GetComponent<Lv4ClonePlayer>().numberToDestructor;
        whiteTaken = white.GetComponent<WhiteCharacter>().turned;

        if (!isDestroyed)
        {          
        

        StartCoroutine(DestroyEnemies());
       
        IEnumerator DestroyEnemies()
        {
            
            var Enemies = new List<GameObject>();
            foreach (Transform child in EnemyContainer.transform) Enemies.Add(child.gameObject);

            if (numberFromCloner==4)
            {
                
                for (int i = 0; i < 3; i++)
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
                        int num = 3 - (i + 1);
                        redNumber.text = num.ToString();
                    isDestroyed = true;
                    win = true;
                }
            }
            else if (numberFromCloner==2 && whiteTaken)
                {
                    for (int i = 0; i < 3; i++)
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
                        int num = 3 - (i + 1);
                        redNumber.text = num.ToString();
                        isDestroyed = true;
                    }
                }
            else if(numberFromCloner==2 && !whiteTaken)
            {
                for (int i = 0; i < 2; i++)
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
                        int num = 3 - (i + 1);
                        redNumber.text = num.ToString();
                    isDestroyed = true;
                }
            }
            else if(numberFromCloner==0 && !whiteTaken)
                {
                    for (int i = 0; i < 3; i++)
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
                        int num = 3 - (i + 1);
                        redNumber.text = num.ToString();
                        isDestroyed = true;
                    }
                }

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
        
    

