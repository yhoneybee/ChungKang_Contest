using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gocomegocome : MonoBehaviour
{
    enum Object_Move { IDLE, WAIT, WALK };

    private Object_Move object_Move = Object_Move.WALK;
    int a = 1;
    int b = 1;
    [Header("0으로 만들면 그 축은 변함 X")]
    [SerializeField] [Range(0, 1)] public int x = 1;
    [SerializeField] [Range(0, 1)] public int y = 1;
    float startPSX;
    float startPSY;
    [Header("속도")]
    public int speed = 5;
    [Header("움직이는 거리 설정")]
    public float leftDistance = 0;
    public float rightDistance = 0;
    public float downDistance = 0;
    public float upDistance = 0;

    private float CurTime = 0;
    public float MaxTime;

    public Vector3 Now_Pos;

    public Vector3 Old_Pos;
    void Start()
    {
        startPSX = transform.position.x;
        startPSY = transform.position.y;
    }
    void FixedUpdate()
    {
        CurTime += Time.deltaTime;

        switch (object_Move)
        {
            case Object_Move.WAIT:
                if (CurTime < MaxTime) return;

                object_Move = Object_Move.WALK;
                //Debug.Log("자 바뀐다!");

                break;
            case Object_Move.WALK:
                if (transform.position.x < startPSX - leftDistance)
                {
                    object_Move = Object_Move.WAIT;
                    CurTime = 0;
                    a = 1;
                    //                    Debug.Log(a);
                    //return;
                }
                else if (transform.position.x > startPSX + rightDistance)
                {
                    object_Move = Object_Move.WAIT;
                    CurTime = 0;
                    a = -1;
                    //                   Debug.Log(a);
                    //return;
                }
                if (transform.position.y < startPSY - downDistance)
                {
                    object_Move = Object_Move.WAIT;
                    CurTime = 0;
                    b = 1;
                    //Debug.Log(b);
                    //return;
                }
                else if (transform.position.y > startPSY + upDistance)
                {
                    object_Move = Object_Move.WAIT;
                    CurTime = 0;
                    b = -1;
                    //Debug.Log(b);
                    //return;
                }

                if (Typing.AllowMove)
                {
                    Old_Pos = transform.position;
                    transform.Translate(Time.deltaTime * a * speed * x, Time.deltaTime * b * speed * y, 0);
                    Now_Pos = transform.position;
                }

                break;
        }
    }
}
