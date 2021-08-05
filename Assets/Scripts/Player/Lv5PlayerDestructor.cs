using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv5PlayerDestructor : MonoBehaviour
{
    public GameObject PlayerContainer;
    public GameObject Player;
    bool isDestroyed = false;

    GameObject a;
    GameObject b;

    int totalNumOfPlayers;
    int totalNumOfEnemies;

    float xdirection;
    float zdirection;

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
        
        else 
        {
            for(int i=1;i<=totalNumOfPlayers;i++)
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
