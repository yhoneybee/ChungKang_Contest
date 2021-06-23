using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eff_Manager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] Effs;

    private GameObject Bomb_Eff;
    private GameObject CurEff; 

    public static Eff_Manager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Eff_Set(Vector3 pos, float Eff_Size, string Tipe)
    {
        
        switch(Tipe)
        {
            case "Yellow":
                Bomb_Eff = Instantiate(Effs[0], pos, Quaternion.identity);
                Bomb_Eff.transform.localScale = new Vector3(Eff_Size, Eff_Size, Eff_Size);
                break;
            case "Pink":
                Bomb_Eff = Instantiate(Effs[1], pos, Quaternion.identity);
                Bomb_Eff.transform.localScale = new Vector3(Eff_Size, Eff_Size, Eff_Size);
                break;
            case "Blue":
                Bomb_Eff = Instantiate(Effs[2], pos, Quaternion.identity);
                Bomb_Eff.transform.localScale = new Vector3(Eff_Size, Eff_Size, Eff_Size);
                break;
            case "Purple":
                Bomb_Eff = Instantiate(Effs[3], pos, Quaternion.identity);
                Bomb_Eff.transform.localScale = new Vector3(Eff_Size, Eff_Size, Eff_Size);
                break;
            case "Green":
                Bomb_Eff = Instantiate(Effs[4], pos, Quaternion.identity);
                Bomb_Eff.transform.localScale = new Vector3(Eff_Size, Eff_Size, Eff_Size);
                break;
        }
    }

}
