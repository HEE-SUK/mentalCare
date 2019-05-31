using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sfx_Mgr : MonoBehaviour
{
    public static Sfx_Mgr SfxSetting = null;

    public AudioSource Soul_Sound;
    public AudioSource Coin_Sound;
    public AudioSource Cat_Touch_Sound;
    public AudioSource Next_Sound;
    public AudioSource Score_Sound;
    public AudioSource Item_Sound;
    public AudioSource Moving_Cat_Sound;

    public bool Sfx_On;

    private void Awake()
    {
        if (SfxSetting == null)
        {
            SfxSetting = this;
        }
        else if (SfxSetting != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Set_Sfx()
    {
        if (Sfx_On == true)
        {
            Sfx_On = false;
            Soul_Sound.mute = false;
            Coin_Sound.mute = false;
            Cat_Touch_Sound.mute = false;
            Next_Sound.mute = false;
            Score_Sound.mute = false;
            Item_Sound.mute = false;
            Moving_Cat_Sound.mute = false;
        }
        else
        {
            Sfx_On = true;
            Soul_Sound.mute = true;
            Coin_Sound.mute = true;
            Cat_Touch_Sound.mute = true;
            Next_Sound.mute = true;
            Score_Sound.mute = true;
            Item_Sound.mute = true;
            Moving_Cat_Sound.mute = true;
        }
    }

    public void Get_Soul_Sfx()
    {
        Soul_Sound.Play();
    }
    public void Get_Coin_Sfx()
    {
        Coin_Sound.Play();
    }
    public void Get_Cat_Sfx()
    {
        Cat_Touch_Sound.Play();
    }
    public void Get_Next_Sfx()
    {
        Next_Sound.Play();
    }
    public void Get_Score_Sfx()
    {
        Score_Sound.Play();
    }
    public void Get_Item_Sfx()
    {
        Item_Sound.Play();
    }
    public void Get_Moving_Cat_Sfx()
    {
        Moving_Cat_Sound.Play();
    }
}
