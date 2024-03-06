using System.Collections.Generic;
using UnityEngine;

public class DisplayStars : MonoBehaviour
{
    [SerializeField] private Victory _victory;
    [SerializeField] private List<GameObject> _stars;

    private void OnEnable()
    {
        _victory.StarsCalculated += StarsCalculate;
    }

    private void OnDisable()
    {
        _victory.StarsCalculated -= StarsCalculate;
    }

    private void StarsCalculate(int starsCount)
    {
        for (int i = 0; i < starsCount; i++)
            _stars[i].SetActive(true);
    }
}
