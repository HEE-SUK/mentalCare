using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Mgr : MonoBehaviour
{
    public Item_Mgr Item;
    public Coin_Mgr Coin;

	void Start ()
    {
        if(PlayerPrefs.GetInt("Infinite")==1)
        {
            Bgm_Mgr.BgmSetting.Start_Sound(4);
        }
        else
        {
            Bgm_Mgr.BgmSetting.Start_Sound(1);
        }
	}


    void Update()
    {
        //치트키 2000원 즉시
        if(Input.GetKeyDown(KeyCode.W))
        {
            Coin.Coin += 2000;
            Coin.Coin_Text.text = Coin.Coin.ToString();
        }
    }
}
