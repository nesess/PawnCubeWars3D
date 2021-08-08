using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WhiteCharacter : MonoBehaviour
{
    public TextMeshProUGUI blueNumber;

    public GameObject playerOriginal;
    public GameObject WhitePlayer;
    public GameObject playerContainer;

    public bool turned = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    void OnTriggerEnter()
    {
        if (!turned)
        {
            Destroy(WhitePlayer);
            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x +7.3f, playerOriginal.transform.position.y + 3.1f, playerOriginal.transform.position.z + 5.4f), playerOriginal.transform.rotation);
            PlayerClone.transform.Rotate(0, 180, 0);
            PlayerClone.transform.parent = playerContainer.transform;
            turned = true;
            blueNumber.text = '4'.ToString();
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
