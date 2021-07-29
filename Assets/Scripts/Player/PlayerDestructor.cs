using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestructor : MonoBehaviour
{
    public GameObject PlayerContainer;
    bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnTriggerEnter()
    {
        var PlayersToDestuct = new List<GameObject>();
        foreach (Transform child in PlayerContainer.transform) PlayersToDestuct.Add(child.gameObject);
        
       if(!isDestroyed)
        {
            Destroy(PlayersToDestuct[0]);
            Destroy(PlayersToDestuct[3]);
            isDestroyed = true;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
