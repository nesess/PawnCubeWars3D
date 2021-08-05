using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lv4EndScreen : MonoBehaviour
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
    bool win;
    GameObject a;

    // Start is called before the first frame update
    void Start()
    {
        a = GameObject.FindGameObjectWithTag("Enemy Destructor 4 2");
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = a.GetComponent<Lv4SecondEnemyDestructor>().GameOver;
        win = a.GetComponent<Lv4SecondEnemyDestructor>().win;
        if (isGameOver)
        {
            Time.timeScale = 0;
            int blueNumber = 2;
            
            
            if(!win)
            {
                EndScreen4.SetActive(true);
            }
            else
            {
                if (win)
                {
                    EndScreen1.SetActive(true);
                }
                //if (blueNumber-redNumber == 2)
                //{
                //    EndScreen2.SetActive(true);
                //}
                //if (blueNumber-redNumber == 3)
                //{
                //    EndScreen3.SetActive(true);
                //}
            }
        }

    }
}
