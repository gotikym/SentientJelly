using System.Collections.Generic;
using UnityEngine;

public class ListLevelDisplay : MonoBehaviour
{
    [SerializeField] private List<LevelDisplay> _levelDisplays;

    private OpenLevels _openLevels;
    private StarsLevels _starsLevels;

    private int _starsLevel = 0;

    private int _openLevelsCount;

    public int OpenLevelsCount => _openLevelsCount;

    public void Initialize(OpenLevels openLevels, StarsLevels starsLevels)
    {
        _openLevels = openLevels;
        _starsLevels = starsLevels;

        _openLevelsCount = _openLevels.GetCurrentOpenLevels();

        SetLevelsDisplay();
    }

    private void SetLevelsDisplay()
    {
        foreach (LevelDisplay levelDisplay in _levelDisplays)
        {
            _starsLevel = _starsLevels.GetCurrentStarsLevel(levelDisplay.GetLevel());
            levelDisplay.SetLevelDisplay(_openLevelsCount, _starsLevel);
        }
    }
}
