using Agava.YandexGames;
using UnityEngine;

public class MainMenuBootsTrap : BootsTrap
{
    [SerializeField] private Shop _shop;
    [SerializeField] private WalletView _walletView;
    [SerializeField] private ListLevelDisplay _listLevelDisplays;
    [SerializeField] private SwitchPauseSounds _musicSwitch;
    [SerializeField] private BackgroundMusic _playBackgroundMusic;

    private Wallet _wallet;
    private OpenLevels _openLevels;
    private StarsLevels _starsLevels;
    private Music _music;

    protected override void Awake()
    {
        //OnCallGameReady();

        base.Awake();

        InitializeWallet();

        InitializeLevels();

        InitializeShop();

        InitializeMusicVolume();

        InitializeBackgroundMusic();
    }

    private void InitializeWallet()
    {
        _wallet = new(_persistentPlayerData);

        _walletView.Initialize(_wallet);
    }

    private void InitializeLevels()
    {
        _openLevels = new(_persistentPlayerData);
        _starsLevels = new(_persistentPlayerData);

        _listLevelDisplays.Initialize(_openLevels, _starsLevels);
    }

    private void InitializeShop()
    {
        OpenSkinsChecker openSkinsChecker = new(_persistentPlayerData);
        SelectedSkinChecker selectedSkinChecker = new(_persistentPlayerData);
        SkinSelector skinSelector = new(_persistentPlayerData);
        SkinUnlocker skinUnlocker = new(_persistentPlayerData);

        _shop.Initialize(_dataProvider, _wallet, openSkinsChecker, selectedSkinChecker, skinSelector, skinUnlocker);
    }

    private void InitializeMusicVolume()
    {
        _music = new(_persistentPlayerData);
        _musicSwitch.Initialize(_music, _dataProvider);
    }

    private void InitializeBackgroundMusic()
    {
        _playBackgroundMusic.Initialize(_music, _dataProvider);
    }

    private void OnCallGameReady()
    {
        YandexGamesSdk.GameReady();
    }
}