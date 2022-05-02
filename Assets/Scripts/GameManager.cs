using System;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private PlayerData PlayerData = new PlayerData();
    [SerializeField] private UIManager _UIManager;
    [SerializeField] private AudioManager _AudioManager;

    [Header("UI items for bonus")]
    [SerializeField] private Button presentButton;
    [SerializeField] private Text coinText;
    [SerializeField] private ParticleSystem coinEffect;

    private int currentDiceStyle = 0;

    public int CurrentDiceStyle { get => currentDiceStyle; set => currentDiceStyle = value; }
    public UIManager UIManager { get => _UIManager; set => _UIManager = value; }
    public Text CoinText { get => coinText; set => coinText = value; }
    public AudioManager AudioManager { get => _AudioManager; set => _AudioManager = value; }

    private void Awake()
    {
        PlayerData.LoadData();
    }

    private void Start()
    {
        CheckPresent();
        UpdateCoin();
    }

    /// <summary>
    /// work with menu buttons
    /// </summary>
    public void CloseButton()
    {
        UIManager.CloseButton();
        //CheckPresent();
    }
    public void OpenOptions()
    {
        UIManager.OpenOptions();
    }
    public void OpenLevels()
    {
        PlayerData.LoadData();
        UIManager.OpenLevels();
    }
    public void OpenShop()
    {
        UIManager.OpenShop();
    }
    public void OpenRuls()
    {
        UIManager.OpenRuls();
    }
    public void ChooseLevel(int levelIndex)
    {
        UIManager.chooseLevel(levelIndex, PlayerData.MaxLevel);
    }

    /// <summary>
    /// validate and get present
    /// </summary>
    public void GetPresent()
    {
        PlayerData.Coins += 25;
        PlayerData.LastVisitDate = DateTime.Today;
        presentButton.interactable = false;
        PlayerData.SaveDate();
        PlayerData.SaveData();
        UIManager.OutPutBalance(PlayerData.Coins, PlayerData.Diamonds);
        coinEffect.Play();
        AudioManager.AudioTakeBonus();
    }
    private void CheckPresent()
    {
        if (DateTime.Compare(PlayerData.LoadDate(), DateTime.Today) < 0)
        {
            //Debug.Log("is later than");
            presentButton.interactable = true;
        }
        else
        {
            //Debug.Log("is earlier than");
            presentButton.interactable = false;
        }
    }

    /// <summary>
    /// work with player data
    /// </summary>
    public void SaveAllShopData()
    {
        PlayerData.SaveAllShopData();
    }
    public void SaveShopData(int index)
    {
        PlayerData.SaveShopData(index);
    }
    public bool[] LoadShopData()
    {
        bool[] activeDices = new bool[5];
        int[] activeDicesData = PlayerData.LoadShopData();
        for (int i = 0; i < activeDices.Length; i++)
        {
            activeDices[i] = activeDicesData[i] == 1;
        }
        return activeDices;
    }
    public PlayerData getPlayerData()
    {
        return PlayerData;
    }
    public void UpdateCoin()
    {
        UpdateData();
        UIManager.OutPutBalance(PlayerData.Coins, PlayerData.Diamonds);
    }
    public void UpdateData()
    {
        PlayerData.LoadData();
    }

}
