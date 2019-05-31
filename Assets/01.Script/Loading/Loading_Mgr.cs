using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading_Mgr : MonoBehaviour
{
    public Text Loading_Ments;

    string[] Loading_Ment;
    float Loading_Time;
    int Loading_Cnt;
    int Ment_Cnt;


	void Start ()
    {
        Ment_Cnt = 0;
        Loading_Cnt = 0;
        Loading_Time = 0;
        Loading_Ment = new string[3];

        Loading_Ment[0] = "반지하 사무실 구하는중";
        Loading_Ment[1] = "길냥이 '로사'를 받아들이는중";
        Loading_Ment[2] = "밀린 월세 갚는중";

        Loading_Ments.text = Loading_Ment[0];

        StartCoroutine(LoadScene());

    }
	
    IEnumerator LoadScene()
    {
        yield return null;

        AsyncOperation Start = SceneManager.LoadSceneAsync("Start");

        Start.allowSceneActivation = false;

        while(!Start.isDone)
        {
            yield return null;
            Loading_Time += Time.deltaTime;

            if(Start.progress >=0.9f)
            {
                Start.allowSceneActivation = true;
            }
            else
            {
                if (Loading_Cnt >= 5)
                {
                    Ment_Cnt++;
                    if (Ment_Cnt >= 3)
                    {
                        Ment_Cnt = 0;
                    }
                    else
                    {
                        Loading_Ments.text = Loading_Ment[Ment_Cnt];
                        Loading_Cnt = 0;
                    }
                }
                
                

                if (Loading_Time >= 1f)
                {
                    Loading_Cnt += 1;
                    Loading_Ments.text += ".";
                    Loading_Time = 0f;
                }
            }
        }

    }
}
