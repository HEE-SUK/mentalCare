using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Guide_Mgr : MonoBehaviour 
{
    public GameObject Guide_Panel;
    public Soul_Mgr Soul;
    //시작시 일시정지
    void Start ()
    {
        if (PlayerPrefs.GetInt("Infinite") == 1)
        {
            Guide_Panel.SetActive(false);
        }
        else
        {
            Guide_Panel.SetActive(true);
            Get_Stop();
        }
    }
    public void Get_Stop()
    {
        Soul.Stop_Souls();
    }
}
