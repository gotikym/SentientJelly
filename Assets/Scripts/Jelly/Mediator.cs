using System;
using UnityEngine;

public class Mediator : MonoBehaviour
{
    [SerializeField] private Player _player;

    private const string JellyRedName = "Red";
    private const string JellyBlueName = "Blue";

    private string _jellyName;

    public event Action<Block> JellyRedChoiced;
    public event Action<Block> JellyBlueChoiced;

    private void Start()
    {
        _player.BlockIsChoiced += BlockIsChoice;
    }

    private void OnDestroy()
    {
        _player.BlockIsChoiced -= BlockIsChoice;
    }

    private void BlockIsChoice(Block block)
    {
       if(block.JellyName != null)
            _jellyName = block.JellyName;

        switch (_jellyName)
        {
            case JellyRedName:
                JellyRedChoiced?.Invoke(block);
                break;

            case JellyBlueName:
                JellyBlueChoiced?.Invoke(block);
                break;
        }
    }
}