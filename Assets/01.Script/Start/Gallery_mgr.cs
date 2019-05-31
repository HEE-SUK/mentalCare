using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gallery_mgr : MonoBehaviour
{
    public GameObject Big_Photo_Panel;
    public Image Big_Photo;

    public GameObject[] Cat_Object;
    public Sprite[] Cat_Photos;
    public Image[] Cat_Btns;

    int Max_Num;

    void Start()
    {

        Max_Num = 14;

        for (int i = 0; i < Max_Num; i++)
        {
            Cat_Btns[i].sprite = Cat_Photos[i];
        }
        Ad_Gallery();
    }

    public void Ad_Gallery()
    {
        int G_Num = PlayerPrefs.GetInt("Gallery_Cnt");

        if (G_Num > 13)
        {
            G_Num = 13;
        }

        for (int i = 0; i < G_Num+1; i++)
        {
            Cat_Object[i].SetActive(true);
        }
    }
    
    //큰사진 변환
    public void Get_Big_Photo(int _Num)
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Big_Photo.sprite = Cat_Photos[_Num];
        Big_Photo_Panel.SetActive(true);
    }

    public void Get_Exit_Big()
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Big_Photo_Panel.SetActive(false);
    }



}
