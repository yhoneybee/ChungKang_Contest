using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_SceneManager : MonoBehaviour
{
    public GameObject Boss;

    public GameObject Boss_Ins;
    private bool IsBoss_Die;

    public static bool Is_Boss_Die_On;
    public int Boss_Scene = 0;
    // Start is called before the first frame update
    void Start()
    {
        IsBoss_Die = false;
        Is_Boss_Die_On = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Fade_InOut.count == 6 && !Boss_Ins)
        {
            if (Boss.name == "FRIDAY_BOSS")
                Boss_Ins = Instantiate(Boss, new Vector3(0, -6, 90), Quaternion.identity);
            else
                Boss_Ins = Instantiate(Boss, new Vector3(0, 6.7f, 90), Quaternion.identity);
            Boss_Ins.name = Boss.name;
            if (Boss_Ins.name == "MONDAY_BOSS")
            {
                Boss_Ins = Boss_Ins.transform.GetChild(1).gameObject;
            }
        }

        //if(!Is_Boss_Die_On) return;

        if (!Boss_Ins && Fade_InOut.count > 6)
        {
            Debug.Log("시발" + StageClear.Stage);
            switch (StageClear.Stage)
            {
                case 13:
                    SceneManager.LoadScene("StageSel");
                    StageManager.Dw_Control++;
                    StageManager.Stage_Control++;
                    GameManager.hp = GameManager.maxHp;
                    StageClear.Stage = 2;
                    Fade_InOut.count = 0;
                    break;
                case 23:
                    SceneManager.LoadScene("StageSel");
                    StageClear.Stage = 3;
                    StageManager.Dw_Control++;
                    StageManager.Stage_Control++;
                    GameManager.hp = GameManager.maxHp;
                    Fade_InOut.count = 0;
                    break;
                case 33:
                    SceneManager.LoadScene("StageSel");
                    StageClear.Stage = 4;
                    StageManager.Dw_Control++;
                    StageManager.Stage_Control++;
                    GameManager.hp = GameManager.maxHp;
                    Fade_InOut.count = 0;
                    break;
                case 43:
                    SceneManager.LoadScene("StageSel");
                    StageClear.Stage = 5;
                    StageManager.Dw_Control++;
                    StageManager.Stage_Control++;
                    GameManager.hp = GameManager.maxHp;
                    Fade_InOut.count = 0;
                    break;
                case 53:
                    SceneManager.LoadScene("EndingScene");
                    StageClear.Stage = 100;
                    StageManager.Dw_Control++;
                    StageManager.Stage_Control++;
                    GameManager.hp = GameManager.maxHp;
                    Fade_InOut.count = 0;
                    break;
            }
        }
    }
}
