using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
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
        isGameOver = a.GetComponent<EnemyDestructor>().GameOver;
        if(isGameOver)
        {
            Time.timeScale = 0;
            int blueNumber = a.GetComponent<EnemyDestructor>().totalNumOfPlayers;
            int redNumber = a.GetComponent<EnemyDestructor>().totalNumOfEnemies;
            if(redNumber>=blueNumber)
            {
                GameManager.instance.levelStarsChecker(1, 0);
                EndScreen4.SetActive(true);
            }
            else
            {
                if (blueNumber-redNumber == 1)
                {
                    GameManager.instance.levelStarsChecker(1, 1);
                    EndScreen1.SetActive(true);
                    
                }
                if (blueNumber-redNumber == 2)
                {
                    GameManager.instance.levelStarsChecker(1, 2);
                    EndScreen2.SetActive(true);
                }
                if (blueNumber-redNumber == 3)
                {
                    GameManager.instance.levelStarsChecker(1, 3);
                    EndScreen3.SetActive(true);
                }
            }
        }

    }
}
