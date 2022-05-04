using UnityEngine;

#if ENABLE_CLOUD_SERVICES_ANALYTICS
using UnityEngine.Analytics;

public class UnityAnalytics : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Start   " + AnalyticsSessionInfo.userId + " " + AnalyticsSessionInfo.sessionState + " " + AnalyticsSessionInfo.sessionId + " " + AnalyticsSessionInfo.sessionElapsedTime);
        AnalyticsSessionInfo.sessionStateChanged += OnSessionStateChanged;
    }

    void OnSessionStateChanged(AnalyticsSessionState sessionState, long sessionId, long sessionElapsedTime, bool sessionChanged)
    {
        Debug.Log("Call    " + AnalyticsSessionInfo.userId + " " + sessionState + " " + sessionId + " " + sessionElapsedTime + " " + sessionChanged);
    }
}
#endif