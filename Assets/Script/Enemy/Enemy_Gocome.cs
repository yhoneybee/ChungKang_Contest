using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Gocome : MonoBehaviour
{
    public float Enemy_Speed;
    public int xForce = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Typing.AllowMove)
            transform.Translate((Vector2.right * Enemy_Speed) * xForce * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            if (xForce == -1)
            {
                xForce = 1;
            }
            else
            {
                xForce = -1;
            }
        }
    }
}
