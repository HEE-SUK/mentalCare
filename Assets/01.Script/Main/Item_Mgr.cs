using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Item_Mgr : MonoBehaviour
{
    public Fade_mgr Fade;
    public Soul_Mgr Souls;
    public Coin_Mgr Coin;
    public Stage_mgr Stage;
    public GameObject Next_Win;
    public GameObject Ending_Win;
    public GameObject Choose_Win;
    public Back_Ground_Down BackGround;
    public Text Next_Price_Text;

    //무한모드 변수
    public GameObject Next_Btn_Win;

    int[] Price;
    int[] Next_Price;
    int[] Coin_Price;
    int[] Down_Item;
    float[] Item_Time_List;
    
    public int Down_Coin;
    public int Down_Cnt;
    public float Item_Time;
    int Stage_Num;

    void Start()
    {
        Stage_Num = 0;
        Price = new int[6] { 200,400,800,1500,1000,2000};
        Down_Item = new int[6] { 2, 4, 8, 15, 0, 0 };
        Item_Time_List = new float[6] { 0f, 0f, 0f, 0f, 6f, 15f };
        Next_Price = new int[5] {3000,5000,7000,10000,13000 };
        Coin_Price = new int[5] { 50, 80, 110, 140, 180 };
        

        if(PlayerPrefs.GetInt("Infinite")==1)
        {
            Next_Btn_Win.SetActive(false);
            Set_Coin(4);
            Coin.Coin_Text_Mgr();
        }

        Next_Price_Text.text = Next_Price[Stage_Num].ToString();
    }

    public void Item_Btn(int _Item_Num)
    {
        Souls.Item_Num = _Item_Num;
        Get_Item(Price[_Item_Num], Down_Item[_Item_Num], Item_Time_List[_Item_Num]);
    }

    //다음스테이지 전환 파트
     #region 다음스테이지전환
    public void Next_Win_Btn() 
    {
        if (Coin.Coin >= Next_Price[Stage_Num])
        {
            //영혼 일시정지
            Souls.Stop_Souls();
            //무한모드
            if (Stage_Num == 4)
            {
                //현재점수저장
                Singleton_Mgr.instance.Set_Score(Coin.Score, Coin.Coin);
                Ending_Win.SetActive(true);
            }
            //다음스테이지
            else
            {
                Next_Win.SetActive(true);
            }
        }
    }

    //다음 스테이지 아이템
    public void Next_Btn()
    {
        //코인감소,점수상승
        Coin.Coin -= Next_Price[Stage_Num];
        Coin.Score += Next_Price[Stage_Num];
        Coin.Coin_Text_Mgr();

        if (Stage_Num==4)
        {
            //마지막 무한모드 구현
            Singleton_Mgr.instance.Set_Score(Coin.Score,Coin.Coin);
            Bgm_Mgr.BgmSetting.Stop_Sound();
            Fade.Fade_Out_Btn();
        }
        else
        {
            //다음스테이지 설정
            BackGround.Get_Down(Stage_Num);
            Stage_Num++;

            //속도와 코인변화
            Souls.Limit_Time_Num++;
            
            
            //스테이지 이름변경
            Stage.Stage_Name_Change(Stage_Num);

            Set_Coin(Stage_Num);
            Next_Price_Text.text = Next_Price[Stage_Num].ToString();
            Souls.Stop_Souls();
        }
    }

    //next_btn얻는 금화 증가치
    void Set_Coin(int _Stage_Num)
    {
        if (_Stage_Num == 1)
        {
            Coin.One_Coin = Coin_Price[1];
        }
        else if (_Stage_Num == 2)
        {
            Coin.One_Coin = Coin_Price[2];
        }
        else if (_Stage_Num == 3)
        {
            Coin.One_Coin = Coin_Price[3];
        }
        else if (_Stage_Num == 4)
        {
            Coin.One_Coin = Coin_Price[4];
        }
        else
        {
            Coin.One_Coin = Coin_Price[0];
        }
    }
    #endregion


    //아이템 사용화면 전환
    void Get_Item(int _Coin, int _Down_Cnt, float _Item_time)
    {
        if(_Coin < Coin.Coin)
        {
            Down_Coin = _Coin;
            Down_Cnt = _Down_Cnt;
            Item_Time = _Item_time;
            Choose_Win.SetActive(true);
        }
    }

}
