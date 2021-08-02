using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePoint : MonoBehaviour
{
    public posClass upPos;
    public posClass downPos;
    public posClass[] rightPos;
    public posClass[] leftPos;

    [System.Serializable]
    public class posClass
    {
        public GameObject pos;
        public bool switchOtherCube;
    }

}
