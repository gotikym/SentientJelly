using UnityEngine;

[CreateAssetMenu(fileName = "BorderSkinItem", menuName = "Shop/BorderSkinItem")]
public class BorderSkinItem : ShopItem
{
    [field: SerializeField] public BorderSkins ScinType { get; private set; }
}