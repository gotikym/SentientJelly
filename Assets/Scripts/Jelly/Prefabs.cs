using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Prefabs : MonoBehaviour
{
    [SerializeField] private List<GameObject> _tail;
    [SerializeField] private List<GameObject> _heads;
    [SerializeField] private List<GameObject> _body;
    [SerializeField] private List<GameObject> _turn;

    public GameObject GetTailMeshByIndex(int index)
    {
        return _tail.ElementAt(index);
    }

    public GameObject GetBodyMeshByIndex(int index)
    {
        return _body.ElementAt(index);
    }

    public GameObject GetTurnMeshByIndex(int index)
    {
        return _turn.ElementAt(index);
    }

    public GameObject GetHeadMeshByIndex(int index)
    {
        return _heads.ElementAt(index);
    }
}