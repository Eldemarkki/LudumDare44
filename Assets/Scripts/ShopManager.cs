using System;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public ShopItem[] shopItems;

    public GameObject shopItemUIPrefab;
    public Transform shopContentPanel;

    private SoundManager soundManager;
    
    public static ShopManager instance;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        soundManager = SoundManager.instance;
        
        shopItems = shopItems.OrderBy(s => s.cost).ToArray();
        
        for (var i = 0; i < shopItems.Length; i++)
        {
            GameObject shopItemPanel = Instantiate(shopItemUIPrefab, shopContentPanel);

            shopItemPanel.name = $"Shop Item {(i + 1).ToString()}";

            ShopItemRenderer sir = shopItemPanel.GetComponent<ShopItemRenderer>();

            sir.shopItem = shopItems[i];
            sir.UpdateRenderer();
        }
    }

    public void Purchase(ShopItem shopItem)
    {
        if (GameManager.instance.blood - shopItem.cost < 0)
            return;
        
        soundManager.Play("Purchase");
        
        GameManager.instance.ReduceBlood(shopItem.cost);
        GameManager.instance.AddBloodPerSecond(shopItem.income);
    }
}
