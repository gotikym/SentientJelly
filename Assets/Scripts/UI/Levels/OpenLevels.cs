using System;

public class OpenLevels
{
    private IPersistentData _persistentData;

    public OpenLevels(IPersistentData persistentData) => _persistentData = persistentData;

    public void TryOpenLevel(int indexLevel)
    {
        if (indexLevel < 1)
            throw new ArgumentOutOfRangeException(nameof(indexLevel));

        _persistentData.PlayerData.OpenLevels = indexLevel;
    }

    public int GetCurrentOpenLevels() => _persistentData.PlayerData.OpenLevels;
}