using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloneSymbolAnim : MonoBehaviour
{
    private float startY;
    private bool topReached = true;
   
    // Start is called before the first frame update
    void Start()
    {
        startY = transform.position.y;
        //StartCoroutine(animCoroutine());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator animCoroutine()
    {
        while(true)
        {
            transform.Rotate(0, 60 * Time.deltaTime, 0);
            if (topReached)
            {
                transform.position += new Vector3(0, 0.01f, 0);
            }
            else
            {
                transform.position -= new Vector3(0, 0.01f, 0);
            }
            
            if(transform.position.y >= startY + 0.2)
            {
                topReached = false;
            }
            
            if(transform.position.y <= startY -0.2 )
            {
                topReached = true;
            }
            yield return new WaitForEndOfFrame();
        }
    }
}
