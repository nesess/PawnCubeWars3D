using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick joystick;
    public bool canMove = true;

    private void Awake()
    {
        
        joystick = FindObjectOfType<Joystick>();

    }

    // Start is called before the first frame update
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {

            if (joystick.Horizontal > 0.6f)
            {
                GameManager.instance.movePlayer("right");
            }
            else if (joystick.Horizontal < -0.6f)
            {
                GameManager.instance.movePlayer("left");
            }
            else if (joystick.Vertical > 0.6f)
            {
                GameManager.instance.movePlayer("up");
            }
            else if (joystick.Vertical < -0.6f)
            {
                GameManager.instance.movePlayer("down");
            }
        }
    }
}
