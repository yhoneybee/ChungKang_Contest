using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leg : MonoBehaviour
{
    List<GameObject> childs = new List<GameObject>();
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
            childs.Add(transform.GetChild(i).gameObject);
        StartCoroutine(CPattern());
    }

    IEnumerator CPattern()
    {
        int safe;
        for (int i = 0; i < 3; i++)
        {
            safe = Random.Range(0, transform.childCount);

            foreach (var child in childs)
                child.transform.localPosition = new Vector3(child.transform.localPosition.x, 40);

            for (int k = 0; k < transform.childCount; k++)
            {
                if (k == safe) continue;
                Instantiate(Resources.Load("WARNING_LEG"), childs[k].transform.position + new Vector3(0, -40, 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(2);

            for (int j = 0; j < transform.childCount; j++)
            {
                if (j == safe) continue;
                childs[j].transform.localPosition += new Vector3(0, -40, 0);
                childs[j].gameObject.GetComponent<Animator>().SetTrigger("Attack");
            }
            yield return new WaitForSeconds(1);
        }

        foreach (var child in childs)
        {
            Destroy(child.gameObject);
        }

        yield return null;
    }
}
