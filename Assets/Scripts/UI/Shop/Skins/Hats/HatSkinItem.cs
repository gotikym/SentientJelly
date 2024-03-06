using UnityEngine;

[CreateAssetMenu(fileName ="HatSkinItem", menuName = "Shop/HatSkinItem")]
public class HatSkinItem : ShopItem
{
    [field: SerializeField] public HatSkins ScinType { get; private set; }
}