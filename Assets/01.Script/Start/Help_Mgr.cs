using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Help_Mgr : MonoBehaviour
{
    public GameObject[] Help_Images;
    public GameObject Prev_Btn_on;
    public GameObject Next_Btn_on;
    public Text Help_Titles;
    public Text Help_Contexts;

    string[] Help_titles;
    string[] Help_contexts;

    int Help_Cnt;

    void Start ()
    {
        //내용초기화
        Help_Cnt = 0;
        Help_titles = new string[4];
        Help_contexts = new string[4];
        Set_Context();

        Get_Change(Help_Cnt);
    }

    //뒤로이동
    public void prevBtn()
    {
        if(Help_Cnt > 0)
        {
            Help_Images[Help_Cnt].SetActive(false);
            Help_Cnt--;
            Get_Change(Help_Cnt);
        }

        if (Help_Cnt == 0)
        {
            Prev_Btn_on.SetActive(false);
        }

        if (Help_Cnt < 3)
        {
            Next_Btn_on.SetActive(true);
        }
    }

    //다음이동
    public void NextBtn()
    {
        if (Help_Cnt < 3)
        {
            Help_Images[Help_Cnt].SetActive(false);
            Help_Cnt++;
            Get_Change(Help_Cnt);
        }

        if (Help_Cnt > 0)
        {
            Prev_Btn_on.SetActive(true);
        }

        if (Help_Cnt == 3)
        {
            Next_Btn_on.SetActive(false);
        }
    }

    //텍스트변환
    void Get_Change(int _Cnt)
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Help_Images[_Cnt].SetActive(true);
        Help_Titles.text = Help_titles[_Cnt];
        Help_Contexts.text = Help_contexts[_Cnt];
    }


    //도움말텍스트 설정
    void Set_Context()
    {
        //제목
        Help_titles[0] = "정신줄";
        Help_titles[1] = "아이템";
        Help_titles[2] = "스테이지";
        Help_titles[3] = "고양이";
        //도움말 내용
        Help_contexts[0] = "정신줄은 일정 시간마다 조금씩 머리에서 빠져나갑니다.\n\n" +
                           "플레이어는 아이템을 사용해서 저희들의 멘탈을 빠져나가지 않도록 관리해주시면 됩니다.\n\n" +
                           "만약 한명이라도 멘탈이 전부 빠져나가 버린다면 게임오버가 됩니다.";

        Help_contexts[1] = "플레이어는 게임을 진행하면서 모이는 돈으로 아이템을 구매할 수 있습니다.\n\n" +
                           "아이템의 효과는 정신줄을 도로 넣어주거나 일정시간동안 잡아줄 수 있습니다.\n\n" +
                           "각 아이템의 설명은 플레이중 왼쪽상단의 아이콘을 터치해주세요!";

        Help_contexts[2] = "총 5개의 스테이지로 구성되어있습니다.\n" +
                           "5개의 스테이지를 모두 클리어 하실경우 엔딩 뒤에 무한모드로 진입하게 됩니다.\n\n" +
                           "반지하에서 시작하여 대기업까지 올라가 여러분의 기록을 새롭게 갱신해보세요!";

        Help_contexts[3] = "일정시간마다 로사(고양이)가 화면 위로 나타나 방해를 하기 시작합니다.\n\n" +
                           "이러한 방해를 막기위해 로사(고양이)를 여러번 터치해야 합니다.\n\n" +
                           "저희 로사(고양이)의 방해를 막지못하면 게임오버가 될 수 있습니다.";
    }
}
