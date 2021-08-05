using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lv2EndScreen : MonoBehaviour
{
    [SerializeField]
    public GameObject EndScreen1;

    [SerializeField]
    public GameObject EndScreen2;

    [SerializeField]
    public GameObject EndScreen3;

    [SerializeField]
    public GameObject EndScreen4;

    bool isGameOver;
    GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("EnemyDestructor");
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = a.GetComponent<Lv2EnemyDestructor>().GameOver;
        if(isGameOver)
        {
            Time.timeScale = 0;
            int blueNumber = a.GetComponent<Lv2EnemyDestructor>().totalNumOfPlayers;
            int redNumber = a.GetComponent<Lv2EnemyDestructor>().totalNumOfEnemies;
            if(redNumber>=blueNumber)
            {
                EndScreen4.SetActive(true);
            }
            else
            {
                if (blueNumber-redNumber == 1)
                {
                    EndScreen1.SetActive(true);
                }
                if (blueNumber-redNumber == 2)
                {
                    EndScreen2.SetActive(true);
                }
                if (blueNumber-redNumber == 3)
                {
                    EndScreen3.SetActive(true);
                }
            }
        }

    }
}
