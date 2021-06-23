using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFO : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(CAttack());
    }

    IEnumerator CAttack()
    {
        for (int i = 0; i < 2; i++)
        {
            transform.GetChild(0).gameObject.SetActive(false);
            yield return new WaitForSeconds(2);
            transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("Attack");
            yield return new WaitForSeconds(1);
            transform.GetChild(0).gameObject.SetActive(false);
        }
        Destroy(gameObject);
    }
}
