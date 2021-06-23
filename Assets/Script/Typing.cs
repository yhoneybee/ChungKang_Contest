using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Typing : MonoBehaviour
{
    public static bool AllowMove { get; set; } = true;

    public Text text = null;
    public TMP_Text tmp_text = null;

    public GameObject icon;
    public TMP_Text Name = null;

    [Header("타이핑이 끝나면 켜져야 하는 Obj들")]
    public List<GameObject> objs;

    public List<List<P_Charactor.Type>> icons = new List<List<P_Charactor.Type>>
    {
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.JUPITER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
        new List<P_Charactor.Type>{ P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER, P_Charactor.Type.REAPER, P_Charactor.Type.STRIKER, P_Charactor.Type.COUNTER, P_Charactor.Type.JUPITER},
    };

    public List<List<string>> scripts = new List<List<string>>
    {
        new List<string>{"방향키로 이동과 점프를 할 수 있습니다.","절벽에서 가까스로 점프키를 누르면 위로 한번 더 점프를 합니다.","V키를 누르고 방향키를 사용해 캐릭터를 체인지 할 수 있습니다.","캐릭터들의 이름은 핑크색-카운터 / 하늘색 - 스트라이커 / 연두색 - 리퍼 / 주황색 - 주피터 입니다","스킬을 사용하여 적 캐릭터를 공격할 수 있습니다.","캐릭터에 따라서 스킬이 바뀝니다. 잘 응용해보세요."  },//스테이지 1-1 
        new List<string>{"주피터의 스킬로 바위를 부술 수 있습니다.","레이저를 잘 구분하세요. 초록색은 닿아도 되지만 주황색은 피해를 입습니다." },// 스테이지 1-2
        new List<string>{"보스몬스터는 다른 몬스터와는 달리 특수한 패턴과 많은 체력을 자랑합니다. ","보스몬스터를 물리쳐보세요." },//1스테이지 보스스테이지
        new List<string>{"바위에 깔리면 압사당합니다. 조심해서 나아가세요" },//스테이지 2-1
        new List<string>{"뜨거운 바위블럭에 닿으면 느려집니다.","카운터의 스킬로 바위를 부술 수 있습니다.","아래에는 무언가 위협적인게 지나다니고 있습니다."},//스테이지 2-2
        new List<string>{"다른 형태의 보스몬스터입니다.","스킬 패턴또한 보스마다 다르니 유의하세요." },//2스테이지 보스스테이지
        new List<string>{"이곳은 떠다니는 얼음이 많습니다.","맞으면 아프지만 스트라이커의 스킬로 부술 수 있습니다.","미끄러지는 얼음 또한 부술 수 있습니다"},//스테이지 3-1
        new List<string>{"파랗게 질린 얼음은 밟으면 떨어집니다.","조심하세요" },//스테이지 3-2
        new List<string>{},//3스테이지 보스스테이지
        new List<string>{"넝쿨들은 리퍼의 공격으로 제거가 가능합니다"},//스테이지 4-1
        new List<string>{"이곳의 레이저는 모두 대미지를 줍니다.","레이저를 없애는 방법을 찾아보세요."},//스테이지 4-2
        new List<string>{},//4스테이지 보스스테이지
        new List<string>{"공허블럭은 모든 캐릭터가 부술 수 있습니다.","공허블럭에 닿아있다면 공격을 하지 못합니다."},//스테이지 5-1
        new List<string>{"곧 여정이 끝나갑니다.","이제 이 대서사에 종지부를 찍으십시오."},//스테이지 5-2
        new List<string>{},//5스테이지 보스스테이지
    };

    public enum ScriptType
    {
        STAGE_1_1,
        STAGE_1_2,
        STAGE_1_FINAL,
        STAGE_2_1,
        STAGE_2_2,
        STAGE_2_FINAL,
        STAGE_3_1,
        STAGE_3_2,
        STAGE_3_FINAL,
        STAGE_4_1,
        STAGE_4_2,
        STAGE_4_FINAL,
        STAGE_5_1,
        STAGE_5_2,
        STAGE_5_FINAL,
    }

    public ScriptType st;

    float delay = 0.1f;
    bool isTyping = false;

    private void Start()
    {
        TypingStart();
    }

    private void Update()
    {
    }

    int index = -1;

    public void TypingStart()
    {
        if (!isTyping)
        {
            isTyping = true;
            AllowMove = false;
            delay = 0.1f;
            StartCoroutine(CTypingStart());
        }
        else
        {
            delay = 0.001f;
        }
    }

    IEnumerator CTypingStart()
    {
        ++index;
        if (scripts[Convert.ToInt32(st)].Count == index)
        {
            transform.GetChild(0).gameObject.SetActive(false);

            yield return new WaitForSeconds(0.5f);

            foreach (var obj in objs)
                obj.SetActive(true);

            AllowMove = true;

            Destroy(gameObject);
            yield break;
        }

        int st_toint = Convert.ToInt32(st);


        for (int i = 0; i <= scripts[st_toint][index].Length; i++)
        {
            icon.GetComponent<Image>().sprite = Resources.Load<Sprite>($"Sprite/Chat_{icons[st_toint][index]}");
            Name.text = $"{icons[st_toint][index]}";
            if (text)
                text.text = scripts[st_toint][index].Substring(0, i);
            if (tmp_text)
                tmp_text.text = scripts[st_toint][index].Substring(0, i);

            yield return new WaitForSeconds(delay);
        }

        isTyping = false;

        yield return null;
    }
}
