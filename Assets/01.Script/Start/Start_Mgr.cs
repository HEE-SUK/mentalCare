using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Start_Mgr : MonoBehaviour
{
    public Help_Ads Ads;
    public Fade_mgr Fade;

    public GameObject Help_Win;
    public GameObject Option_Win;
    public GameObject Picture_Win;
    public GameObject Story_Win;

    void Awake()
    {
        //무한모드초기화
        PlayerPrefs.SetInt("Infinite", 0);
        Singleton_Mgr.instance.Set_Score(0,0);

        //배경음 및 페이드
        Bgm_Mgr.BgmSetting.Start_Sound(0);
        Fade.Fade_In_Btn();
    }

    //시작버튼
    public void Get_start()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        SceneManager.LoadScene("Main");
    }

    //도움말버튼
    public void Get_Help()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Help_Win.SetActive(!Help_Win.activeSelf);
    }

    //옵션버튼
    public void Get_Option()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Option_Win.SetActive(!Option_Win.activeSelf);
    }
    
    //갤러리버튼
    public void Get_Gallery()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Picture_Win.SetActive(!Picture_Win.activeSelf); 
    }

    //광고버튼
    public void Get_Ads()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Ads.ShowRewardedAd();
    }
    
    //이력서버튼
    public void Get_OurStorys()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Story_Win.SetActive(!Story_Win.activeSelf);
    }
}
