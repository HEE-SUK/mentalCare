using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bgm_Mgr : MonoBehaviour
{
    public static Bgm_Mgr BgmSetting = null;

    public AudioSource Bgm_Sound;
    public AudioClip[] Bgm_List;

    public bool Bgm_On;
    
    private void Awake()
    {
        //BGM도 싱글톤화 - 싱글톤을 여러개만들어도 괜찮은걸까
        if (BgmSetting == null)
        {
            BgmSetting = this;
        }
        else if (BgmSetting != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);

    }

    //BGM ON,OFF
    public void Set_Bgm()
    {
        if (Bgm_On == true)
        {
            Bgm_On = false;
            Bgm_Sound.mute = false;
        }
        else
        {
            Bgm_On = true;
            Bgm_Sound.mute = true;
        }
    }

    //BGM재생
    public void Start_Sound(int _Num)
    {
        Bgm_Sound.clip = Bgm_List[_Num];
        Bgm_Sound.Play();
    }

    //BGM종료
    public void Stop_Sound()
    {
        Bgm_Sound.Stop();
    }
}
