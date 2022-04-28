using UnityEngine;
using UnityEngine.UI;

public class ShopDice : MonoBehaviour
{
    [SerializeField] private int price;
    [SerializeField] private Text text;
    private bool isActive;
    [SerializeField] private int index;
    [SerializeField] private GameObject style;

    public int Price { get => price; set => price = value; }
    public Text Text { get => text; set => text = value; }
    public bool IsActive { get => isActive; set => isActive = value; }
    public int Index { get => index; set => index = value; }
    public GameObject Style { get => style; set => style = value; }
}
