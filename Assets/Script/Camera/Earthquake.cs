﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour
{
    public static Earthquake instance;
    enum Camera_Earthquake {IDLE, MOVE};

    private Camera_Earthquake camera_Earthquake = Camera_Earthquake.IDLE;

    private float CurTime;

    private int Camera_Move_On = 0;

    private float Earthquake_Scale;
    private float Earthquake_Time; 
    private bool Earthquake_On = false;
    // Start is called before the first frame update
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Earthquake_Set(float Scale, float Time, bool Ear_On)
    {
        Earthquake_Scale = Scale;
        Earthquake_Time = Time;
        Earthquake_On = Ear_On;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CurTime += Time.deltaTime;

        switch(camera_Earthquake)
        {
            case Camera_Earthquake.IDLE:
                if(Earthquake_On)
                {
                    CurTime = 0;
                    camera_Earthquake = Camera_Earthquake.MOVE;
                    Earthquake_On = false;
                }
                break;
            case Camera_Earthquake.MOVE:

                if(CurTime > Earthquake_Time)
                {
                    Debug.Log("돌아왕!!");
                    camera_Earthquake = Camera_Earthquake.IDLE;
                    return;
                }

                if (Camera_Move_On == 0)
                {
                    transform.position += new Vector3(Earthquake_Scale, 0, 0) * Time.deltaTime;
                    Debug.Log("+5");
                    Camera_Move_On = 1;
                }
                else if (Camera_Move_On == 1)
                {
                    transform.position -= new Vector3(Earthquake_Scale, 0, 0) * Time.deltaTime;
                    Debug.Log("-5");
                    Camera_Move_On = 0;
                }

                break;
        }
    }
}
