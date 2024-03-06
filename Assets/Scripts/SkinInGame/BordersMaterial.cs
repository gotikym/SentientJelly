using System.Collections.Generic;
using UnityEngine;

public class BordersMaterial : MonoBehaviour
{
    [SerializeField] private List<BorderSkinPrefabChange> _borders;
    [SerializeField] private BorderFactory _borderFactory;
    [SerializeField] private Transform _transform;

    private Material _material;
    private BorderSkins _borderSkins;

    public Material Material => _material;

    public void Initialize(BorderSkins borderSkins)
    {
        _borderSkins = borderSkins;

        _material = _borderFactory.Get(_borderSkins, _transform);
    }
}
