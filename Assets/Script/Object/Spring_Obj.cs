using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spring_Obj : MonoBehaviour
{
    PhysicsMaterial2D physicsMaterial2D;

    public float SpringForce;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        physicsMaterial2D = GetComponent<BoxCollider2D>().sharedMaterial;
        animator = transform.parent.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            P_Charactor p_Charactor;
            p_Charactor = collision.gameObject.GetComponent<P_Charactor>();
            p_Charactor.GetComponent<Rigidbody2D>().AddForce(Vector2.up * SpringForce);
            //Debug.Log(collision.gameObject.GetComponent<P_Charactor>().info.move.isJump);
            animator.SetTrigger("IsSpring");
        }
    }
}
