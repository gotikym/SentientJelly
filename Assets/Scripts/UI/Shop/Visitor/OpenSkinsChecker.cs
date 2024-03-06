using System.Linq;

public class OpenSkinsChecker : IShopItemVisitor
{
    private IPersistentData _persistentData;

    public bool IsOpened { get; private set; }

    public OpenSkinsChecker(IPersistentData persistentData) => _persistentData = persistentData;

    public void Visit(ShopItem shopItem) => Visit((dynamic)shopItem);

    public void Visit(HatSkinItem hatSkinItem)
        => IsOpened = _persistentData.PlayerData.OpenHatSkins.Contains(hatSkinItem.ScinType);

    public void Visit(BorderSkinItem borderSkinItem)
        => IsOpened = _persistentData.PlayerData.OpenBorderSkins.Contains(borderSkinItem.ScinType);
}
