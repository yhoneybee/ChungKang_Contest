using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPsRotate : MonoBehaviour
{
    ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (ps)
        {
            ParticleSystem.MainModule main = ps.main;

            if (main.startRotation.mode == ParticleSystemCurveMode.Constant)
            {
                main.startRotation = -transform.parent.eulerAngles.z * Mathf.Deg2Rad;
            }
        }
    }
}
