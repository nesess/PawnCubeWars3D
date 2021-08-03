using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    [SerializeField]
    private float playerSpeed;

    private GameObject player;
    private bool mooving = false;

    [SerializeField]
    private GameObject cubeLeftSide;
    [SerializeField]
    private GameObject cubeRightSide;

    [SerializeField]
    private GameObject currentPos;

    private bool cubeTurning = false;

    [SerializeField]
    private int leftSide = 1;
    [SerializeField]
    private int rightSide = 1;

   

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
                    
                    if (currentPos.GetComponent<MovePoint>().rightPos != null && currentPos.GetComponent<MovePoint>().rightPos.Length == 4)
                    {
                        if(currentPos.GetComponent<MovePoint>().rightPos[rightSide-1] != null)
                        {
                            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, -90, player.transform.eulerAngles.z);
                            if (currentPos.GetComponent<MovePoint>().rightPos[rightSide - 1].switchOtherCube)
                            {
                                
                                player.transform.parent = cubeRightSide.transform;
                                
                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().rightPos[rightSide - 1].pos));
                                
                            }
                            else
                            {
                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().rightPos[rightSide - 1].pos));
                            }
                        }
                        else
                        {
                            defaultState();
                        }
                        
                    }
                    else if(currentPos.GetComponent<MovePoint>().rightPos != null && currentPos.GetComponent<MovePoint>().rightPos.Length == 1)
                    {
                        if (currentPos.GetComponent<MovePoint>().rightPos[0] != null)
                        {
                            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, -90, player.transform.eulerAngles.z);
                            if (currentPos.GetComponent<MovePoint>().rightPos[0].switchOtherCube)
                            {

                                player.transform.parent = cubeRightSide.transform;

                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().rightPos[0].pos));
                                
                            }
                            else
                            {
                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().rightPos[0].pos));
                            }
                        }
                        else
                        {
                            defaultState();
                        }

                    }
                    else
                    {
                        defaultState();
                    }
                    break;
                case "left":
                    if (currentPos.GetComponent<MovePoint>().leftPos != null && currentPos.GetComponent<MovePoint>().leftPos.Length == 4)
                    {
                        if (currentPos.GetComponent<MovePoint>().leftPos[leftSide - 1] != null)
                        {
                            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 90, player.transform.eulerAngles.z);
                            if (currentPos.GetComponent<MovePoint>().leftPos[leftSide - 1].switchOtherCube)
                            {

                                player.transform.parent = cubeLeftSide.transform;
                                
                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().leftPos[leftSide - 1].pos));
                               
                            }
                            else
                            {
                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().leftPos[leftSide - 1].pos));
                            }
                        }
                        else
                        {
                            defaultState();
                        }

                    }
                    else if (currentPos.GetComponent<MovePoint>().leftPos != null && currentPos.GetComponent<MovePoint>().leftPos.Length == 1)
                    {
                        if (currentPos.GetComponent<MovePoint>().leftPos[0] != null)
                        {
                            player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 90, player.transform.eulerAngles.z);
                            if (currentPos.GetComponent<MovePoint>().leftPos[0].switchOtherCube)
                            {

                                player.transform.parent = cubeLeftSide.transform;

                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().leftPos[0].pos));
                                
                            }
                            else
                            {
                                StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().leftPos[0].pos));
                            }
                        }
                        else
                        {
                            defaultState();
                        }

                    }
                    else
                    {
                        defaultState();
                    }
                    break;
                case "down":
                    if (currentPos.GetComponent<MovePoint>().downPos.pos != null)
                    {

                        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 0, player.transform.eulerAngles.z);
                        if (currentPos.GetComponent<MovePoint>().downPos.switchOtherCube)
                        {
                           
                            StartCoroutine(rotateMoveCoroutine(currentPos.GetComponent<MovePoint>().downPos.pos, "up"));
                            
                            if (player.transform.parent.gameObject.Equals(cubeLeftSide))
                            {
                                
                                if (leftSide == 4)
                                {
                                    leftSide = 1;
                                }
                                else
                                {
                                    leftSide++;
                                   
                                }
                                
                            }
                            else if(player.transform.parent.gameObject.Equals(cubeRightSide))
                            {
                                if (rightSide == 4)
                                {
                                    rightSide = 1;
                                }
                                else
                                {
                                    rightSide++;
                                }
                               
                            }
                           
                        } 
                        else
                        {
                            
                            StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().downPos.pos));    
                        }
                        

                    }
                    else
                    {
                        defaultState();
                    }
                    break;
                case "up":
                    if (currentPos.GetComponent<MovePoint>().upPos.pos != null)
                    {

                        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 180, player.transform.eulerAngles.z);
                        if (currentPos.GetComponent<MovePoint>().upPos.switchOtherCube)
                        {
                            
                            StartCoroutine(rotateMoveCoroutine(currentPos.GetComponent<MovePoint>().upPos.pos, "down"));
                            if (player.transform.parent.gameObject.Equals(cubeLeftSide))
                            {
                                Debug.Log("sa");
                                if (leftSide == 1)
                                {
                                    Debug.Log("saa");
                                    leftSide = 4;
                                }
                                else
                                {
                                    Debug.Log("saaa");
                                    leftSide--;
                                }
                            }
                            else if (player.transform.parent.gameObject.Equals(cubeRightSide))
                            {
                                if (rightSide == 1)
                                {
                                    rightSide = 4;
                                }
                                else
                                {
                                    rightSide--;
                                }
                            }
                        }
                        else
                        {
                            
                            StartCoroutine(moveCoroutine(currentPos.GetComponent<MovePoint>().upPos.pos));
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
   
    private void turnPlayer()
    {
        player.transform.localEulerAngles = new Vector3(player.transform.localEulerAngles.x, 180, 0);
    }

    IEnumerator moveCoroutine(GameObject target)
    {
        Vector3 startpos = player.transform.position;
        float t = 0f;
        while (player.transform.position != target.transform.position)
        {
            t += playerSpeed * Time.deltaTime;
            player.transform.position = Vector3.Lerp(startpos, target.transform.position, t);
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
        

        cubeTurning = false;
        StartCoroutine(LinearRotationRoutine(turnDegree, Vector3.right, 1,player.transform.parent.gameObject));
        while (!cubeTurning )
        {

            yield return null;
        }


        StartCoroutine(LinearRotationRoutine(90, Vector3.left, 0.3f, player));
        

        
        Vector3 startpos = player.transform.position;
        float t = 0;
        t += playerSpeed * Time.deltaTime;
        while ( player.transform.position != target.transform.position)
        {

            t += playerSpeed * Time.deltaTime;
            player.transform.position = Vector3.Lerp(startpos, target.transform.position, t);

            //player.transform.localRotation = Quaternion.Lerp(player.transform.localRotation, endRotationPlayer, currentMovementTime / totalMovementTime);
            yield return new WaitForEndOfFrame();
        }

        currentPos = target;
        mooving = false;

    }



    IEnumerator LinearRotationRoutine(float degrees, Vector3 axis, float duration,GameObject rotateObj)
    {
        Quaternion initialRotation = rotateObj.transform.rotation;
        Quaternion finalRotation = initialRotation * Quaternion.AngleAxis(degrees, axis);

        float timeStart = Time.time;
        float timeEnd = timeStart + duration;

        while (Time.time < timeEnd)
        {
            yield return null;
            float animationTime = Mathf.Clamp01((Time.time - timeStart) / duration);
            rotateObj.transform.rotation = Quaternion.Slerp(initialRotation, finalRotation, animationTime);
        }
        cubeTurning = true;
    }
}
