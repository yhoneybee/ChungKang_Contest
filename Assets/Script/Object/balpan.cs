using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balpan : MonoBehaviour
{
    private float CurTime = 0;
    private float MaxTime = 1;
    bool EMB =false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(EMB == true)
        CurTime += Time.deltaTime;
        if (CurTime > MaxTime) this.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //Debug.Log("보였다 빈틈의실");
            EMB = true;


        }
    }

   
}
