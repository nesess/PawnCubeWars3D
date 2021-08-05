using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmokeTrigger : MonoBehaviour
{
    [SerializeField] ParticleSystem smoke;

    bool played = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter()
    {
        if(!played)
        {
            smoke.Play();
            played = true;
        }
        

        StartCoroutine(Stop());
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(2);
        smoke.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
