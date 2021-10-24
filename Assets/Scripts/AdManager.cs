using UnityEngine;
using GoogleMobileAds.Api;
using System;
using UnityEngine.UI;

public class AdManager : MonoBehaviour
{
    public int diamonds = 0;
    public Text diamondsText;

    private BannerView bannerAd;
    private InterstitialAd interstitial;
    private RewardedAd rewardedAd;

    // THIS IS A TEST ADS ID, WHEN YOU WANT TO PUBLISH YOUR GAME JUST REPLACE THESE ID'S WITH YOUR OWN ADMOB ID'S
    private string BannerAdId = "ca-app-pub-3940256099942544/6300978111";
    private string IntersitialAdId = "ca-app-pub-3940256099942544/1033173712";
    private string RewardedVideoAdId = "ca-app-pub-3940256099942544/5224354917";

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(InitializationStatus => { });
        this.RequestBanner();
        diamonds = PlayerPrefs.GetInt("diamond");
    }

    void Update()
    {
        diamondsText.text = "diamonds: " + diamonds;
        PlayerPrefs.SetInt("diamond", diamonds);
    }

    private AdRequest CreateAdRequest()
	{
        return new AdRequest.Builder().Build();
	}

	private void RewardedAd_OnAdClosed(object sender, EventArgs e)
	{

	}

	private void RewardedAd_OnUserEarnedReward(object sender, Reward e)
    {
        diamonds += 5;
    }

	private void RewardedAd_OnAdLoaded(object sender, EventArgs e)
	{
        rewardedAd.Show();
	}

    // used in start func
    // when you want to show your banner on screen 
    private void RequestBanner()
    {
        string adUnityId = BannerAdId;
        this.bannerAd = new BannerView(adUnityId, AdSize.SmartBanner, AdPosition.Bottom);
        this.bannerAd.LoadAd(this.CreateAdRequest());

    }

    // Request Intersitial ads
    public void RequestInterstitialAds()
    {
        string adUnitId = IntersitialAdId;

        if (this.interstitial != null)
        {
            this.interstitial.Destroy();
        }

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(adUnitId);

        // Load an Intersitial ad
        this.interstitial.LoadAd(this.CreateAdRequest());
    }

    // first Request to load Intersitial then show Intersitial ads 
    public void ShowInterstitialAds()
    {
        if (this.interstitial.IsLoaded())
        {
            interstitial.Show();
        }
        else
        {
            Debug.Log("Not ready yet");
        }
    }

    // load rewarded video ads
    public void LoadRewardedVideoAds()
    {
#if UNITY_ANDROID
        string adUnitId = RewardedVideoAdId;
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/1712485313";
#else
            string adUnitId = "unexpected_platform";
#endif

        this.rewardedAd = new RewardedAd(adUnitId);

        this.rewardedAd.OnAdLoaded += RewardedAd_OnAdLoaded;
        this.rewardedAd.OnUserEarnedReward += RewardedAd_OnUserEarnedReward;
        this.rewardedAd.OnAdClosed += RewardedAd_OnAdClosed;


        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(this.CreateAdRequest());
    }
}