using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Help_Ads : MonoBehaviour
{
    public Gallery_mgr Gallerys;

    private const string android_game_id = "2620526";
    private const string ios_game_id = "2620528";

    private const string rewarded_video_id = "rewardedVideo";

    void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
    #if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
    #elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
    #endif
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(rewarded_video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");
                    int G_Num = PlayerPrefs.GetInt("Gallery_Cnt");

                    G_Num += 1;

                    PlayerPrefs.SetInt("Gallery_Cnt", G_Num);

                    Gallerys.Ad_Gallery();
                    // to do ...
                    // 광고 시청이 완료되었을 때 처리

                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // to do ...
                    // 광고가 스킵되었을 때 처리

                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");

                    // to do ...
                    // 광고 시청에 실패했을 때 처리

                    break;
                }
        }
    }
}
