using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class PlayerData
{
    private const int LevelsCount = 36;

    private HatSkins _selectedHatSkin;
    private BorderSkins _selectedBorderSkin;

    private readonly List<HatSkins> _openHatSkins;
    private readonly List<BorderSkins> _openBorderSkins;

    private List<int> _starsLevels;

    private int _money;
    private int _openLevels;
    private int _pauseMusic;
    private int _soundLength;
    private int _pauseSFX;

    public PlayerData()
    {
        _money = 0;
        _openLevels = 1;
        _pauseMusic = 0;
        _soundLength = 0;
        _pauseSFX = 0;

        _selectedHatSkin = HatSkins.Crone;
        _selectedBorderSkin = BorderSkins.bicolor1;

        _openBorderSkins = new List<BorderSkins>() { _selectedBorderSkin };
        _openHatSkins = new List<HatSkins>() { _selectedHatSkin };

        _starsLevels = new List<int>(new int[LevelsCount]);
    }

    [JsonConstructor]
    public PlayerData(int money, int openLevels, int pauseMusic, int pauseSFX, int soundLength, HatSkins selectedHatSkin, BorderSkins selectedBorderSkin,
        List<BorderSkins> openBorderSkins, List<HatSkins> openHatSkins, List<int> starsLevels)
    {
        Money = money;
        OpenLevels = openLevels;
        PauseMusicStatus = pauseMusic;
        PauseSFXStatus = pauseSFX;
        SoundLength = soundLength;

        _selectedHatSkin = selectedHatSkin;
        _selectedBorderSkin = selectedBorderSkin;

        _openBorderSkins = new List<BorderSkins>(openBorderSkins);
        _openHatSkins = new List<HatSkins>(openHatSkins);

        _starsLevels = new List<int>(starsLevels);
    }

    public int Money
    {
        get => _money;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _money = value;
        }
    }

    public int OpenLevels
    {
        get => _openLevels;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _openLevels = value;
        }
    }

    public int PauseMusicStatus
    {
        get => _pauseMusic;
        set
        {
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _pauseMusic = value;
        }
    }

    public int PauseSFXStatus
    {
        get => _pauseSFX;
        set
        {
            if (value < 0 || value > 1)
                throw new ArgumentOutOfRangeException(nameof(value));

            _pauseSFX = value;
        }
    }

    public int SoundLength
    {
        get => _soundLength;
        set
        {
            if (value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _soundLength = value;
        }
    }

    public HatSkins SelectedHatSkin
    {
        get => _selectedHatSkin;
        set
        {
            if (_openHatSkins.Contains(value) == false)
                throw new ArgumentException(nameof(value));

            _selectedHatSkin = value;
        }
    }

    public BorderSkins SelectedBorderSkin
    {
        get => _selectedBorderSkin;
        set
        {
            if (_openBorderSkins.Contains(value) == false)
                throw new ArgumentException(nameof(value));

            _selectedBorderSkin = value;
        }
    }

    public IEnumerable<int> StarsLevels => _starsLevels;
    public IEnumerable<HatSkins> OpenHatSkins => _openHatSkins;
    public IEnumerable<BorderSkins> OpenBorderSkins => _openBorderSkins;

    public void OpenHatSkin(HatSkins skin)
    {
        if (_openHatSkins.Contains(skin))
            throw new ArgumentException(nameof(skin));

        _openHatSkins.Add(skin);
    }

    public void OpenBorderSkin(BorderSkins skin)
    {
        if (_openBorderSkins.Contains(skin))
            throw new ArgumentException(nameof(skin));

        _openBorderSkins.Add(skin);
    }

    public int TryGetStarsLevel(int levelNumber)
    {
        if (_starsLevels[levelNumber] > 0)
            return _starsLevels[levelNumber];

        return 0;
    }

    public void AddStarsLevel(int levelNumber, int stars)
    {
        if (_starsLevels[levelNumber] < stars)
            _starsLevels[levelNumber] = stars;
    }
}