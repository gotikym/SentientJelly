using UnityEngine;

public class Block : MonoBehaviour
{
    [SerializeField] private int _id;

    private bool _isJelly = false;

    private string _jellyName;

    public int Id => _id;
    public bool IsJelly => _isJelly;
    public string JellyName => _jellyName;

    public void Fill(Material materialJelly, GameObject meshJelly, string jellyName)
    {
        TrySetMaterial(materialJelly, meshJelly);

        var mesh = Instantiate(meshJelly).transform;
        mesh.SetParent(transform);
        mesh.localPosition = new Vector3(0, 0, 0);

        _isJelly = true;
        _jellyName = jellyName;
    }

    public void Clean()
    {
        Destroy(transform.GetChild(0).gameObject);
        _isJelly = false;
        _jellyName = null;
    }

    public void CleanChild()
    {
        foreach (Transform child in transform)
            Destroy(child.gameObject);
    }

    private void TrySetMaterial(Material materialJelly, GameObject meshJelly)
    {
        if (meshJelly.TryGetComponent<MeshRenderer>(out var renderer))
            renderer.material = materialJelly;
    }
}
