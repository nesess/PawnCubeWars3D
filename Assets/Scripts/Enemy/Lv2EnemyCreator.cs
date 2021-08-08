using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Lv2EnemyCreator : MonoBehaviour
{
    public TextMeshProUGUI redNumber;

    public GameObject enemyOriginal;
    public GameObject enemyContainer;
    public int totalNumOfEnemies;

    // Start is called before the first frame update
    void Start()
    {
        int i;
        for (i = 0; i < 3; i++)
        {
            GameObject PlayerClone = Instantiate(enemyOriginal, new Vector3(enemyOriginal.transform.position.x + (i * 0.15f +-3.3f) * 1.7f, enemyOriginal.transform.position.y +-11.4f, enemyOriginal.transform.position.z + -1f), enemyOriginal.transform.rotation);
            PlayerClone.transform.Rotate(-90f, 0, 0);
            PlayerClone.transform.parent = enemyContainer.transform;
            PlayerClone.name = "EnemyClone" + (i + 1);
        }
        totalNumOfEnemies = i;
        redNumber.text = '3'.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
