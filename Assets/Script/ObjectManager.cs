using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Player;

    public GameObject Switching_Eff;
    public static int PlayerSelect;

    public static int OldPlayerSelect;

    public static Vector3 PlayerPos;

    GameObject Joo;
    void Start()
    {
        PlayerSelect = 4;
        Joo = Instantiate(Player[OldPlayerSelect], new Vector3(4.45f, 1f, 100), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerSelect)
        {
            case 0:
                Destroy(Joo);
                GameObject obj = Instantiate(Player[0], PlayerPos, Quaternion.identity);
                obj.GetComponent<P_Charactor>().info.move.isJump = Joo.GetComponent<P_Charactor>().info.move.isJump;
                obj.GetComponent<Rigidbody2D>().velocity = Joo.GetComponent<Rigidbody2D>().velocity;
                Joo = obj;
                OldPlayerSelect = PlayerSelect;
                if (Switching_Eff)
                    Instantiate(Switching_Eff, obj.transform.position + new Vector3(0, 2.2f, 0), Quaternion.identity);
                PlayerSelect = 4;
                break;
            case 1:
                Destroy(Joo);
                obj = Instantiate(Player[1], PlayerPos, Quaternion.identity);
                obj.GetComponent<P_Charactor>().info.move.isJump = Joo.GetComponent<P_Charactor>().info.move.isJump;
                obj.GetComponent<Rigidbody2D>().velocity = Joo.GetComponent<Rigidbody2D>().velocity;
                Joo = obj;
                OldPlayerSelect = PlayerSelect;
                if (Switching_Eff)
                    Instantiate(Switching_Eff, obj.transform.position + new Vector3(0, 2.2f, 0), Quaternion.identity);
                PlayerSelect = 4;
                break;
            case 2:
                Destroy(Joo);
                obj = Instantiate(Player[2], PlayerPos, Quaternion.identity);
                obj.GetComponent<P_Charactor>().info.move.isJump = Joo.GetComponent<P_Charactor>().info.move.isJump;
                obj.GetComponent<Rigidbody2D>().velocity = Joo.GetComponent<Rigidbody2D>().velocity;
                Joo = obj;
                OldPlayerSelect = PlayerSelect;
                if (Switching_Eff)
                    Instantiate(Switching_Eff, obj.transform.position + new Vector3(0, 2.2f, 0), Quaternion.identity);
                PlayerSelect = 4;
                break;
            case 3:
                Destroy(Joo);
                obj = Instantiate(Player[3], PlayerPos, Quaternion.identity);
                obj.GetComponent<P_Charactor>().info.move.isJump = Joo.GetComponent<P_Charactor>().info.move.isJump;
                obj.GetComponent<Rigidbody2D>().velocity = Joo.GetComponent<Rigidbody2D>().velocity;
                Joo = obj;
                OldPlayerSelect = PlayerSelect;
                if (Switching_Eff)
                    Instantiate(Switching_Eff, obj.transform.position + new Vector3(0, 2.2f, 0), Quaternion.identity);
                PlayerSelect = 4;
                break;
        }


    }
}