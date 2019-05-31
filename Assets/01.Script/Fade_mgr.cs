using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Fade_mgr : MonoBehaviour
{
    public GameObject Fade;

    public Image fade_image;

    float fades_In;
    float fades_Out;
    float fade_Speed;
    float time;

    bool Fade_In_Start = false;
    bool Fade_Out_Start = false;

    private void Awake()
    {
        fades_In = 1.00f;
        fades_Out = 0f;
        time = 0.00f;
        fade_Speed = 0.01f;
        
    }
	
	void Update ()
    {
        time += Time.deltaTime;
        if(Fade_In_Start==true)
        {
            Fade_In();
        }
        else if(Fade_Out_Start==true)
        {
            Fade_Out();
        }

    }
    //페이드인 호출함수
    public void Fade_In_Btn()
    {
        //Fade.SetActive(true);
        Fade_In_Start = true;
    }

    //페이드아웃 호출함수
    public void Fade_Out_Btn()
    {
        Fade.SetActive(true);
        Fade_Out_Start = true;
    }

    //페이드인 함수 (밝게)
    void Fade_In()
    {
        time += Time.deltaTime;

        if (fades_In > 0.00f && time >= 0.02f)
        {
            fades_In -= fade_Speed;
            fade_image.color = new Color(fade_image.color.r, fade_image.color.g, fade_image.color.b, fades_In);
            time = 0.00f;
        }
        else if (fades_In <= 0.00f)
        {
            time = 0f;
            Fade_In_Start = false;
            Fade.SetActive(false);
        }
    }


    //페이드아웃 함수 (어둡게)
    void Fade_Out()
    {
        time += Time.deltaTime;

        if (fades_Out < 1.00f && time >= 0.02f)
        {
            fades_Out += fade_Speed;
            fade_image.color = new Color(fade_image.color.r, fade_image.color.g, fade_image.color.b, fades_Out);
            time = 0.00f;
        }
        else if(fades_Out >= 1.00f)
        {
            time = 0f;
            Fade_Out_Start = false;

            SceneManager.LoadScene("Ending");
        }
    }
}
