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
        Debug.Log(rotateDirection);

        Quaternion endRotation =  Quaternion.Euler(player.transform.parent.transform.eulerAngles.x + 90, 0, 0);
        

        if (rotateDirection == "down")
        {
            endRotation = Quaternion.Euler((player.transform.parent.transform.eulerAngles.x -90),0,0);
            

        }
       

        float currentMovementTime = 0f; 

        while (player.transform.parent.transform.rotation != endRotation )
        {
            currentMovementTime += Time.deltaTime;


            player.transform.parent.transform.rotation = Quaternion.Lerp(player.transform.parent.transform.rotation,endRotation, currentMovementTime / totalMovementTime);


            yield return new WaitForEndOfFrame();
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


}
