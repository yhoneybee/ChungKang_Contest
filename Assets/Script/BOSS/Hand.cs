using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour
{
    public bool isUp = true;

    Vector3 pos;

    private void Start()
    {
        pos = GameObject.FindWithTag("Player").transform.position + new Vector3(0, 3, 0);
        StartCoroutine(EWarning());
    }

    IEnumerator EWarning()
    {
        for (int i = 0; i < 10; i++)
        {
            Instantiate(Resources.Load<GameObject>("WARNING"), pos, Quaternion.identity);
            yield return new WaitForSeconds(0.2f);
        }
        if (isUp)
            Instantiate(Resources.Load<GameObject>("HANDUP"), pos, Quaternion.identity);
        else
            Instantiate(Resources.Load<GameObject>("HANDDOWN"), pos, Quaternion.identity);

        yield return new WaitForSeconds(5);
        Destroy(gameObject);
        yield return null;
    }
}
