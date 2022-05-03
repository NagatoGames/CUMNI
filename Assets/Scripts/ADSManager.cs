using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;

public class ADSManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener, IUnityAdsInitializationListener
{
    private GameManager gameManager;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Text info;

    public static string Rewarded_Android = "Rewarded_Android";
    public static string Android_ID = "4722669";

    private void Awake()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        info.text = "Ќет доступной рекламы на данный момент!";
    }

    public void ShowADS()
    {
        if (Advertisement.isInitialized)
        {
            Debug.Log("isInitialized = true");
            LoadInititialAd();
        }
        else
        {
            Advertisement.Initialize(Android_ID, false, this);
        }
    }

    public void LoadInititialAd()
    {
        Advertisement.Load(Rewarded_Android, this);
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("cant show ads");
        infoPanel.GetComponent<Animation>().Play();
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("start showing");
        Time.timeScale = 0;
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("ads stoped");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Time.timeScale = 1;
        if (showCompletionState == UnityAdsShowCompletionState.COMPLETED)
        {
            gameManager.getPlayerData().Coins += 25;
            gameManager.getPlayerData().SaveData();
            gameManager.UpdateCoin();
        }
        Debug.Log("ads finish: state = " + showCompletionState);
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("ads loaded");
        Advertisement.Show(Rewarded_Android, this);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("ads failed");
        infoPanel.GetComponent<Animation>().Play();
    }

    public void OnInitializationComplete()
    {
        LoadInititialAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log("ads init failed");
        infoPanel.GetComponent<Animation>().Play();
    }
}
