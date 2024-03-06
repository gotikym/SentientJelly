using TMPro;
using UnityEngine;

public class StepsCountView : MonoBehaviour
{
    [SerializeField] private TextMeshPro _text;
    [SerializeField] private Jelly _jelly;

    private const string NullText = " ";

    private void Start()
    {
        _jelly.StepsCountChanged += StepsCountChange;
        _text.text = _jelly.StepsCount.ToString();
    }

    private void OnDestroy()
    {
        _jelly.StepsCountChanged -= StepsCountChange;
    }

    private void StepsCountChange(int stepsCount)
    {
        if (stepsCount == 0)
            _text.text = NullText;
        else
            _text.text = stepsCount.ToString();
    }
}
