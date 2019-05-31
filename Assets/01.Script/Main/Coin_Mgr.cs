 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Mgr : MonoBehaviour
{
    //외부호출
    public GameObject New_Text;
    public Text Coin_Text;
    public Text Score_Text;
    public Text Coin_Now;
    //점수초기화
    public int One_Coin;
    public int Coin;
    
    public int Score;
    public int Best;
    
    bool One_Time;
    public bool Coin_Stop; 
    float Coin_Time = 0;

    void Start ()
    {
        One_Coin = 20;
        if(PlayerPrefs.GetInt("Infinite")==1)
        {
            Coin = Singleton_Mgr.instance.Get_Coin();
            Score = Singleton_Mgr.instance.Get_Score();
        }
        else
        {
            Score = 0;
            Coin = 0;
        }
        Best = PlayerPrefs.GetInt("BestScore");
        //초기점수 표시 
        Coin_Text_Mgr();
    }
	
	void Update ()
    {
        Coin_Time += Time.deltaTime;

        if(Coin_Time>=0.5f)
        {
            Get_Coin();
            Coin_Time = 0;
        }

        //최대점수
        if(Coin>=999999)
        {
            One_Coin = 0;
        }
	}

    //영혼클릭시 점수획득
    public void Get_Coin()
    {
        if(Coin_Stop==false)
        {
            Coin += One_Coin;
            Score += One_Coin;
        }

        //최고점수 넘는순간 new버튼 활성화
        if (Score>Best)
        {
            if(One_Time==false)
            {
                //효과음
                Sfx_Mgr.SfxSetting.Get_Score_Sfx();
                One_Time = true;
            }
            New_Text.SetActive(true);
        }
        Coin_Text_Mgr();
    }

    //코인 점수 표시
    public void Coin_Text_Mgr()
    {
        Coin_Text.text = Coin.ToString();
        Score_Text.text = Score.ToString();
        Coin_Now.text = "+ "+One_Coin.ToString();
    }
}
