using UnityEngine;

public class Dice : MonoBehaviour
{
    private int value;
    private bool needSave;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject[] styles;

    public int Value { get => value; set => this.value = value; }
    public bool NeedSave { get => needSave; set => needSave = value; }
    public Animator Animator { get => animator; set => animator = value; }
    public GameObject[] Styles { get => styles; set => styles = value; }

    public override string ToString()
    {
        return $" dice: val = {value}; isNeedSave = {needSave}";
    }

    public void SetDiceStyle(int index)
    {
        for (int i = 0; i < styles.Length; i++)
        {
            styles[i].SetActive(false);
        }
        styles[index].SetActive(true);
    }
}
