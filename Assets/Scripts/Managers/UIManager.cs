using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    
    public GameObject gameSc;
    [SerializeField]
    private GameObject startSc;
    [SerializeField]
    private GameObject levelSc;

    [SerializeField]
    private TextMeshProUGUI levelText;
    [SerializeField]
    private GameObject touchStartText;

    [SerializeField]
    private GameObject cameraParent;


    [SerializeField]
    private GameObject shopButton;

    [SerializeField]
    private GameObject[] levelButtons;

    [SerializeField]
    private GameObject[] uýStars;
    [SerializeField]
    private TextMeshProUGUI endScCompleteText;
    [SerializeField]
    private TextMeshProUGUI endScLevelText;
    [SerializeField]
    private Button nextLevelButton;


    public static UIManager instance;


    private void Awake()
    {
        

        

    }

    

    private void Start()
    {
        shopButton.GetComponent<Button>().interactable = false;
        StartCoroutine(textFadeRoutine(touchStartText));
        gameSc.SetActive(false);
        checkLevels();
        levelText.text = "Level 1-" + PlayerPrefs.GetInt("currentLevel", 1);
        
    

        Time.timeScale = 1;
  
        if (UIManager.instance)
        {
            //Destroy(base.gameObject);
        }
        else
        {
            UIManager.instance = this;
        }

    }

    public void startGameButton()
    {
        startSc.SetActive(false);
        cameraParent.gameObject.GetComponent<StartMenuCamera>().startGame();
        gameSc.SetActive(true);
    }

    private IEnumerator textFadeRoutine(GameObject text)
    {
        bool fadeOut = true;
        while (text.gameObject.activeInHierarchy)
        {

            if (text.GetComponent<TextMeshProUGUI>().alpha <= 0)
            {
                fadeOut = false;
            }
            else if (text.GetComponent<TextMeshProUGUI>().alpha >= 1)
            {
                fadeOut = true;
            }

            if (fadeOut)
            {
                text.GetComponent<TextMeshProUGUI>().alpha -= 0.1f;

            }
            else
            {
                text.GetComponent<TextMeshProUGUI>().alpha += 0.1f;
            }

            yield return new WaitForSeconds(0.1f);
        }
    }

    public void openLevelScreenButton()
    {
        startSc.SetActive(false);
        levelSc.SetActive(true);
        checkLevels();
    }

    private void checkLevels()
    {
        for(int i = 0;i<levelButtons.Length;i++)
        {
            levelButtons[i].GetComponent<Button>().interactable = true;
            switch (PlayerPrefs.GetInt("level" +(i+1).ToString(),0))
            {
                case 0:
                    if(!(PlayerPrefs.GetInt("level" + (i).ToString(), 0) >0))
                    {
                        levelButtons[i].GetComponent<Button>().interactable = false;
                    }
                    levelButtons[i].transform.GetChild(0).gameObject.SetActive(true);
                    break;
                case 1:
                    levelButtons[i].transform.GetChild(1).gameObject.SetActive(true);
                    break;
                case 2:
                    levelButtons[i].transform.GetChild(2).gameObject.SetActive(true);
                    break;
                case 3:
                    levelButtons[i].transform.GetChild(3).gameObject.SetActive(true);
                    break;
                default:
                    Debug.Log("something went wrong");
                    break;
            }
        }
    }

    public void levelStarsChecker(int level, int stars)
    {
       
        if (PlayerPrefs.GetInt("level" + level.ToString(), 0) < stars)
        {
            PlayerPrefs.SetInt("totalStars", PlayerPrefs.GetInt("totalStars",0) + (stars - PlayerPrefs.GetInt("level" + level.ToString(),0)));
            PlayerPrefs.SetInt("level" + level.ToString(), stars);
            
        }
        endScUICheck(stars);
    }

    
    private void endScUICheck(int stars)
    {
        if(stars > 0)
        {
            endScCompleteText.text = "COMPLETE";
        }
        else
        {
            endScCompleteText.text = "FAILED";
        }
        uýStars[stars].SetActive(true);
        endScLevelText.text = "LEVEL 1 - " + PlayerPrefs.GetInt("currentLevel", 1).ToString();
        checkEndButton();

    }

    public void closeLevelScreen()
    {
        startSc.SetActive(true);
        StartCoroutine(textFadeRoutine(touchStartText));
        levelSc.SetActive(false);
    }

    public void selectLevelButton(int level)
    {
        PlayerPrefs.SetInt("currentLevel", level);
        SceneManager.LoadScene("Level " + level.ToString());
    }

    public void endScreenReturnMenuButton()
    {
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("currentLevel",1));
    }

    public void endScreenRetryButton()
    {

        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("currentLevel", 1));

    }

    

    public void endScreenNextLevelButton()
    {
        PlayerPrefs.SetInt("currentLevel", PlayerPrefs.GetInt("currentLevel", 1) + 1);
        SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("currentLevel", 1));
    }

    private void checkEndButton()
    {
        if(PlayerPrefs.GetInt("currentLevel", 1) >= 5)
        {
            nextLevelButton.interactable = false;
        }
        else if(PlayerPrefs.GetInt("level" + PlayerPrefs.GetInt("currentLevel",1).ToString(),0) ==0)
        {
            nextLevelButton.interactable = false;
        }
    }
    
   

}
