using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choose_Mgr : MonoBehaviour
{
    //호출함수
    public Soul_Mgr Soul;
    public Item_Mgr Item;
    public Coin_Mgr Coin;

    int Down_Coin;
    //아이템시간 변수
    int Down_Cnt;
    //float Limit_Time;
    float Item_Time;

    //선택 활성화
    void OnEnable()
    {
        //효과음
        Sfx_Mgr.SfxSetting.Get_Coin_Sfx();

        //영혼스탑
        Soul.Stop_Souls();
        Down_Coin = Item.Down_Coin;
        Down_Cnt = Item.Down_Cnt;
        Item_Time = Item.Item_Time;
    }

    //각 캐릭터 선택함수
    public void Choose_Btn(int _soul_num)
    {
        Get_Choice(_soul_num);
    }

    //아이템 적용
    void Get_Choice(int _Num)
    {
        Sfx_Mgr.SfxSetting.Get_Item_Sfx();
        Coin.Coin -= Down_Coin;
        Coin.Coin_Text_Mgr();
        Soul.Set_Item(_Num, Down_Cnt, Item_Time);
        Get_Exit();
    }

    public void Get_Exit()
    {
        Soul.Stop_Souls();
        gameObject.SetActive(false);
    }
}
