using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back_Ground_Down : MonoBehaviour
{
    //배경배열
    public GameObject[] BackGrounds;
    //의자오브젝트
    public GameObject BackChairs;


    public Sprite[] Infinite_Back;
    public SpriteRenderer[] Infinite_Ground;

    public GameObject Stage1_Spider;
    public GameObject Stage5_Devil;
    Vector3 Move_Speed = new Vector3(0.075f, 0f, 0f);
    Vector3 Flip_Image = new Vector3(1f, 1f, 1f);
    Vector3 Flop_Image = new Vector3(-1f, 1f, 1f);
    bool Dir;

    public bool On_Change;
    float Next_Chair;
    float Chair_pos;

    float Chair_time;
    float Next_Chair_time;
    float End_Chair_time;

    void Start()
    {
        if(PlayerPrefs.GetInt("Infinite")==1)
        {
            Infinite_Ground[0].sprite = Infinite_Back[0];
            Infinite_Ground[1].sprite = Infinite_Back[1];
            Stage1_Spider.SetActive(false);
            Stage5_Devil.SetActive(true);
        }
        else
        {
            On_Change = false;
            Next_Chair = 12.8f;
            Chair_pos = 0f;
            Next_Chair_time = 0.75f;
            End_Chair_time = 1.5f;
        }
    }

    void Update()
    {
        Devil_Move();

        if (Chair_time >= End_Chair_time)
        {
            Chair_time = 0;
            On_Change = false;
        }

        //의자 체인지
        if(On_Change ==true)
        {
            Chair_time += Time.deltaTime;
            if(Chair_time>=Next_Chair_time)
            {
                BackChairs.transform.position = Vector3.Lerp(BackChairs.transform.position, new Vector3(Chair_pos, BackChairs.transform.position.y, BackChairs.transform.position.z), 0.2f);
            }
        }
        
    }

    //레이어변환으로 충돌변환
    public void Get_Down(int _Stage_Num)
    {
        BackGrounds[_Stage_Num].layer = 8;

        Sfx_Mgr.SfxSetting.Get_Next_Sfx();
        On_Change = true;
        Chair_pos -= Next_Chair;
    }


    void Devil_Move()
    {
        if(Stage5_Devil.activeSelf==true)
        {
            if (Dir == false)
            {
                Stage5_Devil.transform.localScale = Flop_Image;
                Stage5_Devil.transform.position += Move_Speed;
            }
            else
            {
                Stage5_Devil.transform.localScale = Flip_Image;
                Stage5_Devil.transform.position -= Move_Speed;
            }

            if (Stage5_Devil.transform.position.x <= -4f || Stage5_Devil.transform.position.x >= 4f)
            {
                Dir = !Dir;
            }
        }
    }
}
