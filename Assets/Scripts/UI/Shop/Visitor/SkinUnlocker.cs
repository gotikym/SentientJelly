public class SkinUnlocker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public SkinUnlocker(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatSkinItem hatSkinItem)
        => _persistentData.PlayerData.OpenHatSkin(hatSkinItem.ScinType);

    public void Visit(BorderSkinItem borderSkinItem)
        => _persistentData.PlayerData.OpenBorderSkin(borderSkinItem.ScinType);
}
