using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopContent", menuName = "Shop/ShopContent")]
public class ShopContent : ScriptableObject
{
    [SerializeField] private List<HatSkinItem> _hatSkinItem;
    [SerializeField] private List<BorderSkinItem> _borderSkinItem;

    public IEnumerable<HatSkinItem> HatSkinItems => _hatSkinItem;
    public IEnumerable<BorderSkinItem> BorderSkinItems => _borderSkinItem;

    private void OnValidate()
    {
        var hatSkinsDuplicates = _hatSkinItem.GroupBy(item => item.ScinType)
            .Where(array => array.Count() > 1);

        if(hatSkinsDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_hatSkinItem));
        
        var borderSkinsDuplicates = _borderSkinItem.GroupBy(item => item.ScinType)
            .Where(array => array.Count() > 1);

        if (borderSkinsDuplicates.Count() > 0)
            throw new InvalidOperationException(nameof(_borderSkinItem));
    }
}
