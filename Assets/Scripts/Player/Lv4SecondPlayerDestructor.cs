using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lv4SecondPlayerDestructor : MonoBehaviour
{
    public TextMeshProUGUI blueNumber;

    public GameObject PlayerContainer;
    public GameObject Player;
    bool isDestroyed = false;

    GameObject cloner;
    GameObject white;
    bool whiteTaken;
    public int numberFromCloner;

    GameObject a;
    GameObject b;

    int totalNumOfPlayers;
    int totalNumOfEnemies;

    float xdirection;
    float zdirection;

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
        whiteTaken = white.GetComponent<WhiteCharacter>().turned;
        numberFromCloner = cloner.GetComponent<Lv4ClonePlayer>().numberToDestructor;

        int num = numberFromCloner - 1;
        blueNumber.text = num.ToString();

        StartCoroutine(DestructPlayers());

        IEnumerator DestructPlayers()
        {
            var PlayersToDestuct = new List<GameObject>();
            foreach (Transform child in Player.transform) PlayersToDestuct.Add(child.gameObject);
            foreach (Transform child in PlayerContainer.transform) PlayersToDestuct.Add(child.gameObject);

            if (!isDestroyed)
            {
                if(numberFromCloner == 4)
                {
                for (int i = 1; i < 4; i++)
                {
                    SphereCollider sphereCollider = PlayersToDestuct[i].GetComponent<SphereCollider>();
                    Destroy(sphereCollider);
                    xdirection = Random.Range(-180, 360);
                    zdirection = Random.Range(-90, 270);

                    PlayersToDestuct[i].transform.Rotate(90, 0, 0);
                    yield return new WaitForSeconds(0.3f);
                    Rigidbody r = PlayersToDestuct[i].GetComponent<Rigidbody>();
                    r.AddForce(new Vector3(xdirection, 90, zdirection));
                    yield return new WaitForSeconds(0.7f);
                    Destroy(PlayersToDestuct[i]);
                        int num = 4;
                        num = num - (i + 1);
                        blueNumber.text = num.ToString();
                    }
                isDestroyed = true;
                }
                else if (numberFromCloner == 2 && whiteTaken)
                {
                    for (int i = 1; i < 4; i++)
                    {
                        SphereCollider sphereCollider = PlayersToDestuct[i].GetComponent<SphereCollider>();
                        Destroy(sphereCollider);
                        xdirection = Random.Range(-180, 360);
                        zdirection = Random.Range(-90, 270);

                        PlayersToDestuct[i].transform.Rotate(90, 0, 0);
                        yield return new WaitForSeconds(0.3f);
                        Rigidbody r = PlayersToDestuct[i].GetComponent<Rigidbody>();
                        r.AddForce(new Vector3(xdirection, 90, zdirection));
                        yield return new WaitForSeconds(0.7f);
                        Destroy(PlayersToDestuct[i]);
                        int num = 3;
                        num = num - (i + 0);
                        blueNumber.text = num.ToString();
                    }
                }
                else if(numberFromCloner == 2 && !whiteTaken)
                {
                    for (int i = 1; i < 3; i++)
                    {
                        SphereCollider sphereCollider = PlayersToDestuct[i].GetComponent<SphereCollider>();
                        Destroy(sphereCollider);
                        xdirection = Random.Range(-180, 360);
                        zdirection = Random.Range(-90, 270);

                        PlayersToDestuct[i].transform.Rotate(90, 0, 0);
                        yield return new WaitForSeconds(0.3f);
                        Rigidbody r = PlayersToDestuct[i].GetComponent<Rigidbody>();
                        r.AddForce(new Vector3(xdirection, 90, zdirection));
                        yield return new WaitForSeconds(0.7f);
                        Destroy(PlayersToDestuct[i]);
                        int num = 2;
                        num = num - (i + 0);
                        blueNumber.text = num.ToString();
                    }
                    isDestroyed = true;
                }
                else if (numberFromCloner == 0 && !whiteTaken)
                {
                            for (int i = 1; i < 4; i++)
                            {
                                SphereCollider sphereCollider = PlayersToDestuct[i].GetComponent<SphereCollider>();
                                Destroy(sphereCollider);
                                xdirection = Random.Range(-180, 360);
                                zdirection = Random.Range(-90, 270);

                                PlayersToDestuct[i].transform.Rotate(90, 0, 0);
                                yield return new WaitForSeconds(0.3f);
                                Rigidbody r = PlayersToDestuct[i].GetComponent<Rigidbody>();
                                r.AddForce(new Vector3(xdirection, 90, zdirection));
                                yield return new WaitForSeconds(0.7f);
                                Destroy(PlayersToDestuct[i]);
                            }
                            isDestroyed = true;
                        }


            }

                
            }



                //------------------------------------------------
        //        totalNumOfPlayers = a.GetComponent<ClonePlayer>().totalNumOfPlayers;
        //totalNumOfEnemies = b.GetComponent<Lv4EnemyCreator>().totalNumOfEnemies;


        
        
        //StartCoroutine(DestructPlayers());

        //IEnumerator DestructPlayers()
        //{
        //var PlayersToDestuct = new List<GameObject>();
        //foreach (Transform child in Player.transform) PlayersToDestuct.Add(child.gameObject);
        //foreach (Transform child in PlayerContainer.transform) PlayersToDestuct.Add(child.gameObject);
        
        //if (!isDestroyed)
        //{
        //if (totalNumOfPlayers > totalNumOfEnemies)
        //{
        //    for (int i = 1; i <= totalNumOfEnemies; i++)
        //            {
        //                SphereCollider sphereCollider = PlayersToDestuct[i].GetComponent<SphereCollider>();
        //                Destroy(sphereCollider);
        //                xdirection = Random.Range(-180, 360);
        //                zdirection = Random.Range(-90, 270);

        //                PlayersToDestuct[i].transform.Rotate(90, 0, 0);
        //                yield return new WaitForSeconds(0.3f);
        //                Rigidbody r = PlayersToDestuct[i].GetComponent<Rigidbody>();
        //                r.AddForce(new Vector3(xdirection, 90, zdirection));
        //                yield return new WaitForSeconds(0.7f);
        //                Destroy(PlayersToDestuct[i]);
        //            }
        //    isDestroyed = true;
        //}
        
        //else 
        //{
        //    for(int i=1;i<=totalNumOfPlayers;i++)
        //    {
        //                SphereCollider sphereCollider = PlayersToDestuct[i].GetComponent<SphereCollider>();
        //                Destroy(sphereCollider);
        //                xdirection = Random.Range(-180, 360);
        //                zdirection = Random.Range(-90, 270);

        //                PlayersToDestuct[i].transform.Rotate(90, 0, 0);
        //                yield return new WaitForSeconds(0.3f);
        //                Rigidbody r = PlayersToDestuct[i].GetComponent<Rigidbody>();
        //                r.AddForce(new Vector3(xdirection, 90, zdirection));
        //                yield return new WaitForSeconds(0.7f);
        //                Destroy(PlayersToDestuct[i]);
        //            }
        //    isDestroyed = true;
        //}
        //}
        
        }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
