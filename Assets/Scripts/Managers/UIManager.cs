using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField]
    private GameObject gameSc;
    [SerializeField]
    private GameObject startSc;

    [SerializeField]
    private GameObject levelText;
    [SerializeField]
    private GameObject touchStartText;

    [SerializeField]
    private GameObject cameraParent;

    private void Start()
    {
        StartCoroutine(textFadeRoutine(touchStartText));
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
        while(text.gameObject.activeInHierarchy)
        {
            
            if(text.GetComponent<TextMeshProUGUI>().alpha <= 0)
            {
                fadeOut = false;
            }
            else if(text.GetComponent<TextMeshProUGUI>().alpha >=1)
            {
                fadeOut = true;
            }

            if(fadeOut)
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
}
