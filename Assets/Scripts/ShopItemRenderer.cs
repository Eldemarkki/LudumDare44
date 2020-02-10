using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ShopItemRenderer : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    private Image background;

    public ShopItem shopItem;

    [SerializeField] private Color normalColor;
    [SerializeField] private Color hoveredColor;
    
    [SerializeField] private Image icon;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text costText;
    [SerializeField] private TMP_Text incomeText;
    
    private void Awake()
    {
        background = GetComponent<Image>();
        background.color = normalColor;
    }

    public void UpdateRenderer()
    {
        icon.sprite = shopItem.icon;
        nameText.text = shopItem.name;
        costText.text = shopItem.cost.ToString();
        incomeText.text = shopItem.income.ToString();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        background.color = hoveredColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        background.color = normalColor;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        ShopManager.instance.Purchase(shopItem);
    }
}