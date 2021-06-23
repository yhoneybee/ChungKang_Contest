using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock_Obj : MonoBehaviour
{
    // Start is called before the first frame update
    private float Rotation = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotation += Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, Rotation);
    }
}
