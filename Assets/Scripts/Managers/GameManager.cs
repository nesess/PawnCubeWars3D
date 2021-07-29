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
    private GameObject cubeLeftSide;
    [SerializeField]
    private GameObject cubeRightSide;

    [SerializeField]
    private GameObject currentPos;

    private bool cubeTurning = false;


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
        //player.transform.parent.transform.rotation = Quaternion.Euler(270,0,0);
       
        
    }

    public void movePlayer(string moveLocation)
    {
        if (!mooving)
        {
            mooving = true;
            switch (moveLocation)
            {
                case "right":
                    if (currentPos.GetComponent<MovePoint>().rightPos != null)
                    {
                        player.transform.parent = cubeRightSide.transform;
                        StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().rightPos));
                        
                    }
                    else
                    {
                        defaultState();
                    }
                    break;
                case "left":
                    if (currentPos.GetComponent<MovePoint>().leftPos != null)
                    {
                        player.transform.parent = cubeLeftSide.transform;
                        StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().leftPos));
                    }
                    else
                    {
                        defaultState();
                    }
                    break;
                case "down":
                    if (currentPos.GetComponent<MovePoint>().downPos != null)
                    {
                        if(currentPos.gameObject.name == "BotLeft" || currentPos.gameObject.name == "BotRight")
                        {
                           
                            StartCoroutine(rotateMoveCoroutine(currentPos.GetComponent<MovePoint>().downPos, "up"));
                           
                        } 
                        else
                        {
                            StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().downPos));
                        }
                        
                    }
                    else
                    {
                        defaultState();
                    }
                    break;
                case "up":
                    if (currentPos.GetComponent<MovePoint>().upPos != null)
                    {
                        if (currentPos.gameObject.name == "TopLeft" || currentPos.gameObject.name == "TopRight")
                        {
                                StartCoroutine(rotateMoveCoroutine(currentPos.GetComponent<MovePoint>().upPos, "down"));
                        }
                        else
                        {
                            StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().upPos));
                        }
                    }
                    else
                    {
                        defaultState();
                    }
                    break;
                default:
                    defaultState();
                    break;
            }

        }
    }

    private void defaultState()
    {
        Debug.Log("cant go there");
        mooving = false;
    }
   

    IEnumerator moveCoroutine(GameObject target)
    {
        Vector3 startpos = player.transform.position;

        float currentMovementTime = 0f;


        while (player.transform.position != target.transform.position)
        {
            currentMovementTime += Time.deltaTime;
            player.transform.position = Vector3.Lerp(startpos, target.transform.position, currentMovementTime / totalMovementTime);
            yield return new WaitForEndOfFrame();
        }
        currentPos = target;
        mooving = false;
    }

    IEnumerator rotateMoveCoroutine(GameObject target,string rotateDirection)
    {


        float turnDegree = 90;
        if(rotateDirection == "down")
        {
            turnDegree = -90;
        }
        float currentMovementTime = 0f;

        cubeTurning = false;
        StartCoroutine(LinearRotationRoutine(turnDegree, Vector3.right, 1));
        while (!cubeTurning )
        {

            yield return null;
        }
        
        

        Quaternion endRotationPlayer = Quaternion.Euler(player.transform.eulerAngles.x - 90, 0, 0);
        if (rotateDirection == "down")
        {
            endRotationPlayer = Quaternion.Euler(player.transform.eulerAngles.x + 90, 0, 0);

        }

        currentMovementTime = 0;
        Vector3 startpos = player.transform.position;
        while ( player.transform.position != target.transform.position)
        {
            currentMovementTime += Time.deltaTime;

            player.transform.position = Vector3.Lerp(startpos, target.transform.position, currentMovementTime / totalMovementTime);

            player.transform.rotation = Quaternion.Lerp(player.transform.rotation, endRotationPlayer, currentMovementTime / totalMovementTime);
            yield return new WaitForEndOfFrame();
        }

        currentPos = target;
        mooving = false;

    }



    IEnumerator LinearRotationRoutine(float degrees, Vector3 axis, float duration)
    {
        Quaternion initialRotation = player.transform.parent.transform.rotation;
        Quaternion finalRotation = initialRotation * Quaternion.AngleAxis(degrees, axis);

        float timeStart = Time.time;
        float timeEnd = timeStart + duration;

        while (Time.time < timeEnd)
        {
            yield return null;
            float animationTime = Mathf.Clamp01((Time.time - timeStart) / duration);
            player.transform.parent.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, animationTime);
        }
        cubeTurning = true;
    }
}
