using UnityEngine;

[CreateAssetMenu(fileName = "New Shop Item", menuName = "Shop Item")]
public class ShopItem : ScriptableObject
{
    public Sprite icon;
    public new string name;
    public long cost;
    public long income;
}
