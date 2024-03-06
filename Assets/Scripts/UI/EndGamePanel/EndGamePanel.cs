using IJunior.TypedScenes;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class EndGamePanel : MonoBehaviour
{
    [SerializeField] private BackgroundMusic _backgroundMusic;
    [SerializeField] private GameObject Panel;
    [SerializeField] private Animator _animator;
    [SerializeField] protected Timer _timer;

    protected int StoppedTimeScale = 0;
    protected int RunningTimeScale = 1;
    protected int NextSceneIndex = 1;

    public abstract string AnimationName { get; }

    protected abstract void OnEnable();

    protected abstract void OnDisable();

    public void OnRestartButtonClick()
    {
        _backgroundMusic.SetCurrentSamples();
        Panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = RunningTimeScale;
    }

    public void OnMainMenuButtonClick()
    {
        _backgroundMusic.SetCurrentSamples();
        Main.Load();
        Time.timeScale = RunningTimeScale;
    }

    public void OnNextLevelButtonClick()
    {
        _backgroundMusic.SetCurrentSamples();
        Panel.SetActive(false);
        Time.timeScale = RunningTimeScale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + NextSceneIndex);
    }

    public void OpenPanel()
    {
        Panel.SetActive(true);

        _animator.Play(AnimationName);

        StartCoroutine(WaitEndAnimation());
    }

    private IEnumerator WaitEndAnimation()
    {
        _timer.ResetTime();
        float animationLength = _animator.GetCurrentAnimatorStateInfo(0).length;

        yield return new WaitForSeconds(animationLength);

        Time.timeScale = StoppedTimeScale;
    }

    protected void ClosePanel()
    {
        Panel.SetActive(false);
        Time.timeScale = RunningTimeScale;
    }
}