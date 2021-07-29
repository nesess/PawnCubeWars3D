using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreePlayers : MonoBehaviour
{
    public GameObject playerOriginal;
    public GameObject playerContainer;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject PlayerClone = Instantiate(playerOriginal, new Vector3(playerOriginal.transform.position.x + (i * 0.25f + 2.1f) * 1.7f, playerOriginal.transform.position.y - 2f, playerOriginal.transform.position.z + -1.1f), playerOriginal.transform.rotation);
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
