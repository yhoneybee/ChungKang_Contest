using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Stage;

    public GameObject[] Emblem;
    public Vector3[] Point;

    public GameObject Player;

    public SpriteRenderer[] Arrow_Render;

    private int Dw; //Day of the week

    public static int Stage_Num;

    public static int Stage_Control = 0;

    public static int Dw_Control = 0;
    int Old_Stage_Num;

    Fade_Scene fade_Scene;
    void Start()
    {
        Dw = Dw_Control;
        Stage_Num = Stage_Control;
        fade_Scene = GetComponent<Fade_Scene>();
        Arrow_Render[0] = GameObject.Find("Left_Arrow").GetComponent<SpriteRenderer>();
        Arrow_Render[1] = GameObject.Find("Right_Arrow").GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Dw_Sel();
        Stage_Sel();

        Stage[Stage_Num].SetActive(true);
        Emblem[Dw].SetActive(true);
        Player.transform.position = Point[Dw];

        if(Input.GetKeyDown(KeyCode.Return))
        {
            fade_Scene.Step = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            fade_Scene.Step = 3;
        }

       
    }

    void Dw_Sel()
    {
        for(int i = 0; i < 5; i++) Emblem[i].SetActive(false);

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            if(Dw >= Dw_Control) return;
            Dw++;
            if(Dw > 4) Dw = 4;
            Dw_Stage("Up");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            Dw--;
            if(Dw < 0) Dw = 0;
            Dw_Stage("Up");
        }
    }

    void Stage_Sel()
    {
        int old;
        for (int i = 0; i < 15; i++) Stage[i].SetActive(false);

        if(Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (Stage_Num >= Stage_Control) return;

            old = Stage_Num;
            Stage_Num++;
            //if(Stage_Num > 15) Stage_Num = 13;
            if (Stage_Num % 3 == 0)
            {
                Stage_Num = old;
            }
        }
        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //if (Stage_Num >= Stage_Control)
            //{
            //    Debug.Log(Stage_Num + Stage_Control);
            //    return;
            //}
            ;
            old = Stage_Num;
            Stage_Num--;
            //if(Stage_Num < 0) Stage_Num = 2;
            if ((Stage_Num + 1) % 3 == 0)
            {
                Stage_Num = old;
               //Dw_Stage("Down");
            }
        }
        
        
        
    }

    void Dw_Stage(string UpAndDown)
    {
        if(UpAndDown == "Up")
        {
             switch(Dw)
            {
                case 0:
                    Stage_Num = 0;
                    break;
                case 1:
                    Stage_Num = 3;
                    break;
                case 2:
                    Stage_Num = 6;
                    break;
                case 3:
                    Stage_Num = 9;
                    break;
                case 4:
                    Stage_Num = 12;
                    break;    
            }        
        }
        else if(UpAndDown == "Down")
        {
            switch(Dw)
            {
                case 0:
                    Stage_Num = 2;
                    break;
                case 1:
                    Stage_Num = 5;
                    break;
                case 2:
                    Stage_Num = 8;
                    break;
                case 3:
                    Stage_Num = 11;
                    break;
                case 4:
                    Stage_Num = 14;
                    break;    
            }
        }
        else return;
    }
}
