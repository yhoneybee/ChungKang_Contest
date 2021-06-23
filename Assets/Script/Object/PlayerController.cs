using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
//    private bool isGrounded = false;
//     private GameObject contactPlatform;
//     private Vector3 platformPosition;
//     private Vector3 distance;
    
//    public Rigidbody2D PlayerSpeed;

    public gocomegocome Gocomegocome = null;

    public Vector3 Gocomegocome_pos = Vector3.zero;
    //private Vector3 Add_Pos;
    void Start()
    {
        
    }
    void Update() 
    {     
        if(Gocomegocome != null && Gocomegocome_pos != Gocomegocome.Now_Pos)
        {
            //transform.position = Gocomegocome.transform.position;
            transform.position += (Gocomegocome.Now_Pos - Gocomegocome.Old_Pos);
            Gocomegocome_pos = Gocomegocome.Now_Pos;
            Debug.Log("transform.position " + (Gocomegocome.Now_Pos - Gocomegocome.Old_Pos));
        }
    }

	private void OnCollisionEnter2D(Collision2D collision) {   

            if (collision.gameObject.tag == "Ground") 
            {
                Gocomegocome = collision.gameObject.GetComponent<gocomegocome>();
/*                Debug.Log("붙음");*/
            }         
        }
    
    private void OnCollisionExit2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Ground") 
        {
            Gocomegocome = null;
            Gocomegocome_pos = Vector3.zero;
           /* Debug.Log("떨어짐");*/
        }
    }
}
