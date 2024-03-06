using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    private bool _isBlock = false;

    public event Action<Block> BlockIsChoiced;

    private void OnEnable()
    {
        UnBlockChoice();
        _timer.TimeIsUp += BlockChoice;
        Victory.LevelFinised += BlockChoice;
    }

    private void OnDisable()
    {
        _timer.TimeIsUp -= BlockChoice;
        Victory.LevelFinised -= BlockChoice;
    }

    private void Update()
    {
        ChoiceBlock();
    }

    private void ChoiceBlock()
    {
        if (_isBlock == false)
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                Physics.Raycast(ray, out hit);

                if (hit.collider != null)
                    if (hit.transform.TryGetComponent(out Block block))
                        BlockIsChoiced?.Invoke(block);
            }
    }

    private void BlockChoice()
    {
        _isBlock = true;
    }

    private void UnBlockChoice()
    {
        _isBlock = false;
    }
}