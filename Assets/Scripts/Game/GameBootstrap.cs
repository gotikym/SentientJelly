using UnityEngine;

public class GameBootstrap : BootsTrap
{
    [SerializeField] private Victory _victory;
    [SerializeField] private BordersMaterial _bordersMaterial;
    [SerializeField] private SwitchPauseSounds _musicSwitch;
    [SerializeField] private BackgroundMusic _playBackgroundMusic;
    [SerializeField] private JellyStepSound _jellyStepSound;

    private Wallet _wallet;
    private OpenLevels _openLevels;
    private StarsLevels _starsLevels;
    private Music _music;

    protected override void Awake()
    {
        base.Awake();

        InitializeWallet();

        InitializeLevels();

        InitializeVictory();

        InitializeBorders();

        InitializeMusic();        
    }

    private void InitializeWallet()
    {
        _wallet = new (_persistentPlayerData);
    }

    private void InitializeLevels()
    {
        _openLevels = new (_persistentPlayerData);
        _starsLevels = new (_persistentPlayerData);
    }

    private void InitializeVictory()
    {
        _victory.Initialize(_dataProvider, _wallet, _openLevels, _starsLevels);
    }

    private void InitializeBorders()
    {
        BorderSkins borderSkins = _persistentPlayerData.PlayerData.SelectedBorderSkin;

        _bordersMaterial.Initialize(borderSkins);
    }

    private void InitializeMusic()
    {
        _music = new(_persistentPlayerData);
        _musicSwitch.Initialize(_music, _dataProvider);

        InitializeBackgroundMusic();

        InitializeJellyStepSound();
    }

    private void InitializeBackgroundMusic()
    {
        _playBackgroundMusic.Initialize(_music, _dataProvider);
    }

    private void InitializeJellyStepSound()
    {
        _jellyStepSound.Initialize(_music.GetCurrentSFXStatus());
    }
}