using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestructor : MonoBehaviour
{
    public GameObject EnemyContainer;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void OnTriggerEnter()
    {
        var Enemies = new List<GameObject>();
        foreach (Transform child in EnemyContainer.transform) Enemies.Add(child.gameObject);
        Enemies.ForEach(child => Destroy(child));
    }
    
        
        
    // Update is called once per frame
    void Update()
    {
        
    }
}
