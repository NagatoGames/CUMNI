using System;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

    private int coins = 0;
    private int diamonds = 0;
    private int maxLevel = 0;
    private DateTime lastVisitDate;
    private int[] shopDices = { 1, 0, 0, 0, 0 };
    //todo
    private float soundPower = 1f;

    public int Coins { get => coins; set => coins = value; }
    public int Diamonds { get => diamonds; set => diamonds = value; }
    public int MaxLevel { get => maxLevel; set => maxLevel = value; }
    public float SoundPower { get => soundPower; set => soundPower = value; }
    public DateTime LastVisitDate { get => lastVisitDate; set => lastVisitDate = value; }
    public int[] ShopDices { get => shopDices; set => shopDices = value; }

    public void SaveDate()
    {
        PlayerPrefs.SetInt("year", LastVisitDate.Year);
        PlayerPrefs.SetInt("month", LastVisitDate.Month);
        PlayerPrefs.SetInt("day", LastVisitDate.Day);
    }

    public DateTime LoadDate()
    {
        if (!PlayerPrefs.HasKey("year"))
        {
            PlayerPrefs.SetInt("year", new DateTime().Year);
        }

        if (!PlayerPrefs.HasKey("month"))
        {
            PlayerPrefs.SetInt("month", new DateTime().Month);
        }

        if (!PlayerPrefs.HasKey("day"))
        {
            PlayerPrefs.SetInt("day", new DateTime().Day);
        }

        LastVisitDate = new DateTime(PlayerPrefs.GetInt("year", DateTime.Now.Year), PlayerPrefs.GetInt("month", DateTime.Now.Month), PlayerPrefs.GetInt("day", DateTime.Now.Day));
        return LastVisitDate;
    }


    public void SaveData()
    {
        PlayerPrefs.SetInt("coins", Coins);
        PlayerPrefs.SetInt("diamonds", Diamonds);
        PlayerPrefs.SetInt("maxLevel", MaxLevel);
    }

    public void LoadData()
    {
        if (PlayerPrefs.HasKey("coins"))
        {
            Coins = PlayerPrefs.GetInt("coins");
        }
        else
        {
            PlayerPrefs.SetInt("coins", Coins);
        }

        if (PlayerPrefs.HasKey("diamonds"))
        {
            Diamonds = PlayerPrefs.GetInt("diamonds");
        }
        else
        {
            PlayerPrefs.SetInt("diamonds", Diamonds);
        }

        if (PlayerPrefs.HasKey("maxLevel"))
        {
            MaxLevel = PlayerPrefs.GetInt("maxLevel");
        }
        else
        {
            PlayerPrefs.SetInt("maxLevel", MaxLevel);
        }

    }

    public void SaveAllShopData()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerPrefs.SetInt("shopDice" + i, ShopDices[i]);
        }
    }

    public void SaveShopData(int index)
    {
        PlayerPrefs.SetInt("shopDice" + index, ShopDices[index]);
    }

    public int[] LoadShopData()
    {
        for (int i = 0; i < 5; i++)
        {
            if (!PlayerPrefs.HasKey("shopDice" + i))
            {
                PlayerPrefs.SetInt("shopDice" + i, ShopDices[i]);
            }
            else
            {
                ShopDices[i] = PlayerPrefs.GetInt("shopDice" + i);
            }
        }

        return ShopDices;
    }
}