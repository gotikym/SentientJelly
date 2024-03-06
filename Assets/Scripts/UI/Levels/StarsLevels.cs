public class StarsLevels
{
    private IPersistentData _persistentData;

    public StarsLevels(IPersistentData persistentData) => _persistentData = persistentData;

    public int GetCurrentStarsLevel(int indexLevel) => _persistentData.PlayerData.TryGetStarsLevel(indexLevel);

    public void TryAddStars(int levelNumber, int starsCount)
    {
        int starsLevel = _persistentData.PlayerData.TryGetStarsLevel(levelNumber);

        if (starsLevel < starsCount)
            _persistentData.PlayerData.AddStarsLevel(levelNumber, starsCount);
    }
}
