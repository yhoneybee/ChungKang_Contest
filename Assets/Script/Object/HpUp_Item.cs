using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUp_Item : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = Vector2.zero;
        rb2d.AddForce(Vector2.up * 200);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (GameManager.hp < GameManager.maxHp)
            {
                GameManager.hp += 1;
            }
            Destroy(gameObject);
        }
    }
}
