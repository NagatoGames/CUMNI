using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameLogic : MonoBehaviour
{
    private DiceCombinationManager dcm = new DiceCombinationManager();
    [SerializeField] private BotLevel botLevel;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private List<Dice> dicesTable;

    [SerializeField] private GameObject bonusValue;
    [SerializeField] private Text playerScoreTxt;
    [SerializeField] private Text botScoreTxt;
    [SerializeField] private Text infoTxt;
    [SerializeField] private GameObject infoPanel;
    [SerializeField] private Text currentBotName;

    [SerializeField] private GameObject rollButton;
    [SerializeField] private GameObject finishTurnButton;

    public string botName;
    public int playerScore;
    public int botScore;
    string info = "";
    bool isPlayerTurn;
    List<Dice> dicesCombination;

    private int totalScorePlayer;
    private int totalScoreBot;
    [SerializeField] private Text totalScoreView;

    int terns = 0;

    public List<Dice> DicesTable { get => dicesTable; set => dicesTable = value; }

    public void Start()
    {
        StopAllCoroutines();
        StartGame();
    }

    public void StartGame()
    {
        ClearGameData();
        botName = currentBotName.text;
        System.Random rnd = new System.Random();
        isPlayerTurn = rnd.Next(1, 3) == 1;
        info = isPlayerTurn ? "Вы ходите первым" : $"{botName} ходит первой";
        infoTxt.text = info;
        infoPanel.GetComponent<Animation>().Play();

        StartCoroutine(GameProcess());
    }

    private void ClearGameData()
    {
        botScore = 0;
        playerScore = 0;
        playerScoreTxt.text = playerScore.ToString();
        botScoreTxt.text = botScore.ToString();
        totalScorePlayer = 0;
        totalScoreBot = 0;
        totalScoreView.text = $"{totalScorePlayer}/{totalScoreBot}";
    }

    private void EndOfGame()
    {
        if (playerScore > botScore)
        {
            info = "Раунд окончен в вашу пользу!";
            totalScorePlayer++;
            gameManager.AudioManager.AudioWin();
        }
        else
        {
            info = "Раунд проигран!";
            totalScoreBot++;
            gameManager.AudioManager.AudioLose();
        }
        totalScoreView.text = $"{totalScorePlayer}/{totalScoreBot}";

        infoTxt.text = info;
        infoPanel.GetComponent<Animation>().Play();
        playerScore = 0;
        botScore = 0;
        playerScoreTxt.text = playerScore.ToString();
        botScoreTxt.text = botScore.ToString();

    }

    private bool GG()
    {
        return totalScoreBot == 2 || totalScorePlayer == 2;
    }

    private void CheckWinner()
    {
        if (totalScorePlayer > totalScoreBot)
        {
            info = $"Вы победили со счетом {totalScorePlayer}:{totalScoreBot}!";
            gameManager.getPlayerData().Coins += 50;
            gameManager.getPlayerData().MaxLevel++;
            gameManager.getPlayerData().SaveData();
            foreach (BotLevel bt in gameManager.UIManager.BotLevels)
            {
                bt.OpenLevel();
            }
        }
        else
        {
            info = $"Вы проиграли со счетом {totalScorePlayer}:{totalScoreBot}!";
            gameManager.getPlayerData().Coins += 10;
            gameManager.getPlayerData().SaveData();
        }
        gameManager.getPlayerData().LoadData();
        infoTxt.text = info;
        infoPanel.GetComponent<Animation>().Play();
    }

    IEnumerator GameProcess()
    {
        yield return new WaitForSeconds(2);

        if (isEndOfGame())
        {
            EndOfGame();
            yield return new WaitForSeconds(2);
        }

        if (GG())
        {
            CheckWinner();
            yield return new WaitForSeconds(4);
            gameManager.UIManager.HideDices();
            gameManager.UIManager.OpenLevels();
            yield return new WaitForSeconds(2);
        }

        yield return new WaitForSeconds(2);
        info = isPlayerTurn ? "Ваш ход" : $"{botName} ходит";
        infoTxt.text = info;
        infoPanel.GetComponent<Animation>().Play();
        yield return new WaitForSeconds(2);

        if (!isPlayerTurn)
        {
            terns = 0;
            finishTurnButton.SetActive(false);
            rollButton.SetActive(false);

            BotLogic();
            yield return new WaitForSeconds(3);
            finishTern();
            yield return new WaitForSeconds(2);
        }
        else
        {
            terns = 0;
            finishTurnButton.SetActive(true);
            rollButton.SetActive(true);
            PlayerLogic();
            yield return new WaitForSeconds(2);
        }
    }

    private void PlayerLogic()
    {
        rollDices();
    }

    private void BotLogic()
    {
        rollDices();
        if (dcm.isPoker(dicesTable)
            || dcm.isFourOfAKind(dicesTable)
            || dcm.isFullHouse(dicesTable)
            || dcm.isSmallStreet(dicesTable)
            || dcm.isBigStreet(dicesTable))
        {
            return;
        }
        else
        {
            dcm.rollDices(dicesTable);
            if (dcm.isPoker(dicesTable)
                || dcm.isFourOfAKind(dicesTable)
                || dcm.isFullHouse(dicesTable)
                || dcm.isSmallStreet(dicesTable)
                || dcm.isBigStreet(dicesTable)
                || dcm.isTwoPair(dicesTable)
                || dcm.isSet(dicesTable))
            {
                return;
            }
            else
            {
                dcm.rollDices(dicesTable);
            }
        }
    }

    public void finishTern()
    {
        StopAllCoroutines();

        dicesCombination = dicesTable;
        Combination combination = dcm.getCombination(dicesCombination);
        infoTxt.text = combination.ToString();
        infoPanel.GetComponent<Animation>().Play();
        if (isPlayerTurn)
        {
            playerScore += combination.score;
            playerScoreTxt.text = playerScore.ToString();
        }
        else
        {
            botScore += combination.score;
            botScoreTxt.text = botScore.ToString();
        }
        info = combination.description;
        isPlayerTurn = !isPlayerTurn;

        StartCoroutine(GameProcess());
    }

    private bool isEndOfGame()
    {
        return playerScore >= 100 || botScore >= 100;
    }

    public void rollDices()
    {
        terns++;
        if (terns == 3)
        {
            rollButton.SetActive(false);
        }
        foreach (Dice dice in dicesTable)
        {
            if (!dice.NeedSave)
            {
                dice.gameObject.SetActive(false);
                dice.gameObject.SetActive(true);
                dice.NeedSave = false;
                dice.Animator.SetBool("save", false);
            }
        }
        Combination combination = dcm.rollDices(dicesTable);
        bonusValue.GetComponent<Text>().text = combination.ToString();
        bonusValue.GetComponent<Animation>().Play();
        gameManager.AudioManager.AudioRollDice();
    }
}
