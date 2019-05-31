using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cat_Mgr : MonoBehaviour
{
    //호출변수
    public Coin_Mgr Coin;
    public bool Cat_Stop;
    bool Bgm_Start;

    //노말모드 고양이 변수
    public GameObject Moving_Cat;
    public GameObject Cat_Coin;

    float Move_Time;
    float Change_Move_Time;
    bool Dir;

    Vector3 Move_Speed = new Vector3(5f, 0f, 0f);
    Vector3 Flip_Image = new Vector3(-1f, 1f, 1f);
    Vector3 Flop_Image = new Vector3(1f, 1f, 1f);


    //방해모드 고양이 변수
    public GameObject Interrupt_Cat;
    public Image Interrupt_Cat_Image;
    public Sprite[] Interrupt_Cats;

    float Cat_Coin_Time;
    float Interrupt_Time;
    float Change_Interrupt_Time;
    bool Cat_Appear;
    int Cat_Touch_Cnt;

    Vector3 Up_Speed = new Vector3(0f, 6f, 0f);
    Vector3 Down_Speed = new Vector3(0f, -6f, 0f);
    
    void Start ()
    {
        //무브고양이변수
        Dir = false;
        Move_Time = 0f;
        Change_Move_Time = Random.Range(0f, 2f);

        //방해고양이변수
        Cat_Touch_Cnt = 0;
        Interrupt_Time = 0f;
        Change_Interrupt_Time = 15f;
	}
	
	void Update ()
    {
        if (Cat_Stop==false)
        {
            Interrupt_Time += Time.deltaTime;
            Cat_Interrupt();
            if(Moving_Cat.activeSelf==true)
            {
                Move_Time += Time.deltaTime;
                Cat_Coin_Time += Time.deltaTime;
                Get_Moving_Cat_Coin();
                Cat_Move();
            }
        }
	}

    //노말모드 고양이 함수모음
    #region 노말모드 고양이

    //노말모드 고양이 움직임
    void Cat_Move()
    {
        if (Dir == false)
        {
            Moving_Cat.transform.localScale = Flop_Image;
            Moving_Cat.transform.localPosition += Move_Speed;
        }
        else
        {
            Moving_Cat.transform.localScale = Flip_Image;
            Moving_Cat.transform.localPosition -= Move_Speed;
        }

        if (Move_Time >= Change_Move_Time || Moving_Cat.transform.localPosition.x <= -400f || Moving_Cat.transform.localPosition.x >= 400f)
        {
            Dir = !Dir;

            Move_Time = 0f;
            Change_Move_Time = Random.Range(0f, 2f);
        }
    }

    //노말모드 고양이 터치 다운
    void Get_Moving_Cat_Coin()
    {
        //5번째 금화들어옴
        if(Cat_Coin_Time >= 2f)
        {
            Sfx_Mgr.SfxSetting.Get_Moving_Cat_Sfx();

            Cat_Coin.SetActive(true);
            Cat_Coin_Time = 0f;
        }
    }
    
    #endregion

    //방해모드 고양이 함수모음
    #region 방해모드 고양이

    //방해모드 고양이
    void Cat_Interrupt()
    {
        //고양이 퇴치
        if(Cat_Appear == true && Cat_Touch_Cnt >= 20)
        {
            if (PlayerPrefs.GetInt("Infinite") == 1)
            {
                Bgm_Mgr.BgmSetting.Start_Sound(4);
            }
            else
            {
                Bgm_Mgr.BgmSetting.Start_Sound(1);
            }
            Moving_Cat.SetActive(true);
            Bgm_Start = false;
            Cat_Appear = false;
            Interrupt_Time = 0f;
        }

        //고양이 방해모드 후
        if (Cat_Appear == true)
        {
            if(Interrupt_Cat.transform.localPosition.y <= -10f)
            {
                Interrupt_Cat.transform.localPosition += Up_Speed;
            }
        }
        //고양이 방해모드 전
        else if(Cat_Appear == false)
        {
            if (Interrupt_Cat.transform.localPosition.y >= -1400)
            {
                Interrupt_Cat.transform.localPosition += Down_Speed;
            }
        }

        //고양이 방해모드 시작
        if(Interrupt_Time>=Change_Interrupt_Time)
        {
            if(Bgm_Start==false)
            {
                Cat_Touch_Cnt = 0;
                Bgm_Mgr.BgmSetting.Start_Sound(2);
                Bgm_Start = true;

                //노말고양이 사라짐
                Moving_Cat.SetActive(false);
            }
            Cat_Appear = true;
        }

    }
    
    //방해모드 고양이터치 버튼다운
    public void Inter_Cat_On_Btn_Down()
    {
        if (Cat_Stop == false)
        {
            Sfx_Mgr.SfxSetting.Get_Cat_Sfx();
            Cat_Touch_Cnt++;
            Interrupt_Cat_Image.sprite = Interrupt_Cats[1];
        }
    }

    //방해모드 고양이터치 버튼업
    public void Inter_Cat_On_Btn_Up()
    {
        Interrupt_Cat_Image.sprite = Interrupt_Cats[0];
    }
    
    #endregion


    //고양이 일시정지
    public void Cat_Stop_Btn()
    {
        Cat_Stop = !Cat_Stop;
    }
}
