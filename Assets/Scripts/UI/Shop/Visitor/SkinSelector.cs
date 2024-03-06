public class SkinSelector : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public SkinSelector(IPersistentData persistentData)
        => _persistentData = persistentData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatSkinItem hatSkinItem)
        => _persistentData.PlayerData.SelectedHatSkin = hatSkinItem.ScinType;

    public void Visit(BorderSkinItem borderSkinItem)
        => _persistentData.PlayerData.SelectedBorderSkin = borderSkinItem.ScinType;
}
