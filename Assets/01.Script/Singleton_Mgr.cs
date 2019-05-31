using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Singleton_Mgr : MonoBehaviour
{
    public static Singleton_Mgr instance = null;
    int Last_Score;
    int Last_Coin;
    
    int Exit_Cnt = 0;

    private void Awake()
    {
        //화면고정 - 1280*720
        Screen.SetResolution(1280, 720, true);
        //Screen.fullScreen = true;
        //PlayerPrefs.SetInt("First_Time", 0);
        //인스턴스 유지 - 싱글톤
        if (instance == null)
        {
            instance = this;
        } 
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        //처음시작할때 최대점수와 갤러리 초기화
        if (PlayerPrefs.GetInt("First_Time")==0)
        {
            //기록 및 사진열람 초기화
            PlayerPrefs.DeleteAll();
            PlayerPrefs.SetInt("First_Time", 1);
        }


        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        Get_Quit_Btn();
    }

    //저장된 점수 출력
    public void Set_Score(int _Store,int _Coin)
    {
        Last_Score = _Store;
        Last_Coin = _Coin;
    }

    //점수저장
    public int Get_Score()
    {
        return Last_Score;
    }
    //돈 저장
    public int Get_Coin()
    {
        return Last_Coin;
    }

    //백버튼구현
    #region BACK버튼 구현

    //나가기버튼
    void Get_Quit_Btn()
    {
        //백버튼 누를시
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Exit_Cnt++;
            //두번연속 실패
            if (!IsInvoking("Disable_Double_Click"))
            {
                Invoke("Disable_Double_Click", 0.5f);
            }
        }
        //백버튼 두번연속 게임종료
        if (Exit_Cnt == 2)
        {
            CancelInvoke("Disable_Double_Click");
            Application.Quit();
        }
    }

    //두번 연속실패 다시처음
    void Disable_Double_Click()
    {
        Exit_Cnt = 0;
    }
    #endregion

}
