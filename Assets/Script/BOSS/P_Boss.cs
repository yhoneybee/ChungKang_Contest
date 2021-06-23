using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class P_Boss : MonoBehaviour
{
    public AudioClip patern1;
    public AudioClip patern2;
    public AudioClip patern3;
    public enum Day
    {
        MONDAY,
        TUESDAY,
        WEDNESDAY,
        THURSDAY,
        FRIDAY,
    }

    public Day day;

    bool isLockon = false;

    Vector2 dir;

    GameObject child;
    IEnumerator EDestroy(float time, GameObject obj)
    {
        yield return new WaitForSeconds(time);
        Destroy(obj);
        yield return null;
    }

    IEnumerator ESwitch()
    {
        while (day == Day.MONDAY)
        {
            yield return new WaitForSeconds(10);
            isLockon = !isLockon;

            child.GetComponent<Animator>().SetBool("isMove", !isLockon);

            if (isLockon)
            {
                child.transform.rotation = Quaternion.identity;
                dir = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                dir = dir.normalized;
                child.transform.localPosition = Vector3.zero;
                transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 11.327663f, 0);
            }
        }
        yield return null;
    }

    private void Start()
    {
        switch (day)
        {
            case Day.MONDAY:
                child = GetComponentInChildren<SpriteRenderer>().gameObject;
                dir = new Vector2(Random.Range(-10, 10), Random.Range(-10, 10));
                dir = dir.normalized;
                StartCoroutine(ESwitch());
                break;
            case Day.TUESDAY:
                break;
            case Day.WEDNESDAY:
                break;
            case Day.THURSDAY:
                break;
            case Day.FRIDAY:
                break;
        }

        StartCoroutine(CUpdate());
    }

    IEnumerator CUpdate()
    {
        while (true)
        {
            int pattern_case = Random.Range(0, 3);

            yield return new WaitForSeconds(3);

            switch (day)
            {
                case Day.MONDAY:
                    if (isLockon)
                    {
                        transform.position = Vector3.Lerp(transform.position, new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 11.327663f, 0), Time.deltaTime * 0.1f);
                        switch (pattern_case)
                        {
                            case 0:
                                ChainSpear(5, 1);
                                yield return new WaitForSeconds(5);
                                break;
                            case 1:
                                Aim_And_Shoot();
                                yield return new WaitForSeconds(5);
                                break;
                            case 2:
                                StartCoroutine(EFalling());
                                yield return new WaitForSeconds(6);
                                break;
                        }
                    }
                    break;
                case Day.TUESDAY:
                    switch (pattern_case)
                    {
                        case 0:
                            GetComponent<Animator>().SetBool("isMove", false);

                            GetComponent<Animator>().SetTrigger("isAbove");
                            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
                            GetComponent<BoxCollider2D>().enabled = false;
                            yield return new WaitForSeconds(1);
                            LegAttack();
                            yield return new WaitForSeconds(10);
                            GetComponent<Animator>().SetTrigger("isBelow");
                            GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation | RigidbodyConstraints2D.FreezePositionX;
                            GetComponent<BoxCollider2D>().enabled = true;
                            break;
                        case 1:
                            break;
                            GetComponent<Animator>().SetBool("isMove", false);

                            GetComponent<Animator>().SetTrigger("Sushi");
                            yield return new WaitForSeconds(1);
                            RotatingSushi();
                            yield return new WaitForSeconds(24);
                            break;
                        case 2:
                            GetComponent<Animator>().SetBool("isMove", true);

                            dir = new Vector2((Random.Range(0, 2) == 0 ? -1 : 1), 0);
                            yield return new WaitForSeconds(5);
                            break;
                    }
                    break;
                case Day.WEDNESDAY:
                    switch (pattern_case)
                    {
                        case 0:
                            GetComponent<Animator>().SetBool("isMove", false);

                            GetComponent<Animator>().SetTrigger("Dokdo");
                            yield return new WaitForSeconds(1);
                            HandUp();
                            yield return new WaitForSeconds(3);
                            break;
                        case 1:
                            GetComponent<Animator>().SetBool("isMove", false);

                            StartCoroutine(EFalling(false));
                            yield return new WaitForSeconds(6);
                            break;
                        case 2:
                            GetComponent<Animator>().SetBool("isMove", true);

                            dir = new Vector2((Random.Range(0, 2) == 0 ? -1 : 1), 0);
                            yield return new WaitForSeconds(5);
                            break;
                    }
                    break;
                case Day.THURSDAY:
                    if (!isLockon)
                        transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(0.90f, 0)).x, GameObject.FindWithTag("Player").transform.position.y + 4);
                    switch (pattern_case)
                    {
                        case 0:
                            HandDown();
                            yield return new WaitForSeconds(3);
                            break;
                        case 1:
                            StartCoroutine(ERocketPunch());
                            yield return new WaitForSeconds(10);
                            break;
                    }
                    break;
                case Day.FRIDAY:
                    switch (pattern_case)
                    {
                        case 0:
                            StartCoroutine(EShootPattern(Random.Range(1, 5)));
                            yield return new WaitForSeconds(2);
                            break;
                        case 1:
                            StartCoroutine(CSummon());
                            yield return new WaitForSeconds(1);
                            break;
                    }
                    break;
            }

            yield return null;
        }
    }

    private void Update()
    {
        switch (day)
        {
            case Day.MONDAY:
                {
                    if (!isLockon)
                    {
                        Destroy(GameObject.Find("Lazer"));
                        Destroy(GameObject.Find("Aiming"));
                        child.transform.Rotate(new Vector3(0, 0, -1));
                        transform.Translate(dir * 20 * Time.deltaTime);
                        Vector2 v2 = Camera.main.WorldToViewportPoint(child.transform.position);
                        if (v2.x > 1)
                            dir = Vector3.left;
                        else if (v2.x > 0.95f)
                        {
                            transform.Translate(Vector3.left * 0.3f);
                            dir = Vector3.Reflect(dir, Vector3.right);
                        }

                        if (v2.y > 1)
                            dir = Vector3.down;
                        else if (v2.y > 0.95f)
                        {
                            transform.Translate(Vector3.down * 0.3f);
                            dir = Vector3.Reflect(dir, Vector3.up);
                        }

                        if (v2.x < 0)
                            dir = Vector3.right;
                        else if (v2.x < 0.05f)
                        {
                            transform.Translate(Vector3.right * 0.3f);
                            dir = Vector3.Reflect(dir, Vector3.left);
                        }

                        if (v2.y < 0)
                            dir = Vector3.up;
                        else if (v2.y < 0.05f)
                        {
                            transform.Translate(Vector3.up * 0.3f);
                            dir = Vector3.Reflect(dir, Vector3.down);
                        }
                    }
                }
                break;
            case Day.TUESDAY:
            case Day.WEDNESDAY:
                {
                    Vector2 v2 = Camera.main.WorldToViewportPoint(transform.position);

                    SpriteRenderer sr = GetComponent<SpriteRenderer>();

                    if (1 - v2.x < 0.1f)
                    {
                        dir = Vector3.left;
                    }
                    if (1 - v2.x > 0.9f)
                    {
                        dir = Vector3.right;
                    }

                    if (dir.x > 0)
                        sr.flipX = true;
                    else
                        sr.flipX = false;

                    if (GetComponent<Animator>().GetBool("isMove"))
                        transform.Translate(dir * 5 * Time.deltaTime);
                    /*                    else if (v2.x > 0.9f)
                                        {
                                            transform.Translate(Vector3.left * 0.3f);
                                        }*/


                    /*                    else if (v2.x < 0.1f)
                                        {
                                            transform.Translate(Vector3.right * 0.3f);
                                        }*/
                }
                break;
            case Day.THURSDAY:
                break;
            case Day.FRIDAY:
                break;
            default:
                break;
        }
    }

    #region MONDAY_BOSS_CODE

    public void Aim_And_Shoot()
    {
        GameObject aiming = Instantiate(Resources.Load<GameObject>("Aiming"));
        aiming.name = "Aiming";
        aiming.GetComponent<TargetAiming>().Aiming_End += On_Aim_End;
    }

    IEnumerator EOn_Aim_End()
    {
        Sound_Manager.instance.SFXPlay("RocketPunch", patern1);
        Destroy(GameObject.Find("Aiming"));
        yield return new WaitForSeconds(0.5f);
        GameObject obj = Instantiate(Resources.Load<GameObject>("Lazer"));
        obj.name = "Lazer";
        obj.transform.SetParent(GameObject.Find("LazerStart").transform);
        obj.transform.localPosition = new Vector3(0, 0, -10);
        obj.transform.localRotation = Quaternion.Euler(0, 0, 90);
        obj.transform.localScale = new Vector3(7, 10, 1);
        StartCoroutine(EDestroy(5, GameObject.Find("Lazer")));
        yield return null;
    }

    private void On_Aim_End()
    {
        StartCoroutine(EOn_Aim_End());
        return;
    }

    IEnumerator EFalling(bool isMonday = true)
    {
        Sprite sprite;

        sprite = Resources.Load<Sprite>("Sprite/fall_monday");

        GetComponent<Animator>().SetTrigger("Fall");

        for (int i = 0; i < 20; i++)
        {
            int rand;
            if (!isMonday)
            {
                Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
                rand = Random.Range(1, 10);
                sprite = Resources.Load<Sprite>($"Sprite/ice{rand}");
            }
            else
            {
                Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
                rand = Random.Range(1, 6);
                sprite = Resources.Load<Sprite>($"Sprite/fall{rand}");
            }

            Vector3 v3 = Camera.main.ViewportToWorldPoint(Vector3.up);
            GameObject obj = Instantiate(Resources.Load<GameObject>("Fall"), new Vector3(Camera.main.ViewportToWorldPoint(new Vector3(Random.Range(0f, 1f), 0)).x, v3.y + 2, 0), Quaternion.identity);

            //Material temp = Resources.Load<Material>("Material/Fall");

            //if (!isMonday)
            //    temp.mainTexture = Resources.Load<Texture>($"Sprite/ice{rand}");
            //else
            //    temp.mainTexture = Resources.Load<Texture>($"Sprite/fall{rand}");

            //obj.transform.GetChild(0).GetComponent<ParticleSystemRenderer>().material = temp;

            if (!isMonday)
                obj.transform.localScale = Vector3.one * Random.Range(1f, 2f);
            else
                obj.transform.localScale = Vector3.one;

            obj.GetComponent<SpriteRenderer>().sprite = sprite;

            obj.name = "Fall";
            yield return new WaitForSeconds(0.3f);
        }

        yield return null;
    }

    IEnumerator EChainSpear(int count)
    {
        GameObject player;
        GameObject chain;
        Vector3 dir;
        float angle;
        for (int i = 0; i < count; i++)
        {
            player = GameObject.FindWithTag("Player");
            chain = Instantiate(Resources.Load<GameObject>("Chain"),
                new Vector3(Random.Range(player.transform.position.x - 30, player.transform.position.x + 30), 30),
                Quaternion.identity);
            chain.name = "Chain";
            dir = player.transform.position;
            dir -= chain.transform.position;
            angle = Mathf.Atan2(dir.normalized.y, dir.normalized.x) * Mathf.Rad2Deg;
            chain.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            yield return new WaitForSeconds(1);
        }
        yield return null;
    }

    public void ChainSpear(int count, int sync_count)
    {
        for (int i = 0; i < sync_count; i++)
            StartCoroutine(EChainSpear(count));
    }
    #endregion

    #region TUESDAY_BOSS_CODE
    public void LegAttack() // 9 sec
    {
        Sound_Manager.instance.SFXPlay("RocketPunch", patern1);
        Instantiate(Resources.Load<GameObject>("Cage"), new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y), Quaternion.identity);
    }

    public void RotatingSushi() // 24 sec
    {
        Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
        Instantiate(Resources.Load<GameObject>("Rotating_Sushi"),
            new Vector3(Camera.main.transform.position.x, GameObject.FindWithTag("Player").transform.position.y + 15.14272f - 5),
            Quaternion.identity);
    }
    #endregion

    #region WEDNESDAY_BOSS_CODE

    public void HandUp()
    {
        
        Instantiate(Resources.Load<GameObject>("HAND"),
            new Vector3(0, 0, 0),
            Quaternion.identity).GetComponent<Hand>().isUp = true;
    }

    #endregion

    #region THURSDAY_BOSS_CODE

    public void HandDown()
    {
        GetComponent<Animator>().SetTrigger("Pattern1");
        Instantiate(Resources.Load<GameObject>("HAND"),
            new Vector3(0, 0, 0),
            Quaternion.identity).GetComponent<Hand>().isUp = false;
    }

    IEnumerator ERocketPunch()
    {
        isLockon = true;

        BulletMove bm;

        List<int> type = new List<int>
        {
            1,0,1,0,0,1,0,0,1,0
        };

        for (int i = 0; i < 10; i++)
        {
            GetComponent<Animator>().SetTrigger("Pattern2");
            switch (type[i])
            {
                case 0:
                    Sound_Manager.instance.SFXPlay("RocketPunch", patern1);
                    bm = Instantiate(Resources.Load<BulletMove>("RocketPunch"), transform.position + new Vector3(0, 1), Quaternion.identity);
                    Sound_Manager.instance.SFXPlay("RocketPunch", patern1);
                    Vector3 temp = GameObject.FindWithTag("Player").transform.position - transform.position;
                    if (temp.x > 0)
                        bm.Dir = new Vector2(1.5f, 0);
                    else
                        bm.Dir = new Vector2(-1.5f, 0);

                    break;
                case 1:
                    Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
                    bm = Instantiate(Resources.Load<BulletMove>("RocketPunch"), transform.position + new Vector3(0, -3), Quaternion.identity);
                    Sound_Manager.instance.SFXPlay("patern2", patern2);
                    temp = GameObject.FindWithTag("Player").transform.position - transform.position;
                    if (temp.x > 0)
                        bm.Dir = new Vector2(1.5f, 0);
                    else
                        bm.Dir = new Vector2(-1.5f, 0);

                    break;
            }
            yield return new WaitForSeconds(1);
        }

        isLockon = false;

        yield return null;
    }

    #endregion

    #region FRIDAY_BOSS_CODE

    IEnumerator EShootPattern(int type)
    {
        GameObject origin = Resources.Load<GameObject>("Friday_Rocket");
        GameObject temp;
        List<GameObject> objs = new List<GameObject>();

        GetComponent<Animator>().SetTrigger("isVariations");

        switch (type)
        {
            case 1:
                for (int i = 0; i < 5; i++)
                {
                    Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
                    temp = Instantiate(origin, transform.position + new Vector3(7 * (i == 0 ? -1 : i == 1 ? 1 : i == 2 ? -1 : i == 3 ? 1 : 0), 7 * (i == 0 ? 1 : i == 1 ? 1 : i == 2 ? -1 : i == 3 ? -1 : 0)), Quaternion.Euler(0, 0, 45 * i));
                    temp.AddComponent<Tracking>().delay = 5;
                }
                break;
            case 2:
                for (int i = 0; i < 4; i++)
                {
                    Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
                    temp = Instantiate(origin, transform.position + new Vector3(), Quaternion.Euler(0, 0, (45 / 2) * i + 67.5f - (22.5f / 2)));
                    BulletMove bm = temp.AddComponent<BulletMove>();
                    bm.Dir = Vector3.up;
                    bm.BulletSpeed = 30;
                    bm.isFriend = false;
                }
                break;
            case 3:
                objs.Clear();
                for (int i = 0; i < 3; i++)
                {
                    Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
                    temp = Instantiate(origin, transform.position + new Vector3(), Quaternion.Euler(0, 0, (45 / 2) * i + 67.5f));
                    objs.Add(temp);
                    BulletMove bm = temp.AddComponent<BulletMove>();
                    bm.Dir = Vector3.up;
                    bm.BulletSpeed = 30;
                    bm.isFriend = false;
                }

                yield return new WaitForSeconds(1.5f);

                foreach (var obj in objs)
                {
                    Destroy(obj.GetComponent<BulletMove>());
                    Destroy(obj.GetComponent<Destroy>());
                    obj.AddComponent<Destroy>().time = 3;
                    obj.AddComponent<Tracking>().delay = 5;
                }
                break;
            case 4:
                for (int i = 0; i < 36; i++)
                {
                    Sound_Manager.instance.SFXPlay("RocketPunch", patern2);
                    temp = Instantiate(origin, transform.position + new Vector3(), Quaternion.Euler(0, 0, 10 * i));
                    BulletMove bm = temp.AddComponent<BulletMove>();
                    bm.Dir = Vector3.up;
                    bm.BulletSpeed = 30;
                    bm.isFriend = false;
                    yield return new WaitForSeconds(0.1f);
                }
                break;
        }


        yield return null;
    }

    IEnumerator CSummon()
    {
        GameObject player = GameObject.FindWithTag("Player");
        GetComponent<Animator>().SetTrigger("isStay");
        switch (Random.Range(0, 2))
        {
            case 0:
                for (int i = 0; i < 2; i++)
                    Sound_Manager.instance.SFXPlay("UFO", patern1);
                Instantiate(Resources.Load<GameObject>("UFO"), player.transform.position + new Vector3(Random.Range(-10, 10), 5, 0), Quaternion.identity);
                break;
            case 1:
                Sound_Manager.instance.SFXPlay("WHIP", patern2);
                Instantiate(Resources.Load<GameObject>("Whip"), player.transform.position + new Vector3(-20, 5, 0), Quaternion.identity);
                Instantiate(Resources.Load<GameObject>("Whip"), player.transform.position + new Vector3(20, 5, 0), Quaternion.identity);
                break;
        }
        yield return null;
    }

    #endregion
}
