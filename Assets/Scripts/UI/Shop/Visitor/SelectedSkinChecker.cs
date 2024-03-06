public class SelectedSkinChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public bool IsSelected { get; private set; }

    public SelectedSkinChecker(IPersistentData persistentData)
        => _persistentData = persistentData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatSkinItem hatSkinItem)
        => IsSelected = _persistentData.PlayerData.SelectedHatSkin == hatSkinItem.ScinType;

    public void Visit(BorderSkinItem borderSkinItem)
        => IsSelected = _persistentData.PlayerData.SelectedBorderSkin == borderSkinItem.ScinType;
}
