using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    GameObject child;

    bool isUp = true;

    void Start()
    {
        child = transform.Find("enemy").gameObject;
        StartCoroutine(CPipe());
    }

    private void Update()
    {
        if (isUp)
            child.transform.localPosition = Vector3.Lerp(child.transform.localPosition, new Vector3(0, 4, 0), Time.deltaTime * 10);
        else
            child.transform.localPosition = Vector3.Lerp(child.transform.localPosition, new Vector3(0, 0, 0), Time.deltaTime * 10);
    }

    IEnumerator CPipe()
    {
        while (true)
        {
            isUp = !isUp;
            if (isUp)
            {
                child.tag = "unfriendly";
                child.layer = 9;
            }
            else
            {
                child.tag = "Ground";
                child.layer = 8;
            }

            yield return new WaitForSeconds(3);
        }
    }
}
