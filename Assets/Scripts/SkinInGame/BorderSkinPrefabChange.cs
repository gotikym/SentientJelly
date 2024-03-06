using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BorderSkinPrefabChange : MonoBehaviour
{
    [SerializeField] private BordersMaterial _bordersMaterial;

    private Renderer _renderer;

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        _renderer.material = _bordersMaterial.Material;
    }
}