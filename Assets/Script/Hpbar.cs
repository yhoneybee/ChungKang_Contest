using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    public P_Enemy Owner;
    public Slider slider;
    public Slider effect_slider;
    public bool isBoss = false;

    bool effect = true;

    List<string> boss_name = new List<string> { "MONDAY_BOSS", "TUESDAY_BOSS", "WEDNESDAY_BOSS", "THURSDAY_BOSS", "FRIDAY_BOSS" };

    private void Start()
    {
        if (Owner)
        {
            Owner.take_damage += EffectON;
            slider.maxValue = Owner.max_hp;
            effect_slider.maxValue = Owner.max_hp;
            effect_slider.value = Owner.max_hp;
        }
    }

    void Update()
    {
        if (Owner)
        {
            slider.value = Mathf.Lerp(slider.value, Owner.hp, Time.deltaTime * 13);

            if (!isBoss)
                transform.position = Owner.transform.position + new Vector3(0, 3);
            else
            {
                Vector3 temp = Camera.main.ViewportToWorldPoint(new Vector3(0.71f, 0.88f));
                transform.position = new Vector3(temp.x, temp.y);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
            }

            if (effect)
            {
                effect_slider.value = Mathf.Lerp(effect_slider.value, slider.value, Time.deltaTime * 13);
                if (slider.value >= effect_slider.value - 0.01f)
                {
                    effect = false;
                    effect_slider.value = slider.value;
                    Debug.Log("시련");
                }
            }
        }
        else
        {
            if (!isBoss)
                Destroy(gameObject);
            else
            {
                foreach (var name in boss_name)
                {
                    if (GameObject.Find(name))
                    {
                        if (name.Equals("MONDAY_BOSS"))
                            Owner = GameObject.Find(name).transform.GetChild(1).gameObject.GetComponent<P_Enemy>();
                        else
                            Owner = GameObject.Find(name).GetComponent<P_Enemy>();
                        Owner.take_damage += EffectON;
                        slider.maxValue = Owner.max_hp;
                        slider.value = Owner.hp;
                        effect_slider.maxValue = Owner.max_hp;
                        effect_slider.value = Owner.max_hp;
                    }
                }
            }
        }
    }

    IEnumerator CEffectOn()
    {
        yield return new WaitForSeconds(0.5f);
        effect = true;
    }

    public void EffectON()
    {
        if (gameObject.activeSelf)
            StartCoroutine(CEffectOn());
    }
}
