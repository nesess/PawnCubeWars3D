using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSc;
    [SerializeField]
    private GameObject startSc;
    [SerializeField]
    private GameObject levelSc;

    [SerializeField]
    private GameObject levelText;
    [SerializeField]
    private GameObject touchStartText;

    [SerializeField]
    private GameObject cameraParent;


    [SerializeField]
    private GameObject[] levelButtons;

    [SerializeField]
    private Scene sa;

    private void Start()
    {
        StartCoroutine(textFadeRoutine(touchStartText));
        gameSc.SetActive(false);
        checkLevels();
        PlayerPrefs.SetInt("level1", 3);
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
                    levelButtons[i].GetComponent<Button>().interactable = false;
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

    public void closeLevelScreen()
    {
        startSc.SetActive(true);
        levelSc.SetActive(false);
    }

    public void selectLevelButton(int level)
    {
        SceneManager.LoadScene("Level " + level.ToString());
    }

}
