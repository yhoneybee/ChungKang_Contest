using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class P_Enemy : MonoBehaviour
{
    [Header("[ 적의 체력 ]")]
    [Range(0, 9999)]
    public int hp;
    [Header("[ 적의 최대 체력 ]")]
    [Space(20)]
    [Range(0, 9999)]
    public int max_hp;
    [Header("[ 적의 공격력 ]")]
    [Space(20)]
    [Range(0, 9999)]
    public int damage;

    SpriteRenderer sr;
    Rigidbody2D rb2D;
    public bool IsThrowing { get; set; } = false;

    private GameObject target;
    public bool Freeze_all { get; set; } = false;

    public bool hasHpbar = false;

    public delegate void VoidCallBack();
    public event VoidCallBack take_damage;

    public GameObject Hp_Item;

    public bool isDamagedAble = true;
    public bool isGradedAble = true;

    public Hpbar hpbar;

    gocomegocome Gocomegocome;

    private int Enemy_BackUpSpeed;

    public AudioClip Hit_Sound;

    public string Eff_Name;
    private void Start()
    {
        take_damage += () => { };

        sr = GetComponent<SpriteRenderer>();
        rb2D = GetComponent<Rigidbody2D>();
        Gocomegocome = GetComponent<gocomegocome>();
        if (Gocomegocome)
            Enemy_BackUpSpeed = Gocomegocome.speed;

        if (hasHpbar)
        {
            hpbar = Instantiate(Resources.Load<Hpbar>("HpEffect"), transform.position + new Vector3(0, 1), Quaternion.identity);
            hpbar.transform.position = new Vector3(hpbar.transform.position.x, hpbar.transform.position.y);
            hpbar.Owner = this;
            hpbar.name = name + " hpbar";
            hpbar.transform.SetParent(GameObject.Find("Canvas").transform);
            hpbar.transform.localScale = Vector3.one;
        }
    }
    public void Update()
    {
        if (hp > max_hp)
            hp = max_hp;

        if (hp <= 0)
        {
            int r = Random.Range(0, 100);

            if (r == 0)
            {
                Instantiate(Hp_Item, transform.position, Quaternion.identity);
            }

            Destroy(gameObject);
        }

        if (hasHpbar)
        {
            if (hp == max_hp)
            {
                hpbar.gameObject.SetActive(false);
            }
            else
            {
                hpbar.gameObject.SetActive(true);
            }
        }
    }
    public void LateUpdate()
    {
        Debug.DrawRay(transform.position, Vector3.down * 2, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, Vector3.down, 2, LayerMask.GetMask("Platform")/*, LayerMask.GetMask("TileMap")*/);

        if (rayHit.collider != null)
        {
            if (Freeze_all)
            {
                Freeze_all = false;
                GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                GetComponent<Enemy_Move>().enabled = true;
                IsThrowing = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.GetComponent<P_Skill>())
        {
            if (isDamagedAble)
            {
                take_damage();
                hp -= col.gameObject.GetComponent<P_Skill>().damage;

                if (Sound_Manager.instance)
                    Sound_Manager.instance.SFXPlay("Hit_Sound", Hit_Sound);

                if (col.CompareTag("Attack")) //카운터
                {
                    if (Eff_Manager.instance)
                        Eff_Manager.instance.Eff_Set(transform.position, 1f, Eff_Name);
                    gameObject.tag = "Ground";
                    gameObject.layer = 8;
                    sr.material.color = new Color(0.3f, 0.3f, 0.3f);
                    rb2D.bodyType = RigidbodyType2D.Kinematic;
                    if (Gocomegocome)
                        Gocomegocome.speed = 0;
                    Invoke(nameof(MonsterIdle), 4f);
                }

                if (col.CompareTag("Attack2") || col.CompareTag("Attack3"))
                {
                    Debug.Log("기모티콘");
                    if (Eff_Manager.instance)
                        Eff_Manager.instance.Eff_Set(transform.position, 1f, Eff_Name);
                    if (col.gameObject.GetComponent<SpriteRenderer>().flipX == true)
                        gameObject.transform.rotation = Quaternion.Euler(0, 0, 15f);
                    if (col.gameObject.GetComponent<SpriteRenderer>().flipX == false)
                        gameObject.transform.rotation = Quaternion.Euler(0, 0, -15f);

                    sr.material.color = new Color(1f, 0f, 0f);
                    Invoke("Rotate_Change_After", 0.2f);

                }
            }
        }
    }

    public void Rotate_Change_After() //나머지 캐릭터
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        sr.material.color = new Color(1f, 1f, 1f);
    }
    public void MonsterIdle() //카운터
    {
        gameObject.tag = "unfriendly";
        gameObject.layer = 9;
        sr.material.color = new Color(1f, 1f, 1f);
        rb2D.bodyType = RigidbodyType2D.Dynamic;
        Gocomegocome.speed = Enemy_BackUpSpeed;
    }
}
