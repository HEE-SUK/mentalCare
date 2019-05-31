using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro_Mgr : MonoBehaviour
{
    public GameObject Text;
	void Start ()
    {
        Screen.fullScreen = true;
        Text.transform.localPosition = new Vector3(0f, -1000f, 0f);
    }

    void Update()
    {
        Text.transform.position += new Vector3(0f, 3f, 0f);
        
        //텍스트 모두 봤으면 이동
        if (Text.transform.localPosition.y>=800)
        {
            SceneManager.LoadScene("Loading");
        }
        
    }

    //스킵버튼
    public void Skip_Btn()
    {
        SceneManager.LoadScene("Loading");
    }
}
