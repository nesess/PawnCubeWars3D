using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuCamera : MonoBehaviour
{
    [SerializeField]
    private float speed;
    private float totalMovementTime = 1;
   

    private bool startCamera = true;

  

    // Update is called once per frame
    void Update()
    {
        if(startCamera)
        {
            transform.Rotate(0, speed * Time.deltaTime, 0);
        }

    }

    public void startGame()
    {
        startCamera = false;
        StartCoroutine(moveCamera());
    }

    private IEnumerator moveCamera()
    {

        float currentMovementTime = 0;
        Quaternion startRot = Quaternion.Euler(0, 0, 0);
        while (transform.rotation != startRot)
        {
            currentMovementTime += Time.deltaTime;

            transform.rotation = Quaternion.Lerp(transform.rotation, startRot, currentMovementTime / totalMovementTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
