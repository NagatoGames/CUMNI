using UnityEngine;

public class SaveDiceButton : MonoBehaviour
{
    [SerializeField] private GameLogic gameLogic;
    [SerializeField] private GameObject saveButtonBgImage;

    public bool isNeedSave = false;
    public int index;

    void Start()
    {
        saveButtonBgImage.SetActive(isNeedSave);
    }

    public void UpdateNeedSave()
    {
        isNeedSave = !isNeedSave;
        saveButtonBgImage.SetActive(isNeedSave);
        gameLogic.DicesTable[index].GetComponent<Dice>().NeedSave = isNeedSave;
    }

    public void SetDontNeedSave()
    {
        isNeedSave = false;
        saveButtonBgImage.SetActive(isNeedSave);
    }
}
