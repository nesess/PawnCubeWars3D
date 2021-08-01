using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhiteCharacter : MonoBehaviour
{
    public GameObject playerOriginal;
    public GameObject WhitePlayer;
    public GameObject playerContainer;

    bool turned = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }



    void OnTriggerEnter()
    {
        if (!turned)
        {
            Destroy(WhitePlayer);
            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x-1.3f, playerOriginal.transform.position.y + 3.1f, playerOriginal.transform.position.z + -3.1f), playerOriginal.transform.rotation);
            PlayerClone.transform.parent = playerContainer.transform;
            turned = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
