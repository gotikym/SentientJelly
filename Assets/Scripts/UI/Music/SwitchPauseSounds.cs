using System;
using UnityEngine;

public class SwitchPauseSounds : MonoBehaviour
{
    [SerializeField] private GameObject _imageMusicOn;
    [SerializeField] private GameObject _imageMusicOff;
    [SerializeField] private GameObject _imageSFXOn;
    [SerializeField] private GameObject _imageSFXOff;

    private const int PauseOn = 1;
    private const int PauseOff = 0;

    private bool _isMusicPause;
    private bool _isSFXPause;
    private Music _music;
    private IDataProvider _dataProvider;

    public event Action MusicPaused;
    public event Action MusicUnPaused;
    public event Action SFXPaused;
    public event Action SFXUnPaused;

    public void Initialize(Music music, IDataProvider dataProvider)
    {
        _music = music;
        _dataProvider = dataProvider;

        if (_music.GetCurrentMusicStatus() == PauseOff)
            MusicUnPause();
        else
            MusicPause();

        if (_music.GetCurrentSFXStatus() == PauseOff)
            SFXUnPause();
        else
            SFXPause();
    }

    private void MusicUnPause()
    {
        _imageMusicOff.SetActive(false);
        _imageMusicOn.SetActive(true);
        _isMusicPause = false;
    }

    private void MusicPause()
    {
        _imageMusicOn.SetActive(false);
        _imageMusicOff.SetActive(true);
        _isMusicPause = true;
    }

    private void SFXUnPause()
    {
        _imageSFXOff.SetActive(false);
        _imageSFXOn.SetActive(true);
        _isSFXPause = false;
    }

    private void SFXPause()
    {
        _imageSFXOn.SetActive(false);
        _imageSFXOff.SetActive(true);
        _isSFXPause = true;
    }

    public void SwitchMusicPause()
    {
        if (_isMusicPause)
        {
            MusicUnPause();
            _music.SetPauseMusicStatus(PauseOff);

            MusicUnPaused?.Invoke();
        }
        else if (_isMusicPause == false)
        {
            MusicPause();
            _music.SetPauseMusicStatus(PauseOn);

            MusicPaused?.Invoke();
        }

        _dataProvider.Save();
    }

    public void SwitchSFXPause()
    {
        if (_isSFXPause)
        {
            SFXUnPause();
            _music.SetPauseSFXStatus(PauseOff);

            SFXUnPaused?.Invoke();
        }
        else if (_isSFXPause == false)
        {
            SFXPause();
            _music.SetPauseSFXStatus(PauseOn);

            SFXPaused?.Invoke();
        }

        _dataProvider.Save();
    }
}