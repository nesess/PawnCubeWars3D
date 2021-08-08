using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lv4EnemyCreator : MonoBehaviour
{
    public TextMeshProUGUI redNumber;

    public GameObject enemyOriginal;
    public GameObject enemyContainer;
    public int totalNumOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 0; i < 2; i++)
        {
            GameObject PlayerClone = Instantiate(enemyOriginal, new Vector3(enemyOriginal.transform.position.x + (i * 0.15f +0.3f) * 1.7f, enemyOriginal.transform.position.y +0f, enemyOriginal.transform.position.z + -0f), enemyOriginal.transform.rotation);
            PlayerClone.transform.parent = enemyContainer.transform;
            PlayerClone.name = "EnemyClone" + (i + 1);
        }
        totalNumOfEnemies = i;
        redNumber.text = '5'.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
