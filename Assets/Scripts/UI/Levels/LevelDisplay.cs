using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private GameObject _lockImage;
    [SerializeField] private GameObject _focusImage;
    [SerializeField] private List<GameObject> _activeStars;
    [SerializeField] private List<GameObject> _notActiveStars;
    [SerializeField] private int _level;
    [SerializeField] private BackgroundMusic _backgroundMusic;

    private const int _runningTimeScale = 1;
    private const int MaxStars = 3;

    private int _stars = 3;

    private int _starsCount;
    private int _openLevelsCount;

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);
    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);

    public void SetLevelDisplay(int openLevelsCount, int starsLevel)
    {
        _openLevelsCount = openLevelsCount;
        OffAllStars();


        _focusImage.SetActive(false);

        _starsCount = starsLevel;

        DisplayLevel(openLevelsCount);

        SetStars();
        SetNotActiveStars();
    }

    public void OnButtonClick()
    {
        if (_openLevelsCount >= _level)
        {
            _backgroundMusic.SetCurrentSamples();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + _level);
            Time.timeScale = _runningTimeScale;
        }
    }

    public int GetLevel()
    {
        return _level;
    }

    private void DisplayLevel(int openLevelsCount)
    {
        if (openLevelsCount < _level)
        {
            _lockImage.SetActive(true);
        }
        else if (openLevelsCount >= _level)
        {
            _lockImage.SetActive(false);

            if (_starsCount > 0)
                _focusImage.SetActive(true);
        }
    }

    private void SetStars()
    {
        if (_starsCount >= 0)
            for (int i = 0; i < _starsCount; i++)
            {
                _activeStars[i].SetActive(true);
                _stars--;
            }
    }

    private void SetNotActiveStars()
    {
        for (int i = 0; i < _stars; i++)
            _notActiveStars[i].SetActive(true);
    }

    private void OffAllStars()
    {
        foreach (var star in _activeStars)
            star.SetActive(false);

        foreach (var star in _notActiveStars)
            star.SetActive(false);

        _stars = MaxStars;
    }
}