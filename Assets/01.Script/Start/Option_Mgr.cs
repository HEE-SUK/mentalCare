using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Option_Mgr : MonoBehaviour
{
    public Text Bgm_Text;
    public Text Sfx_Text;

    //시작시 onoff표시 체크
    void Start ()
    {
        Check_Bgm();
        Check_Sfx();
    }

    //배경음 onoff버튼 클릭
    public void Bgm_OnOff()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Bgm_Mgr.BgmSetting.Set_Bgm();

        Check_Bgm();
    }
    
    //효과음 onoff버튼 클릭
    public void Sfx_OnOff()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Sfx_Mgr.SfxSetting.Set_Sfx();
        Check_Sfx();
    }

    //onoff체크
    void Check_Bgm()
    {
        if (Bgm_Mgr.BgmSetting.Bgm_On)
        {
            Bgm_Text.text = "OFF";
        }
        else
        {
            Bgm_Text.text = "ON";
        }
    }

    //onoff체크
    void Check_Sfx()
    {
        if (Sfx_Mgr.SfxSetting.Sfx_On)
        {
            Sfx_Text.text = "OFF";
        }
        else
        {
            Sfx_Text.text = "ON";
        }
    }
}
