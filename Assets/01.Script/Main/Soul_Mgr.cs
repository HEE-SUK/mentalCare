using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Soul_Mgr : MonoBehaviour
{
    //외부 호출변수
    public GameObject[] Souls;
    public Coin_Mgr Coin_Score;
    public Cat_Mgr Cat_Move;


    //영혼올라가는 프레임당 길이
    Vector3 Speed = new Vector3(0f, 0.1f, 0f);
    Vector3 Click_Speed = new Vector3(0f, -0.1f, 0f);

    //위치변수
    public int[] Soul_Cnt = { 0 };

    int GameOver_cnt;
    public bool Soul_Stop;

    //시간변수
    float[] Up_Times = { 0 };
    public float[] Limit_Time;
    public int Limit_Time_Num;
    float Infinite_Times;

    //아이템변수
    public Image[] Item_Status_where;
    public Sprite[] Item_Status_Sprite;
    public GameObject[] Item_Status;
    public int Item_Num;
    bool[] Item_On;

    float []Item_Time;
    float []Item_Time_Finish;

    //영혼이미지변수
    public SpriteRenderer[] Soul_Images;
    public Sprite[] Soul_Sprites;
    int Soul_Red;
    int Soul_Pink;

    void Awake ()
    {
        //각 영혼의 상승 시간값 
        Limit_Time = new float[5] { 3.5f, 2.7f, 2.0f, 1.5f, 1.1f };

        //영혼일시정지
        Soul_Stop = false;

        //영혼높이 카운트
        GameOver_cnt = 20;
        Soul_Cnt = new int[3];
        
        //각 영혼의 시간변수
        Up_Times = new float[3];
        //무한모드시 5스테이지속도로 시작
        if(PlayerPrefs.GetInt("Infinite")==1)
        {
            Limit_Time_Num = 4;
        }
        else
        {
            Limit_Time_Num = 0;
        }

        //아이템 시간변수
        Item_Time = new float[3];
        Item_Time_Finish = new float[3];
        Item_On = new bool[3];

        //영혼이미지변수
        Soul_Red = 15;
        Soul_Pink = 10;
    }
	
	void Update ()
    {
        //아이템 적용시간 카운트
        Item_Time_Cnt();
        Item_Time_End();

        //각 영혼 시간카운트 및 상승
        if (Soul_Stop == false)
        {
            //무한모드시 카운트
            if (PlayerPrefs.GetInt("Infinite") == 1)
            {
                Infinite_Times += Time.deltaTime;
                //1분마다 0.15초씩 감소
                if(Infinite_Times>=30f)
                {
                    Limit_Time[4] -= 0.15f;
                    Infinite_Times = 0f;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                //시간카운트
                if(Item_On[i]==false)
                {
                    Up_Times[i] += Time.deltaTime;
                    Color_Souls(i);
                }
                
                //영혼 상승
                if (Up_Times[i] >= Limit_Time[Limit_Time_Num])
                {
                    Up_Souls(i);
                    Up_Times[i] = 0f;
                }
            }
        }
    }
    
    //캐릭터 아이템 적용 파트 -> 정리완료!
    #region 각 영혼별 아이템 적용 파트

    //첫번째 영혼 아이템적용 
    public void Set_Item(int _Num, int _Down_Cnt, float _Item_Time)
    {
        Debug.Log("아이템 적용 시작");
        //아이템적용 이미지
        Soul_Images[_Num].sprite = Soul_Sprites[3];
        Item_Status_where[_Num].sprite = Item_Status_Sprite[Item_Num];
        Item_Status[_Num].SetActive(true);
        //상승속도 및 아이템시간 적용

        Item_Time[_Num] = 0f;
        Item_Time_Finish[_Num] = _Item_Time;
        
        Down_Souls(_Num, _Down_Cnt);

        Item_On[_Num] = true;
    }

    //아이템 적용시간 카운트
    void Item_Time_Cnt()
    {
        //영혼 3개 방문하면서 아이템온 체크
        for(int i=0;i<3;i++)
        {
            if (Item_On[i] == true)
            {
                //체크온 시 시간카운트
                Item_Time[i] += Time.deltaTime;
            }
        }
    }

    //아이템 적용종료
    void Item_Time_End()
    {
        for(int i=0;i<3;i++)
        {
            //아이템 적용시간 종료
            if (Item_On[i] == true && Item_Time[i] >= Item_Time_Finish[i])
            {
                Debug.Log("아이템 적용 종료");

                //아이템종료후 영혼 초기화
                Color_Souls(i);
                Item_Status[i].SetActive(false);
                Item_Time[i] = 0f;
                Item_On[i] = false;
            }
        }
    }

    //영혼 상태변화
    void Color_Souls(int _Num)
    {
        //18칸부터 빨간색 - 위험
        if (Soul_Cnt[_Num] >= Soul_Red)
        {
            Soul_Images[_Num].sprite = Soul_Sprites[2];
        }
        //13칸부터 주황색 - 경고
        else if (Soul_Cnt[_Num] >= Soul_Pink)
        {
            Soul_Images[_Num].sprite = Soul_Sprites[1];
        }
        //평소 파란색 - 안전
        else
        {
            Soul_Images[_Num].sprite = Soul_Sprites[0];
        }
    }

    //영혼 일시정지
    public void Stop_Souls()
    {
        Soul_Stop = !Soul_Stop;
        Cat_Move.Cat_Stop_Btn();
        Coin_Score.Coin_Stop = !Coin_Score.Coin_Stop;
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
    }

    #endregion

    //캐릭터 영혼상승 파트 -> 정리완료!
    #region 캐릭터별 영혼 상승 파트

    void Up_Souls(int _num)
    {
        //특정위치 이하에서만 상승
        if (Soul_Cnt[_num] < GameOver_cnt)
        {
            Souls[_num].transform.position += Speed;
            Soul_Cnt[_num]++;
        }
        //특정위치 도달시 게임오버
        else
        {
            //최고점수기록
            if (Coin_Score.Score > Coin_Score.Best)
            {
                PlayerPrefs.SetInt("BestScore", Coin_Score.Score);
            }
            //현재점수저장
            Singleton_Mgr.instance.Set_Score(Coin_Score.Score,Coin_Score.Coin);

            SceneManager.LoadScene("GameOver");
        }
    }

    #endregion

    //캐릭터 클릭효과 파트 -> 효율적으로 정리필요
    #region 캐릭터별 클릭시 효과

    public void Down_Souls(int _soul_num,int _down_cnt)
    {
        //아이템사용시 0이하로 내려가는 예외처리
        if (_down_cnt > Soul_Cnt[_soul_num])
        {
            Souls[_soul_num].transform.position += Click_Speed * Soul_Cnt[_soul_num];
            Soul_Cnt[_soul_num] -= Soul_Cnt[_soul_num];
        }
        //특정위치 이상에서만 내려간다.
        else if (Soul_Cnt[_soul_num] > 0)
        {
            //위치이동 및 cnt
            Souls[_soul_num].transform.position += Click_Speed*_down_cnt;
            Soul_Cnt[_soul_num] -= _down_cnt;

        }
    }
    #endregion
}
