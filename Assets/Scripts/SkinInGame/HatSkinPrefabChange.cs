using UnityEngine;

public class HatSkinPrefabChange : BootsTrap
{
    [SerializeField] private Transform _hatSkinPlace;
    [SerializeField] private HatFactory _hatFactory;

    private Hat _hat;

    protected override void Awake()
    {
        base.Awake();

        SpawnHatSkin();
    }

    private void SpawnHatSkin()
    {
        _hat = _hatFactory.Get(_persistentPlayerData.PlayerData.SelectedHatSkin, _hatSkinPlace.transform);
    }
}