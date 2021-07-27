using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    

    [SerializeField]
    private float totalMovementTime;

    private GameObject player;

   
    private bool mooving = false;

    [SerializeField]
    private Transform topLeft;
    [SerializeField]
    private Transform midLeft;
    [SerializeField]
    private Transform botLeft;
    [SerializeField]
    private Transform topRight;
    [SerializeField]
    private Transform midRight;
    [SerializeField]
    private Transform botRight;

    [SerializeField]
    private string currentPos;

    [SerializeField]
    private Transform upPos;
    [SerializeField]
    private Transform downPos;
    [SerializeField]
    private Transform leftPos;
    [SerializeField]
    private Transform rightPos;


    public static GameManager instance;

    

    private void Awake()
    {
        player = FindObjectOfType<Player>().gameObject;
        
        if (GameManager.instance)
        {
            Destroy(base.gameObject);
        }
        else
        {
            GameManager.instance = this;
        }

       
    }

    private void Start()
    {
        currentPos = "topLeft";
    }

    public void movePlayer(string moveLocation)
    {
        if (!mooving)
        {
            mooving = true;
            checkAvailableLocations();
            switch (moveLocation)
            {
                case "right":
                    if(rightPos != null)
                    {
                        StartCoroutine(moveCoroutine(rightPos));
                    }
                    else
                    {
                        Debug.Log("cant go there");
                        mooving = false;
                    }
                    break;
                case "left":
                    if (leftPos != null)
                    {
                        StartCoroutine(moveCoroutine(leftPos));
                    }
                    else
                    {
                        Debug.Log("cant go there");
                        mooving = false;
                    }
                    break;
                case "down":
                    if (downPos != null)
                    {
                        StartCoroutine(moveCoroutine(downPos));
                    }
                    else
                    {
                        Debug.Log("cant go there");
                        mooving = false;
                    }
                    break;
                case "up":
                    if (upPos != null)
                    {
                        StartCoroutine(moveCoroutine(upPos));
                    }
                    else
                    {
                        Debug.Log("cant go there");
                        mooving = false;
                    }
                    break;
                default:
                    Debug.Log("cant go there");
                    mooving = false;
                    break;
            }
            
        }
    }

    private void checkAvailableLocations()
    {
        switch (currentPos)
        {
            case "topLeft":
                upPos = null;
                downPos = midLeft;
                rightPos = topRight;
                leftPos = null;
                break;
            case "midLeft":
                upPos = topLeft;
                downPos = botLeft;
                rightPos = midRight;
                leftPos = null;
                break;
            case "botLeft":
                upPos = midLeft;
                downPos = null;
                rightPos = botRight;
                leftPos = null;
                break;
            case "topRight":
                upPos = null;
                downPos = midRight;
                rightPos = null;
                leftPos = topLeft;
                break;
            case "midRight":
                upPos = topRight;
                downPos = botRight;
                rightPos = null;
                leftPos = midLeft;
                break;
            case "botRight":
                upPos = midRight;
                downPos = null;
                rightPos = null;
                leftPos = botLeft;
                break;
            default:
                Debug.Log("Something went wrong");
                break;
        }
    }

    IEnumerator moveCoroutine(Transform target)
    {
        Vector3 startpos = player.transform.position;
        
        float currentMovementTime = 0f;

        
        while (player.transform.position != target.position)
        {
            currentMovementTime += Time.deltaTime;
            player.transform.position = Vector3.Lerp(startpos, target.position, currentMovementTime / totalMovementTime);
            yield return new WaitForEndOfFrame();
        }
        findMyCurrentPos(target);
        mooving = false;
    }

    private void findMyCurrentPos(Transform target)
    {
        if(target == topLeft)
        {
            currentPos = "topLeft";
        }
        else if (target == midLeft)
        {
            currentPos = "midLeft";
        }
        else if (target == botLeft)
        {
            currentPos = "botLeft";
        }
        else if (target == topRight)
        {
            currentPos = "topRight";
        }
        else if (target == midRight)
        {
            currentPos = "midRight";
        }
        else if (target == botRight)
        {
            currentPos = "botRight";
        }

    }

}
