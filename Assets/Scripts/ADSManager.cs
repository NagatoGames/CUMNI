using UnityEngine;
using UnityEngine.Advertisements;

public class ADSManager : MonoBehaviour, IUnityAdsShowListener, IUnityAdsLoadListener
{
    private GameManager gameManager;

    public static string Rewarded_Android = "Rewarded_Android";

    void Start()
    {
        gameManager = gameObject.GetComponent<GameManager>();
        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("4722669", false);
        }
    }

    public void ShowADS()
    {
        Advertisement.Show(Rewarded_Android);
        gameManager.getPlayerData().Coins += 25;
        gameManager.getPlayerData().SaveData();
        gameManager.UpdateCoin();

    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("cant show ads");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("start showing");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("ads stoped");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("ads finish");
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("ads loaded");
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("ads failed");
    }
}
