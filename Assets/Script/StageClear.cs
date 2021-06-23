using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClear : MonoBehaviour
{
    // Start is called before the first frame update
    public static int Stage = 1;

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
                    if (FadePlane)
                        FadePlane.SetActive(false);
                }
                break;
            case 2:
                fade += Time.deltaTime;
                if (fade >= 1)
                {
                    Step = 3;
                    Next_Stage();
                }
                break;
        }

        //AudioSource.volume = 1.0f - fade;
        if (CanvasRenderer)
            CanvasRenderer.SetAlpha(fade);
    }

    void Next_Stage()
    {
        /*if(Stage == 1)
            {
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("2Stage");
                Stage = 2;
            }*/
        //12 = 1-2   13 = 1-3 이런식으로 스테이지 표시했음 
        switch (Stage) 
        {
            case 1:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 12;
                StageManager.Stage_Control++;
                break;
            case 12:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 13;
                StageManager.Stage_Control++;
                break;
            case 2:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 22;
                StageManager.Stage_Control++;
                break;
            case 22:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 23;
                StageManager.Stage_Control++;
                break;
            case 3:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 32;
                StageManager.Stage_Control++;
                break;
            case 32:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 33;
                StageManager.Stage_Control++;
                break;
            case 4:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 42;
                StageManager.Stage_Control++;
                break;
            case 42:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 43;
                StageManager.Stage_Control++;
                break;
            case 5:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                Stage = 52;
                StageManager.Stage_Control++;
                break;
            case 52:
                GameManager.hp = GameManager.maxHp;
                GameManager.instance.ChangeScene("StageSel");
                StageManager.Stage_Control++;
                Stage = 53;
                //Stage = 2;
                break;

        }
        //if (Stage == 1)
        //{
           
        //}
        //else if (Stage == 12)
        //{
            
        //}
        //else if (Stage == 13)
        //{
           
        //}
        //else if (Stage == 2)
        //{
        //    GameManager.hp = GameManager.maxHp;
        //    GameManager.instance.ChangeScene("3Stage");
        //    Stage = 3;
        //}
        //else if()
        //else if (Stage == 3)
        //{
        //    GameManager.hp = GameManager.maxHp;
        //    GameManager.instance.ChangeScene("4Stage");
        //    Stage = 4;
        //}
        //else if (Stage == 4)
        //{
        //    GameManager.hp = GameManager.maxHp;
        //    GameManager.instance.ChangeScene("5Stage");
        //    Stage = 5;
        //}
        //else if (Stage == 5)
        //{
        //    GameManager.instance.ChangeScene("EndingScene");
        //}
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Step = 2;
            FadePlane.SetActive(true);
        }

    }
}
