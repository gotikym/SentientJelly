using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class JellyStepSound : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _audioClip;
    [SerializeField] private SwitchPauseSounds _switchPauseMusic;

    private int _isSFXPause;
    private const int PauseOn = 1;
    private const int PauseOff = 0;

    private void OnValidate()
    {
        _audioSource ??= GetComponent<AudioSource>();
    }

    public void Initialize(int isSFXPause)
    {
        _isSFXPause = isSFXPause;
    }

    private void Start()
    {
        Jelly.JellyChanged += PlayJellyStepSound;
        _switchPauseMusic.SFXUnPaused += OnSFXUnPause;
        _switchPauseMusic.SFXPaused += OnSFXPause;
    }

    private void OnDisable()
    {
        Jelly.JellyChanged -= PlayJellyStepSound;
        _switchPauseMusic.SFXUnPaused -= OnSFXUnPause;
        _switchPauseMusic.SFXPaused -= OnSFXPause;
    }

    private void PlayJellyStepSound()
    {
        if (_isSFXPause < PauseOn)
            _audioSource.PlayOneShot(_audioClip);
    }

    private void OnSFXPause()
    {
        _isSFXPause = PauseOn;
    }

    private void OnSFXUnPause()
    {
        _isSFXPause = PauseOff;
    }
}
