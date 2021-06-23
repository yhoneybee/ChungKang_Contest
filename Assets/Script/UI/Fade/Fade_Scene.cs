using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fade_Scene : MonoBehaviour
{
    public int Step;

    float fade = 1f;

    GameObject FadePlane;
    CanvasRenderer CanvasRenderer;
    //AudioSource AudioSource;
    void Start()
    {
        FadePlane = GameObject.Find("FadeIn");
        if (FadePlane)
        {
            FadePlane.SetActive(true);
            CanvasRenderer = FadePlane.GetComponent<CanvasRenderer>();
        }
        //AudioSource = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        Step = 0;
    }
    // Update is called once per frame
    void Update()
    {
        switch (Step)
        {
            case 0:
                fade -= Time.deltaTime;
                if (fade <= 0)
                {
                    fade = 0;
                    Step = 1;
                    FadePlane.SetActive(false);
                }
                break;
            case 2:
                fade += Time.deltaTime;
                FadePlane.SetActive(true);
                if (fade >= 1)
                {
                    Step = 3;
                    Sel_Stage();
                }
                break;
            case 3:
                fade += Time.deltaTime;
                FadePlane.SetActive(true);
                if (fade >= 1)
                {
                    Step = 3;
                    GameManager.instance.ChangeScene("Title2");
                }
                break;
        }

        CanvasRenderer.SetAlpha(fade);
    }

    void Sel_Stage()
    {
            switch(StageManager.Stage_Num)
            {
                case 0:
                    GameManager.instance.ChangeScene("Stage1_1");
                    StageClear.Stage = 1;
                    break;
                case 1: 
                    GameManager.instance.ChangeScene("Stage1_2");
                    StageClear.Stage = 12;
                    break;
                case 2:
                    GameManager.instance.ChangeScene("Monday_Boss");
                    StageClear.Stage = 13;
                    break;
                case 3:
                    GameManager.instance.ChangeScene("Stage2_1");
                    StageClear.Stage = 2;
                    break;
                case 4:
                    GameManager.instance.ChangeScene("Stage2_2");
                    StageClear.Stage = 22;
                    break;
                case 5:
                    GameManager.instance.ChangeScene("Tuesday_Boss");
                    StageClear.Stage = 23;
                    break;
                case 6:
                    GameManager.instance.ChangeScene("Stage3_1");
                    StageClear.Stage = 3;
                    break;
                case 7:
                    GameManager.instance.ChangeScene("Stage3_2");
                    StageClear.Stage = 32;
                    break;
                case 8:
                    GameManager.instance.ChangeScene("Wednesday_Boss");
                    StageClear.Stage = 33;
                    break;
                case 9:
                    GameManager.instance.ChangeScene("Stage4_1");
                    StageClear.Stage = 4;
                    break;
                case 10:
                    GameManager.instance.ChangeScene("Stage4_2");
                    StageClear.Stage = 42;
                    break;
                case 11:
                    GameManager.instance.ChangeScene("Thursday_Boss");
                    StageClear.Stage = 43;
                    break;
                case 12:
                    GameManager.instance.ChangeScene("Stage5_1");
                    StageClear.Stage = 5;
                    break;
                case 13:
                    GameManager.instance.ChangeScene("Stage5_2");
                    StageClear.Stage = 52;
                    break;
                case 14:
                    GameManager.instance.ChangeScene("Friday_Boss");
                    StageClear.Stage = 53;
                    break;
        }
    }
}
