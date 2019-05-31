using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stage_mgr : MonoBehaviour
{
    public Text Stage_Name;
    string[] Stages;

	void Start ()
    {
        Stages = new string[6];
        Stages[0] = "반지하";
        Stages[1] = "오피스텔";
        Stages[2] = "소기업";
        Stages[3] = "중견기업";
        Stages[4] = "대기업";
        Stages[5] = "무한모드";

        if (PlayerPrefs.GetInt("Infinite")==1)
        {
            Stage_Name.text = Stages[5];
        }
        else
        {
            Stage_Name.text = Stages[0];
        }

    }
	
    public void Stage_Name_Change(int _Stage_Num)
    {
        Stage_Name.text = Stages[_Stage_Num];
    }
}
