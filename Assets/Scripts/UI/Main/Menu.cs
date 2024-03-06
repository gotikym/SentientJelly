using IJunior.TypedScenes;
using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private BackgroundMusic _backgroundMusic;

    private int _stoppedTimeScale = 0;
    private int _runningTimeScale = 1;

    public void OpenPannel(GameObject panel)
    {
        panel.SetActive(true);
        Time.timeScale = _stoppedTimeScale;
    }

    public void ClosePanel(GameObject panel)
    {
        panel.SetActive(false);
        Time.timeScale = _runningTimeScale;
    }

    public void CloseSubPanel(GameObject panel)
    {
        panel.SetActive(false);
    }

    public void GoToMain()
    {
        _backgroundMusic.SetCurrentSamples();
        Main.Load();
        Time.timeScale = _runningTimeScale;
    }

    public void Exit()
    {
        _backgroundMusic.SetCurrentSamples();
        Application.Quit();
    }
}