using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private SwitchPauseSounds _switchPauseMusic;

    private Music _music;
    private IDataProvider _dataLocalProvider;

    private void OnValidate()
    {
        _audioSource ??= GetComponent<AudioSource>();
    }

    public void Initialize(Music music, IDataProvider dataProvider)
    {
        _music = music;
        _dataLocalProvider = dataProvider;

        if (_music.GetCurrentMusicStatus() < 1)
            OnMusicUnPause();
    }

    private void Awake()
    {
        _switchPauseMusic.MusicUnPaused += OnMusicUnPause;
        _switchPauseMusic.MusicPaused += OnMusicPause;
    }

    private void OnDisable()
    {
        _switchPauseMusic.MusicUnPaused -= OnMusicUnPause;
        _switchPauseMusic.MusicPaused -= OnMusicPause;
    }

    public void SetCurrentSamples()
    {
        _music.SetSoundLength(_audioSource.timeSamples);
        _dataLocalProvider.Save();
    }

    private void OnMusicUnPause()
    {
        _audioSource.Play();
        _audioSource.timeSamples = _music.GetCurrentSoundLength();
    }

    private void OnMusicPause()
    {
        SetCurrentSamples();
        _audioSource.Stop();
        _dataLocalProvider.Save();
    }
}
