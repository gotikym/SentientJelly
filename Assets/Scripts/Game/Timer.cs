using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _timeStart;
    [SerializeField] private TMP_Text _timerText;
    [SerializeField] private TMP_Text _nameLevelText;

    private float _currentTime;

    public float TimeStart => _timeStart;
    public float CurrentTime => _currentTime;

    public event Action TimeIsUp;

    private void Start()
    {
        ResetTime();
        _timerText.text = _currentTime.ToString();
        _nameLevelText.text = "Level " + SceneManager.GetActiveScene().buildIndex;
    }

    private void FixedUpdate()
    {
        SubtractTime();
    }

    public void ResetTime()
    {
        _currentTime = _timeStart;
    }

    private void SubtractTime()
    {
        _currentTime -= Time.deltaTime;
        _timerText.text = Mathf.Round(_currentTime).ToString();

        if (_currentTime <= 0)
            TimeIsUp?.Invoke();
    }
}