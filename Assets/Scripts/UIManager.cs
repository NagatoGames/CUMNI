using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject optionsPanel;
    [SerializeField] private GameObject levelsPanel;
    [SerializeField] private GameObject shopPanel;
    [SerializeField] private GameObject rulsPanel;
    [SerializeField] private GameObject gamePanel;

    [SerializeField] private GameObject Alldices;
    [SerializeField] private List<GameObject> dices;

    [Header("PlayerBalance")]
    [SerializeField] private Text coinsText;
    [SerializeField] private Text diamondsText;

    private GameObject currentPanel;

    [SerializeField] private List<Sprite> botSprits;
    [SerializeField] private List<string> botNames;
    [SerializeField] private Image currentBotSprite;
    [SerializeField] private Text currentBotName;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Text bonusValue;

    [SerializeField] private BotLevel[] botLevels;

    public BotLevel[] BotLevels { get => botLevels; set => botLevels = value; }

    private void Start()
    {
        if (currentPanel == null)
        {
            currentPanel = menuPanel;
            currentPanel.SetActive(true);
        }
    }

    public void CloseButton()
    {
        if (currentPanel.Equals(gamePanel))
        {
            Alldices.SetActive(false);
        }
        currentPanel.SetActive(false);
        currentPanel = menuPanel;
        currentPanel.SetActive(true);
        gameManager.AudioManager.AudioButtonClick();
    }

    public void OpenOptions()
    {
        currentPanel.SetActive(false);
        currentPanel = optionsPanel;
        currentPanel.SetActive(true);
        gameManager.AudioManager.AudioButtonClick();
    }

    public void OpenLevels()
    {
        currentPanel.SetActive(false);
        currentPanel = levelsPanel;
        currentPanel.SetActive(true);
        gameManager.AudioManager.AudioButtonClick();
    }

    public void OpenShop()
    {
        currentPanel.SetActive(false);
        currentPanel = shopPanel;
        currentPanel.SetActive(true);
        gameManager.AudioManager.AudioButtonClick();
    }

    public void OpenRuls()
    {
        currentPanel.SetActive(false);
        currentPanel = rulsPanel;
        currentPanel.SetActive(true);
        gameManager.AudioManager.AudioButtonClick();
    }

    public void OutPutBalance(int Coins, int Diamonds)
    {
        coinsText.text = Coins.ToString();
        diamondsText.text = Diamonds.ToString();
    }

    public void chooseLevel(int levelIndex, int maxLevel)
    {
        if (levelIndex > maxLevel) return;
        currentPanel.SetActive(false);
        currentPanel = gamePanel;
        currentPanel.SetActive(true);

        for (int i = 0; i < dices.Count; i++)
        {
            dices[i].GetComponent<Dice>().SetDiceStyle(gameManager.CurrentDiceStyle);
        }
        Alldices.SetActive(true);
        currentBotSprite.sprite = botSprits[levelIndex];
        currentBotName.text = botNames[levelIndex];

        gamePanel.GetComponent<GameLogic>().StartGame();
        gameManager.AudioManager.AudioButtonClick();
    }

    public void ShowBonusValue(string description, string score)
    {
        bonusValue.text = $"{description} (+{score} он)";
    }

    public void HideDices()
    {
        Alldices.SetActive(false);
    }
}
