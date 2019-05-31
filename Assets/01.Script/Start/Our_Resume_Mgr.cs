using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Our_Resume_Mgr : MonoBehaviour
{
    public GameObject Prev_Btn;
    public GameObject Next_Btn;

    public Image Resume_Photo;
    public Text Resume_Title;
    public Text Resume_Profile;
    public Text Resume_Content;

    public Sprite[] Our_Photo;

    string[] Our_Title;
    string[] Our_Profile;
    string[] Our_Content;

    int Resume_Cnt;

    void Start ()
    {
        Resume_Cnt = 0;


        Our_Title = new string[4];
        Our_Profile = new string[4];
        Our_Content = new string[4];


        Our_Title[0] = "폭탄맨";
        Our_Title[1] = "너굴맨";
        Our_Title[2] = "호스맨";
        Our_Title[3] = "로사";

        Our_Profile[0] = "인적 사항: 27(남)\n담당업무: 아트\n특징: 종종 심지에 불이 붙는다.";
        Our_Profile[1] = "인적 사항: 27(남)\n담당업무: 기획\n특징: 보리차를 좋아한다.";
        Our_Profile[2] = "인적 사항: 27(남)\n담당업무: 프로그래밍\n특징: 카페인 중독자";
        Our_Profile[3] = "묘적 사항: 1(남)\n담당업무: 방해\n특징: 아주 산만하다.";

        Our_Content[0] = "유망했던 '붐붐대학' 폭탄제거과에 입학했지만 오랜 꿈인 미술을 포기하지 못하고 결국 자퇴를 한다. 그 후 너굴맨과 함께 스타트업 회사를 함께 창립하게 된다.";
        Our_Content[1] = "절친했던 래서판다가 너굴컴퍼니에서 퇴출당하자 멘붕에 빠진 그도 결국 퇴사하게 된다. 개인적인 야망과 회사에 대한 복수심으로 그는 스타트업 회사를 차리게 된다.";
        Our_Content[2] = "경주마였던 형제를 동경했지만 걸음이 느린 그는 새로운 재능을 찾아 떠난 끝에 멘붕컴퍼니에서 프로그래밍을 시작하게 된다.";
        Our_Content[3] = "비가 내리던 밤, 불현듯 사무실에 찾아온 아기고양이. 그렇게 새로운 사원으로 식구가 늘었지만 날이 가면갈수록 작업을 방해하기 시작한다. " +
                         "\n종종 로사가 알수없는 동전을 떨어트린다. " +
                         "\n사라지기전에 빨리 주워보자.";

        Get_Text();

    }
	

    public void Prev_Resume()
    {
        if (Resume_Cnt > 0)
        {
            Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
            Resume_Cnt--;
            Get_Text();
        }

        if (Resume_Cnt == 0)
        {
            Prev_Btn.SetActive(false);
        }

        if (Resume_Cnt < 3)
        {
            Next_Btn.SetActive(true);
        }
    }

    public void Next_Resume()
    {

        if (Resume_Cnt < 3)
        {
            Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
            Resume_Cnt++;
            Get_Text();
        }

        if (Resume_Cnt > 0)
        {
            Prev_Btn.SetActive(true);
        }

        if (Resume_Cnt == 3)
        {
            Next_Btn.SetActive(false);
        }
    }

    void Get_Text()
    {
        Resume_Photo.sprite = Our_Photo[Resume_Cnt];
        Resume_Title.text = Our_Title[Resume_Cnt];
        Resume_Profile.text = Our_Profile[Resume_Cnt];
        Resume_Content.text = Our_Content[Resume_Cnt];
        Resume_Photo.SetNativeSize();
    }
}
