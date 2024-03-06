using System;
using UnityEngine;

[CreateAssetMenu(fileName = "BorderFactory", menuName = "Gameplay/BorderFactory")]
public class BorderFactory : ScriptableObject
{
    [SerializeField] private Border _bicolor1;
    [SerializeField] private Border _bicolor2;
    [SerializeField] private Border _bicolor3;
    [SerializeField] private Border _bicolor4;

    public Material Get(BorderSkins skinType, Transform spawnPosition)
    {
        Border border = Instantiate(GetPrefab(skinType), spawnPosition);
        
        return border.GetComponent<Renderer>().material;
    }

    private Border GetPrefab(BorderSkins skinType)
    {
        switch (skinType)
        {
            case BorderSkins.bicolor1:
                return _bicolor1;
            case BorderSkins.bicolor2:
                return _bicolor2;
            case BorderSkins.bicolor3:
                return _bicolor3;
            case BorderSkins.bicolor4:
                return _bicolor4;
            default:
                throw new ArgumentException(nameof(skinType));
        }
    }
}