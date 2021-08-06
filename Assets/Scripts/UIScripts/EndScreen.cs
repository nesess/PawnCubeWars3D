using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreen : MonoBehaviour
{
    [SerializeField]
    public GameObject EndScreen1;


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
                UIManager.instance.levelStarsChecker(1, 0);
                EndScreen1.SetActive(true);
            }
            else
            {
                if (blueNumber-redNumber == 1)
                {
                    UIManager.instance.levelStarsChecker(1, 1);
                    EndScreen1.SetActive(true);
                    
                }
                if (blueNumber-redNumber == 2)
                {
                    UIManager.instance.levelStarsChecker(1, 2);
                    EndScreen1.SetActive(true);
                }
                if (blueNumber-redNumber == 3)
                {
                    UIManager.instance.levelStarsChecker(1, 3);
                    EndScreen1.SetActive(true);
                }
            }
        }

    }
}
