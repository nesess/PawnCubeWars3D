using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreator : MonoBehaviour
{
    public GameObject enemyOriginal;
    public GameObject enemyContainer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 4; i++)
        {
            GameObject PlayerClone = Instantiate(enemyOriginal, new Vector3(enemyOriginal.transform.position.x + (i * 0.25f - 0.5f) * 1.7f, enemyOriginal.transform.position.y - 0.1f, enemyOriginal.transform.position.z + -0.5f), enemyOriginal.transform.rotation);
            PlayerClone.transform.parent = enemyContainer.transform;
            PlayerClone.name = "EnemyClone" + (i + 1);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}