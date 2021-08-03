using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lv1EnemyCreator : MonoBehaviour
{
    public GameObject enemyOriginal;
    public GameObject enemyContainer;
    public int totalNumOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 0; i < 4; i++)
        {
            GameObject PlayerClone = Instantiate(enemyOriginal, new Vector3(enemyOriginal.transform.position.x + (i * 0.15f +0f) * 1.7f, enemyOriginal.transform.position.y +0f, enemyOriginal.transform.position.z + -0f), enemyOriginal.transform.rotation);
            PlayerClone.transform.parent = enemyContainer.transform;
            PlayerClone.name = "EnemyClone" + (i + 1);
        }
        totalNumOfEnemies = i;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
