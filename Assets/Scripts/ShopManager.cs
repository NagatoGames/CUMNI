using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<ShopDice> shopDices;
    public ShopDice currentDice;

    void Start()
    {
        bool[] activeDices = gameManager.LoadShopData();
        for (int i = 0; i < shopDices.Count; i++)
        {
            if (!activeDices[i])
            {
                shopDices[i].Text.text = shopDices[i].Price.ToString();
                shopDices[i].IsActive = false;
            }
            else
            {
                shopDices[i].Text.text = "Уже куплено!";
                shopDices[i].IsActive = true;
            }
        }
        currentDice = shopDices[0].GetComponent<ShopDice>();
        shopDices[0].GetComponent<ShopDice>().Text.text = "Выбрано!";
    }

    public void ChoesDice(int index)
    {
        if (shopDices[index].IsActive == false)
        {
            if (gameManager.getPlayerData().Coins >= shopDices[index].Price)
            {
                shopDices[index].IsActive = true;
                gameManager.getPlayerData().Coins -= shopDices[index].Price;
                gameManager.getPlayerData().ShopDices[index] = 1;
                gameManager.getPlayerData().SaveData();
                gameManager.getPlayerData().SaveShopData(index);
            }
            else
            {
                return;
            }
        }
        currentDice.Text.text = "Уже куплено!";
        currentDice = shopDices[index].GetComponent<ShopDice>();
        currentDice.Text.text = "Выбрано!";
        gameManager.CurrentDiceStyle = index;
    }
}
