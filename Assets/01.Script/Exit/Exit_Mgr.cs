using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Exit_Mgr : MonoBehaviour
{
    public string[] Words;
    public Text Word;
    public Text Score_Num;
    public Text Best_Num;

    void Start()
    {
        Bgm_Mgr.BgmSetting.Start_Sound(3);

        Words = new string[6];

        Words[0] = "좀만 자고 다시해볼까나~";
        Words[1] = "고양아 너 사료값은 꼭 벌어줄게...";
        Words[2] = "우리는 의지가 불타올랐다!";
        Words[3] = "햄버거가 먹고싶다리...";
        Words[4] = "치킨먹고 다시해보잙!";
        Words[5] = "언젠간 사람들이 알아봐줄거야";

        int num = Random.Range(0,5);

        Word.text = Words[num];


        //점수출력
        Score_Num.text = Singleton_Mgr.instance.Get_Score().ToString();
        Best_Num.text = PlayerPrefs.GetInt("BestScore").ToString();
    }


    public void Get_Return()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        SceneManager.LoadScene("Start");
    }
}
