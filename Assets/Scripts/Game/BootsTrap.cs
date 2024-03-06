using UnityEngine;

public abstract class BootsTrap : MonoBehaviour
{
    protected IDataProvider _dataProvider;
    protected IPersistentData _persistentPlayerData;

    protected virtual void Awake()
    {
        InitializeData();
    }

    private void InitializeData()
    {
        _persistentPlayerData = new PersistentData();
        _dataProvider = new DataLocalProvider(_persistentPlayerData);

        LoadDataOrInit();
    }

    private void LoadDataOrInit()
    {
        if (_dataProvider.TryLoad() == false)
            _persistentPlayerData.PlayerData = new PlayerData();
    }
}