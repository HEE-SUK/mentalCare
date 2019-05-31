 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat_Coin_mgr : MonoBehaviour
{
    public GameObject Moving_Cat;
    public Coin_Mgr Coin;
    Vector3 Cat_Pos;
    Vector3 Limit_Pos;
    float time;
    float Limit_Time;

    void OnEnable()
    {
        time = 0f;
        Limit_Time = 1.5f;
        Cat_Pos = Moving_Cat.transform.position;
        gameObject.transform.position = Cat_Pos + new Vector3(0f,80f,0f);
        Limit_Pos = gameObject.transform.position + new Vector3(0f, 100f, 0f);
    }

    void Update()
    {
        time += Time.deltaTime;
        
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position,Limit_Pos,0.25f);
        
        //동전 사라짐
        if (time >= Limit_Time)
        {
            gameObject.SetActive(false);
        }
    }

    public void Get_Cat_Coin()
    {
        Sfx_Mgr.SfxSetting.Get_Coin_Sfx();
        Coin.Coin += 200;
        Coin.Coin_Text_Mgr();
        gameObject.SetActive(false);
    }
}
