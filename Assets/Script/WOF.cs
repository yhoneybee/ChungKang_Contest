using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WOF : MonoBehaviour
{
    public bool go_left = true;
    public float speed = 3;

    private void Update()
    {
        if (go_left)
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        else
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
