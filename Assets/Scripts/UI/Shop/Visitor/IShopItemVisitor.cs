public interface IShopItemVisitor
{
    void Visit(ShopItem shopItem);
    void Visit(HatSkinItem hatSkinItem);
    void Visit(BorderSkinItem borderSkinItem);
}
