using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    GameObject target = null;
    [Header("보정벡터")]
    public Vector3 vec3;

    private void Update()
    {
        if (!target)
            target = GameObject.FindWithTag("Player");
        else
            transform.position = target.transform.position + vec3;
    }
}
