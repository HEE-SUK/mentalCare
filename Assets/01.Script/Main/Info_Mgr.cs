using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Info_Mgr : MonoBehaviour
{
    //버튼
    public GameObject Prev_Btn_on;
    public GameObject Next_Btn_on;

    public Image Info_Images;
    public Text Info_Titles;
    public Text Info_Shorts;
    public Text Info_Contexts;

    public Sprite[] Info_images;
    string[] Info_titles;
    string[] Info_shorts;
    string[] Info_contexts;

    int Info_Cnt;

    void Start ()
    {
        //아이템정보 초기화
        Info_Cnt = 0;
        Info_titles = new string[6];
        Info_shorts = new string[6];
        Info_contexts = new string[6];

        Set_Texts();

        Get_Change(Info_Cnt);
    }
	

    //이전버튼
    public void Prev_Btn()
    {
        if (Info_Cnt > 0)
        {
            Info_Cnt--;
            Get_Change(Info_Cnt);
        }
        if (Info_Cnt == 0)
        {
            Prev_Btn_on.SetActive(false);
        }

        if (Info_Cnt < 5)
        {
            Next_Btn_on.SetActive(true);
        }
    }

    //다음버튼
    public void Next_Btn()
    {

        if (Info_Cnt < 5)
        {
            Info_Cnt++;
            Get_Change(Info_Cnt);
        }

        if (Info_Cnt > 0)
        {
            Prev_Btn_on.SetActive(true);
        }

        if (Info_Cnt == 5)
        {
            Next_Btn_on.SetActive(false);
        }
    }


    //텍스트변환
    void Get_Change(int _Cnt)
    {
        Sfx_Mgr.SfxSetting.Get_Soul_Sfx();
        Info_Images.sprite = Info_images[_Cnt];
        Info_Titles.text = Info_titles[_Cnt];
        Info_Shorts.text = Info_shorts[_Cnt];
        Info_Contexts.text = Info_contexts[_Cnt];
    }


    //텍스트 입력
    void Set_Texts()
    {
        //아이템 이름
        Info_titles[0] = "냉수";
        Info_titles[1] = "믹스커피";
        Info_titles[2] = "에너지드링크";
        Info_titles[3] = "피로회복제";
        Info_titles[4] = "스팀팩";
        Info_titles[5] = "휴식";

        //아이템 효과
        Info_shorts[0] = "올라오는 정신줄을 2칸 내려줍니다.";
        Info_shorts[1] = "올라오는 정신줄을 4칸 내려줍니다.";
        Info_shorts[2] = "올라오는 정신줄을 8칸 내려줍니다.";
        Info_shorts[3] = "올라오는 정신줄을 15칸 내려줍니다.";
        Info_shorts[4] = "올라오는 정신줄을 6초간 멈추게 해줍니다.";
        Info_shorts[5] = "올라오는 정신줄을 15초간 멈추게 해줍니다.";

        //아이템 설명
        Info_contexts[0] = "반지하방에서 유일하게 걱정없이 마실 수 있는 음료이다.\n너굴맨의 보리차티백을 넣으면 기가막히지만 다떨어진지 오래되었다..." +
                           "\n차가운 물로 정신을 차려서 열심히 작업을 해보자!\n ";
        Info_contexts[1] = "아침마다 타먹는 믹스커피는 기가막히게 정신을 차리게 해준다. 따뜻한 믹스커피한잔을 음미하며 다시 집중해서 일해보자" +
                           "\n너무 많이 마시면 중독이될 것이다... 호스맨은 이미 심각한 카페인 중독에 빠져있다...";
        Info_contexts[2] = "물과 커피로도 부족하다면 에너지드링크로 각성을 해보자! 부작용으로는 잠을 못자게 될 수도 있다." +
                           "\n폭탄맨이 요즘 자꾸 늦게 자는것 같다...";
        Info_contexts[3] = "도저히 못 버티겠다면 약의 힘으로 버텨보자! 오랜시간동안 정신줄을 붙잡을 순 있겠지만 너무 많이 먹지는 말자." +
                           "\n오히려 몸을 망가뜨리는 지름길이 될 수도 있다...";
        Info_contexts[4] = "기왕 각성할꺼면 확실하게 해야할 필요가 있지. 불나방처럼 작업에 달려든다면 정신줄이 빠져나갈 틈도 주지않게 될 것이다.";
        Info_contexts[5] = "그동안 고생해왔으니 이제 그만 멈추고 잠을 자도록하자. \n'잠은 최고의 약이다.'";
    }
}
