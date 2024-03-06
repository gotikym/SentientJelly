using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class Jelly : MonoBehaviour
{
    [SerializeField] protected Mediator _mediator;
    [SerializeField] private Block _startJelly;
    [SerializeField] private Material _materialJelly;
    [SerializeField] private Prefabs _prefabs;
    [SerializeField] private GameObject _mesh;
    [SerializeField] private int _stepsCount;

    protected abstract string Name { get; }

    private const int BotStep = 100;
    private const int TopStep = -100;
    private const int LeftStep = -1;
    private const int RightStep = 1;
    private const int TurnLeftTop = -101;
    private const int TurnLeftBot = 99;
    private const int TurnRightTop = -99;
    private const int TurnRightBot = 101;
    private const int BodyHorizontal = 10;
    private const int BodyVertical = -10;
    private const int TailIndex = 0;
    private const int FirstHeadIndex = 1;
    private const int One = 1;
    private const int OneHundred = 100;

    private List<Block> _jelly = new List<Block>();
    private List<int> _canSteps = new List<int>();

    public string JellyName => Name;
    public int StepsCount => _stepsCount;

    public static event Action JellyChanged;
    public static event Action JellyFilled;
    public event Action<int> StepsCountChanged;

    protected virtual void Start()
    {
        SetStartMesh();
    }

    protected abstract void OnDestroy();

    protected void BlockIsChoice(Block block)
    {
        if (_stepsCount > 0)
            Step(block);
        else if (block.IsJelly)
            Step(block);
    }

    private void Step(Block block)
    {
        int jellyCount = _jelly.Count;
        int lastIndex = _jelly.Count - 1;
        int stepSize = _jelly[lastIndex].Id - block.Id;

        foreach (var step in _canSteps)
        {
            if (step == stepSize && block.IsJelly == false)
            {
                IncreaseJelly(block);
                _stepsCount--;
                JellyChanged?.Invoke();
                StepsCountChanged?.Invoke(_stepsCount);
            }
            else if (step == stepSize && block.IsJelly == true)
            {
                DecreaseJelly(_jelly[lastIndex]);
                _stepsCount++;
                JellyChanged?.Invoke();
                StepsCountChanged?.Invoke(_stepsCount);
            }
        }

        if (jellyCount != _jelly.Count)
            SetMeshes();

        if (_stepsCount == 0)
        {
            JellyFilled?.Invoke();
        }
    }

    private void SetMeshes()
    {
        if (_jelly.Count == 1)
            SetFirstMesh();
        else if (_jelly.Count == 2)
            SetFirstTailHeadMeshes();
        else
            SetJellyMeshes();
    }

    private void SetJellyMeshes()
    {
        int lastIndex = _jelly[_jelly.Count - 1].Id;
        int penultimateIndex = _jelly[_jelly.Count - 2].Id;
        int thirdIndexFromEnd = _jelly[_jelly.Count - 3].Id;
        int bodyIndex = _jelly.Count - 2;
        int headIndex = _jelly.Count - 1;
        int lastStep = lastIndex - penultimateIndex;
        int penultimateStep = penultimateIndex - thirdIndexFromEnd;

        if (_jelly[bodyIndex].transform.childCount > 0)
            _jelly[bodyIndex].Clean();
        if (_jelly[headIndex].transform.childCount > 0)
            _jelly[headIndex].Clean();

        SetBodyMeshes(bodyIndex, lastStep, penultimateStep);
        SetHeadMeshes(headIndex, lastStep);
    }

    private void SetFirstTailHeadMeshes()
    {
        _jelly[0].CleanChild();
        _jelly[1].CleanChild();

        int tailId = _jelly[TailIndex].Id;
        int headId = _jelly[FirstHeadIndex].Id;
        int firstStep = headId - tailId;

        switch (headId - tailId)
        {
            case LeftStep:
                _jelly[TailIndex].Fill(_materialJelly, _prefabs.GetTailMeshByIndex(3), Name);
                break;
            case RightStep:
                _jelly[TailIndex].Fill(_materialJelly, _prefabs.GetTailMeshByIndex(2), Name);
                break;
            case TopStep:
                _jelly[TailIndex].Fill(_materialJelly, _prefabs.GetTailMeshByIndex(0), Name);
                break;
            case BotStep:
                _jelly[TailIndex].Fill(_materialJelly, _prefabs.GetTailMeshByIndex(1), Name);
                break;
        }

        SetHeadMeshes(FirstHeadIndex, firstStep);
    }

    private void SetBodyMeshes(int bodyIndex, int lastStep, int penultimateStep)
    {
        int fewSteps;

        if (Math.Abs(lastStep) == One && Math.Abs(penultimateStep) == One)
            fewSteps = BodyHorizontal;
        else if (Math.Abs(lastStep) == OneHundred && Math.Abs(penultimateStep) == OneHundred)
            fewSteps = BodyVertical;
        else
            fewSteps = lastStep - penultimateStep;

        switch (fewSteps)
        {
            case TurnLeftTop:
                _jelly[bodyIndex].Fill(_materialJelly, _prefabs.GetTurnMeshByIndex(1), Name);
                break;
            case TurnLeftBot:
                _jelly[bodyIndex].Fill(_materialJelly, _prefabs.GetTurnMeshByIndex(0), Name);
                break;
            case TurnRightTop:
                _jelly[bodyIndex].Fill(_materialJelly, _prefabs.GetTurnMeshByIndex(3), Name);
                break;
            case TurnRightBot:
                _jelly[bodyIndex].Fill(_materialJelly, _prefabs.GetTurnMeshByIndex(2), Name);
                break;
            case BodyHorizontal:
                _jelly[bodyIndex].Fill(_materialJelly, _prefabs.GetBodyMeshByIndex(0), Name);
                break;
            case BodyVertical:
                _jelly[bodyIndex].Fill(_materialJelly, _prefabs.GetBodyMeshByIndex(1), Name);
                break;
        }
    }

    private void SetHeadMeshes(int headIndex, int step)
    {
        switch (step)
        {
            case LeftStep:
                _jelly[headIndex].Fill(_materialJelly, _prefabs.GetHeadMeshByIndex(2), Name);
                break;
            case RightStep:
                _jelly[headIndex].Fill(_materialJelly, _prefabs.GetHeadMeshByIndex(3), Name);
                break;
            case TopStep:
                _jelly[headIndex].Fill(_materialJelly, _prefabs.GetHeadMeshByIndex(1), Name);
                break;
            case BotStep:
                _jelly[headIndex].Fill(_materialJelly, _prefabs.GetHeadMeshByIndex(0), Name);
                break;
        }
    }

    private void SetFirstMesh()
    {
        _jelly[0].CleanChild();
        _jelly[0].Fill(_materialJelly, _mesh, Name);
    }

    private void SetStartMesh()
    {
        CombineSteps();
        _jelly.Add(_startJelly);
        _jelly[0].Fill(_materialJelly, _mesh, Name);
    }

    private void IncreaseJelly(Block block)
    {
        _jelly.Add(block);
    }

    private void DecreaseJelly(Block block)
    {
        if (_jelly.Count > 1)
        {
            block.Clean();
            _jelly.Remove(block);
        }
    }

    private void CombineSteps()
    {
        _canSteps.Add(BotStep);
        _canSteps.Add(TopStep);
        _canSteps.Add(LeftStep);
        _canSteps.Add(RightStep);
    }
}