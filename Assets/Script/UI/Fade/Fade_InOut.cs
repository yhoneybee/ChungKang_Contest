using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade_InOut : MonoBehaviour
{
    public int prolStep = 0;

   
    float fade = 0.7f;
    public static int count = 0;
    private float CurTime;
    private float MaxTime;
    public static float TimeCheck;
    GameObject FadePlane;
    CanvasRenderer CanvasRenderer;
    CanvasRenderer ImageRenderer;
    GameObject Image;
    AudioSource AudioSource;
    void Start()
    {
        CurTime = 0;
        MaxTime = 0.5f;
        count = 0;
        FadePlane = GameObject.Find("Fade_InOut");
        CanvasRenderer = FadePlane.GetComponent<CanvasRenderer>();
        Image = GameObject.Find("Image");
        print(name);
        ImageRenderer = Image.GetComponent<CanvasRenderer>();
        fade = 0.7f;
        AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("카운트" + count);
        CurTime += Time.deltaTime;
        if (CurTime > MaxTime)
        {
            if (fade == 0)
                prolStep = 2;
            else if (fade == 0.5f)
                prolStep = 0;

            CurTime = 0;
        }
        switch (prolStep)
        {
            case 0:
                fade -= Time.deltaTime;
                if (fade <= 0)
                {                  
                    fade = 0;
                    prolStep = 4;
                    count++;
                    if (count > 6)
                    {
                        FadePlane.SetActive(false);
                        Image.SetActive(false);
                        Boss_SceneManager.Is_Boss_Die_On = true;
                    }
                }
                break;
            case 2:
                fade += Time.deltaTime;
                if (fade >= 0.5f)
                {
                    if (FadePlane.activeSelf == true)
                        Earthquake.instance.Earthquake_Set(75f, 0.5f, true);
                    fade = 0.5f;
                    prolStep = 4;
                    count++;
                }
                break;
        }
        if (count == 6)
        {
            ImageRenderer.SetAlpha(fade);
        }

        CanvasRenderer.SetAlpha(fade);
        
    }
}
