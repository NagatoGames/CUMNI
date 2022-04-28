using UnityEngine;

public class BotLevel : MonoBehaviour
{
    public int level;
    [SerializeField] private GameObject closeLogo;
    [SerializeField] private GameManager gameManager;

    public void OpenLevel()
    {
        gameManager.UpdateData();
        int maxOpenLevel = gameManager.getPlayerData().MaxLevel;
        if (maxOpenLevel >= level) closeLogo.SetActive(false);
    }

    private void Start()
    {
        OpenLevel();
    }

}
