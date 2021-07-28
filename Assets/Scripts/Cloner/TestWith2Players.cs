using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestWith2Players : MonoBehaviour
{
    public GameObject playerOriginal;
    public GameObject playerContainer;

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<2;i++)
        {
            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + 3.8f, playerOriginal.transform.position.y - 1.6f, playerOriginal.transform.position.z + (i * 0.3f + 1f) * -1.5f), playerOriginal.transform.rotation);
            PlayerClone.transform.parent = playerContainer.transform;
            PlayerClone.name = "PlayerClone" + (i + 1);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        playerContainer.transform.position = playerOriginal.transform.position;
    }
}
