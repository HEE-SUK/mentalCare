using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Ending_Mgr : MonoBehaviour
{
    public GameObject Next_Btn;
    public GameObject Infinite_Win;
    int Ending_Cnt;

    float Next_Cut;
    float Cut_pos;

    void Start()
    {
        //배경음
        Next_Cut = 12.8f;
        Cut_pos = 0f;
        Ending_Cnt = 0;
    }


    void Update()
    {
        this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(Cut_pos, this.transform.position.y, this.transform.position.z), 0.2f);
    }

    //다음이동
    public void NextBtn()
    {
        Get_Change();
        if (Ending_Cnt < 2)
        {
            Cut_pos -= Next_Cut;
            Ending_Cnt++;
        }
        else
        {
            //무한모드진입 창출력
            Infinite_Win.SetActive(true);
        }
        
        
    }

    //텍스트변환
    void Get_Change()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
    }


    //무한모드 전환
    public void Get_Infinite()
    {
        PlayerPrefs.SetInt("Infinite", 1);
        SceneManager.LoadScene("Main");
    }
}
