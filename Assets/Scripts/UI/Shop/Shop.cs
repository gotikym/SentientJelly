using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [SerializeField] private ShopContent _contentItems;

    [SerializeField] private ShopCategoryButton _hatSkinsButton;
    [SerializeField] private ShopCategoryButton _borderSkinsButton;

    [SerializeField] private BuyButton _buyButton;
    [SerializeField] private Button _selectionButton;
    [SerializeField] private Image _selectedText;

    [SerializeField] private ShopPanel _shopPanel;

    [SerializeField] private SkinPlacement _skinPlacement;

    [SerializeField] private Camera _modelCamera;
    [SerializeField] private Transform _hatCategoryCameraPosition;
    [SerializeField] private Transform _borderCategoryCameraPosition;

    private IDataProvider _dataProvider;

    private ShopItemView _previewedItem;

    private Wallet _wallet;

    private SkinSelector _skinSelector;
    private SkinUnlocker _skinUnlocker;
    private OpenSkinsChecker _openSkinsCheker;
    private SelectedSkinChecker _selectedSkinChecker;

    private void OnEnable()
    {
        _hatSkinsButton.Click += OnHatSkinsButtonClick;
        _borderSkinsButton.Click += OnBorderSkinsButtonClick;        

        _buyButton.Click += OnBuyButtonClick;
        _selectionButton.onClick.AddListener(OnSelectionButtonClick);
    }

    private void OnDestroy()
    {
        _hatSkinsButton.Click -= OnHatSkinsButtonClick;
        _borderSkinsButton.Click -= OnBorderSkinsButtonClick;
        _shopPanel.ItemViewClicked -= OnItemViewClicked;

        _buyButton.Click -= OnBuyButtonClick;
        _selectionButton.onClick.RemoveListener(OnSelectionButtonClick);
    }

    public void Initialize(IDataProvider dataProvider, Wallet wallet, OpenSkinsChecker openSkinsChecker
        , SelectedSkinChecker selectedSkinChecker, SkinSelector skinSelector, SkinUnlocker skinUnlocker)
    {
        _wallet = wallet;
        _openSkinsCheker = openSkinsChecker;
        _selectedSkinChecker = selectedSkinChecker;
        _skinSelector = skinSelector;
        _skinUnlocker = skinUnlocker;

        _dataProvider = dataProvider;

        _shopPanel.Initialize(openSkinsChecker, selectedSkinChecker);

        _shopPanel.ItemViewClicked += OnItemViewClicked;

        OnHatSkinsButtonClick();
    }

    private void OnItemViewClicked(ShopItemView item)
    {
        _previewedItem = item;
        _skinPlacement.InstantiateModel(_previewedItem.Model);

        _openSkinsCheker.Visit(_previewedItem.Item);

        if(_openSkinsCheker.IsOpened)
        {
            _selectedSkinChecker.Visit(_previewedItem.Item);

            if(_selectedSkinChecker.IsSelected)
            {
                ShowSelectedText();
                return;
            }

            ShowSelectionButton();
        }
        else
        {
            ShowBuyButton(_previewedItem.Price);
        }
    }

    private void OnBuyButtonClick()
    {
        if(_wallet.IsEnough(_previewedItem.Price))
        {
            _wallet.Spend(_previewedItem.Price);

            _skinUnlocker.Visit(_previewedItem.Item);

            SelectSkin();

            _previewedItem.UnLock();

            _dataProvider.Save();
        }
    }

    private void OnSelectionButtonClick()
    {
        SelectSkin();

        _dataProvider.Save();
    }

    private void OnBorderSkinsButtonClick()
    {
        _borderSkinsButton.Select();
        _hatSkinsButton.UnSelect();

        UpdateCameraTransform(_borderCategoryCameraPosition);

        _shopPanel.Show(_contentItems.BorderSkinItems.Cast<ShopItem>());
    }

    private void OnHatSkinsButtonClick()
    {
        _borderSkinsButton.UnSelect();
        _hatSkinsButton.Select();

        UpdateCameraTransform(_hatCategoryCameraPosition);

        _shopPanel.Show(_contentItems.HatSkinItems.Cast<ShopItem>());
    }

    private void UpdateCameraTransform(Transform transform)
    {
        _modelCamera.transform.position = transform.position;
        _modelCamera.transform.rotation = transform.rotation;
    }

    private void SelectSkin()
    {
        _skinSelector.Visit(_previewedItem.Item);
        _shopPanel.Select(_previewedItem);
        ShowSelectedText();
    }

    private void ShowBuyButton(int price)
    {
        _buyButton.gameObject.SetActive(true);
        _buyButton.UpdateText(price);

        if (_wallet.IsEnough(price))
            _buyButton.Unlock();
        else
            _buyButton.Lock();

        HideSelectedText();
        HideSelectionButton();
    }

    private void ShowSelectionButton()
    {
        _selectionButton.gameObject.SetActive(true);
        HideBuyButton();
        HideSelectedText();
    }

    private void ShowSelectedText()
    {
        _selectedText.gameObject.SetActive(true);
        HideBuyButton();
        HideSelectionButton();
    }

    private void HideBuyButton() => _buyButton.gameObject.SetActive(false);
    private void HideSelectionButton() => _selectionButton.gameObject.SetActive(false);
    private void HideSelectedText() => _selectedText.gameObject.SetActive(false);
}
